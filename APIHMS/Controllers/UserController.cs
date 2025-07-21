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
        userBL objUserBl = new userBL();
        private readonly JwtTokenService _jwtTokenService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        CommonServices objCommonservices = new CommonServices();

        public UserController(JwtTokenService jwtTokenService, IHttpContextAccessor httpContextAccessor)
        {
            _jwtTokenService = jwtTokenService;
            _httpContextAccessor = httpContextAccessor;
        }
        string headerKey = "Key";
        

        //public string GetHeaderValue()
        //{
        //    // Check if the header exists
        //    if (Request.Headers.TryGetValue("Key", out var headerValue))
        //    {
        //        //return Ok(new { HeaderValue = headerValue.ToString() });
        //        return headerValue.ToString();
        //    }
        //    else
        //    {
        //        return "Header not found.";
        //    }
        //}


        //[HttpPost]
        //[Route("userLogin")]
        //public ResponseData userLogin(UserModel ObjUm)
        //{
        //    ObjUm.Password = HMS_DL.Cryptography.Encrypt(ObjUm.Password);
        //    try
        //    {
        //        var objResponseData = objUserBl.userLogin(ObjUm);
        //        if (objResponseData.statusCode == 1)
        //        {
        //            var token = _jwtTokenService.GenerateToken(ObjUm.loginID);
        //            objResponseData.JWT = token;
        //            //return Ok(new { token });
        //            return objResponseData;
        //        }
        //       // return Unauthorized();
        //        return objResponseData;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        [HttpPost]
        [Route("userLogin")]
        public ResponseData userLogin(UserModel ObjUm)
        {
            //var keyMerchat = GetHeaderValue();
            var kevalue = commonFunction.GetHeaderValue(_httpContextAccessor, headerKey);

            ObjUm.Password = HMS_DL.Cryptography.Encrypt(ObjUm.Password, kevalue);
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
            //var keyMerchat = GetHeaderValue();
            var keyMerchat = commonFunction.GetHeaderValue(_httpContextAccessor, headerKey);
            ObjUm.Password = HMS_DL.Cryptography.Encrypt(ObjUm.Password, keyMerchat);
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
