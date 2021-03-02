using RestAPIWithASP_Net5.Data;
using RestAPIWithASP_Net5.Data.VO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestAPIWithASP_Net5.Business
{
    public interface ILoginBusiness
    {
        TokenVO ValidateCredencials(UserVO userVO);
        TokenVO ValidateCredencials(TokenVO token);
        bool Revoke(string userName);

    }
}
