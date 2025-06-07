using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using HMS_BL;
using HMS_BO;
using System;
using APIHMS.Services;
using Microsoft.AspNetCore.Authorization;

namespace APIHMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly JwtTokenService _jwtTokenService;
        CommonServices objCommonservices = new CommonServices();

        public UserController(JwtTokenService jwtTokenService)
        {
            _jwtTokenService = jwtTokenService;
        }
        userBL objUserBl = new userBL();

        [HttpPost]
        [Route("userLogin")]
        public ResponseData userLogin(UserModel ObjUm)
        {
            ObjUm.Password = HMS_DL.Cryptography.Encrypt(ObjUm.Password);
            try
            {
                var objResponseData = objUserBl.userLogin(ObjUm);
                if (objResponseData.statusCode == 1)
                {
                    var token = _jwtTokenService.GenerateToken(ObjUm.loginID);
                    objResponseData.JWT = token;
                    //return Ok(new { token });
                    return objResponseData;
                }
               // return Unauthorized();
                return objResponseData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [Authorize]
        [HttpPost]
        [Route("UserRegistration")]
        public ResponseData UserRegistration([FromForm]UserModel ObjUm)
        {
            ObjUm.Password = HMS_DL.Cryptography.Encrypt(ObjUm.Password);
            try
            {
                var objResponseData = objUserBl.UserRegistration(ObjUm);
                return objResponseData;
            }
            catch (Exception ex)
            {
                var objResponseData= objCommonservices.ApiErroLog(ex.Message);
                return objResponseData;
                throw ex;
            }

        }
        [Authorize]
        [HttpPost]
        [Route("UserList")]
        public ResponseData UserList([FromForm]tableParam objpara)
      {
            try
            {
                var objResponseData = objUserBl.UserList(objpara);
                return objResponseData;
            }
            catch (Exception ex)
            {
                var objResponseData = objCommonservices.ApiErroLog(ex.Message);
                return objResponseData;
                throw ex;
            }

        }
    }
}
