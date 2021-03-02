using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using RestAPIWithASP_Net5.Business;
using RestAPIWithASP_Net5.Data;
using RestAPIWithASP_Net5.Data.VO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestAPIWithASP_Net5.Controllers
{
    [ApiVersion("1")]
    [Route("api/[controller]/v{version:apiVersion}")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ILoginBusiness LoginBusiness;

        public AuthController(ILoginBusiness loginBusiness)
        {
            LoginBusiness = loginBusiness;
        }

        [HttpPost]
        [Route("signin")]
        public IActionResult Signin([FromBody] UserVO user)
        {
            if (user == null) return BadRequest("Invalid Request");
            var loginConfirm = LoginBusiness.ValidateCredencials(user);
            if (loginConfirm == null) return Unauthorized();
            return Ok(loginConfirm);
        }

        [HttpPost]
        [Route("refresh")]
        public IActionResult Refresh([FromBody] TokenVO tokenVO)
        {
            if (tokenVO == null) return BadRequest("Invalid Request");
            var loginConfirm = LoginBusiness.ValidateCredencials(tokenVO);
            if (loginConfirm == null) return BadRequest("Invalid Request");
            return Ok(loginConfirm);
        }

        [HttpGet]
        [Route("Revoke")]
        [Authorize("Bearer")]
        public IActionResult Revoke()
        {
            var user = User.Identity.Name;
            var result = LoginBusiness.Revoke(user);

            if (result == null) return BadRequest("Invalid Request");
            return NoContent();
        }
    }
}
