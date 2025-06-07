using HMS_BL;
using HMS_BO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using Microsoft.AspNetCore.Authorization;

namespace APIHMS.Controllers
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class RollController : ControllerBase
    {
        RollBL objAdminBL = new RollBL();

        [HttpGet]
        [Route("GetAllRolls")]
        public ResponseData GetAllRolls()
        {
            try
            {
                var objResponseData = objAdminBL.GetLocation();
                return objResponseData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpPost]
        [Route("SaveRolls")]
        public ResponseData SaveLocation(Location_Master ObjLm)
        {
            try
            {
                var objResponseData = objAdminBL.SaveLocation(ObjLm);
                return objResponseData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
