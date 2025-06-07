using System;
using APIHMS.Controllers;
using HMS_BL;
using HMS_BO;

namespace APIHMS.Services
{
    public class CommonServices
    {
        ResponseData objResponseData = new ResponseData();
        public ResponseData ApiErroLog(string ex )
        {
            objResponseData.Message = ex;
            //objResponseData.Error = ex;
            //ErrorLogController obj =new ErrorLogController();
            //var responcedata= obj.ErrorLogResponce(ex);
            //return responcedata; 
            return objResponseData;
        }
    }
}
