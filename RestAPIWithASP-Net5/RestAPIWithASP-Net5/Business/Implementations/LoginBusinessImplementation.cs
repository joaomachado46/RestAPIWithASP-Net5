using RestAPIWithASP_Net5.Configurations;
using RestAPIWithASP_Net5.Data;
using RestAPIWithASP_Net5.Data.VO;
using RestAPIWithASP_Net5.Repository;
using RestAPIWithASP_Net5.Services;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace RestAPIWithASP_Net5.Business.Implementations
{
    public class LoginBusinessImplementation : ILoginBusiness
    {
        private const string DATE_FORMAT = "yyyy-MM-dd:HH:mm:ss";
        private TokenConfiguration TokenConfiguration;

        private IUserRepository UserRepository;
        private readonly ITokenService TokenService;

        public LoginBusinessImplementation(TokenConfiguration tokenConfiguration, IUserRepository userRepository, ITokenService tokenService)
        {
            TokenConfiguration = tokenConfiguration;
            UserRepository = userRepository;
            TokenService = tokenService;
        }

        public TokenVO ValidateCredencials(UserVO userCredencials)
        {
            var user = UserRepository.ValidateCredencials(userCredencials);
            if (user == null) return null;
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")),
                new Claim(JwtRegisteredClaimNames.UniqueName, user.UserName)
            };

            var accesToken = TokenService.GenerateAccessToken(claims);
            var refreshToken = TokenService.GenerateRefreshToken();

            user.RefreshToken = refreshToken;
            user.RefreshTokenTime = DateTime.Now.AddDays(TokenConfiguration.DaysToExpirity);

            UserRepository.RefreshUserInfo(user);

            DateTime createDate = DateTime.Now;
            DateTime expirationDate = DateTime.Now.AddMinutes(TokenConfiguration.Minutes);

            return new TokenVO(true, createDate.ToString(DATE_FORMAT), expirationDate.ToString(DATE_FORMAT), accesToken, refreshToken);
        }

        public TokenVO ValidateCredencials(TokenVO token)
        {
            var accesToken = token.AccessToken;
            var refreshToken = token.RefreshToken;

            var principal = TokenService.GetPrincipalFromExpiredToken(accesToken);

            var userName = principal.Identity.Name;

            var user = UserRepository.ValidateCredencials(userName);

            if (user == null || user.RefreshToken != refreshToken || user.RefreshTokenTime <= DateTime.Now)
            {
                return null;
            }

            accesToken = TokenService.GenerateAccessToken(principal.Claims);
            refreshToken = TokenService.GenerateRefreshToken();

            user.RefreshToken = refreshToken;

            UserRepository.RefreshUserInfo(user);

            DateTime createDate = DateTime.Now;
            DateTime expirationDate = DateTime.Now.AddMinutes(TokenConfiguration.Minutes);

            return new TokenVO(true, createDate.ToString(DATE_FORMAT), expirationDate.ToString(DATE_FORMAT), accesToken, refreshToken);

        }

        public bool Revoke(string userName)
        {
            return UserRepository.RevokeToken(userName);
        }
    }
}
