using RestAPIWithASP_Net5.Data;
using RestAPIWithASP_Net5.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestAPIWithASP_Net5.Repository
{
    public interface IUserRepository
    {
        User ValidateCredencials(UserVO user);
        User ValidateCredencials(string userName);

        bool RevokeToken(string userName);
        User RefreshUserInfo(User user);
    }
}
