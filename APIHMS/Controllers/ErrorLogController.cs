using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using HMS_BL;
using HMS_BO;

namespace APIHMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ErrorLogController : ControllerBase
    {
        userBL objUserBl = new userBL();
        public ResponseData ErrorLogResponce( string ex)
        {
            //objresonce= objUserBl.
            return new ResponseData();
        }
    }
}
