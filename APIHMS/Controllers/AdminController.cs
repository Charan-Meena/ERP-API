using Microsoft.AspNetCore.Mvc;
using System;
using HMS_BO;
using HMS_BL;
using Microsoft.AspNetCore.Http;
namespace APIHMS.Controllers
{

    [Route("[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        //ResponseData objResponseData1 = new ResponseData();

        AdminBL objAdminBL = new AdminBL();

        [HttpGet]
        [Route("GetLocation")]
        public ResponseData GetLocation()
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
        [Route("SaveLocation")]
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
