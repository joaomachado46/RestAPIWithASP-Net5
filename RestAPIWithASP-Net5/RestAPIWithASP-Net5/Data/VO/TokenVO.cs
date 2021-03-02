using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestAPIWithASP_Net5.Data.VO
{
    public class TokenVO
    {
        public bool Authenticater { get; set; }
        public string Create { get; set; }
        public string Expiration { get; set; }
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }

        public TokenVO(bool authenticater, string create, string expiration, string accessToken, string refreshToken)
        {
            Authenticater = authenticater;
            Create = create;
            Expiration = expiration;
            AccessToken = accessToken;
            RefreshToken = refreshToken;
        }
    }
}
