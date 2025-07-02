using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using HMS_BO;
using HMS_BL;
using System.Collections.Generic;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Authorization;
using System;
using HMS_BO;

namespace APIHMS.Controllers
{
    [Route("api/student/")]
    [ApiController]
    public class StudentController : Controller
    {
        ResponseTableData bojTableResponce = new ResponseTableData();
        ResponseData objres = new ResponseData();
        StudentBL objStuBl = new StudentBL();

        [Route("studentRegistration")]
        [HttpPost]
        [Authorize]
        public ResponseData stdentsRegistration([FromForm] StudentModal ObjStudent)
        {
            ObjStudent.passwordhash = HMS_DL.Cryptography.Encrypt(ObjStudent.passwordhash);
            objres = objStuBl.stdentsRegistration(ObjStudent);
            return objres;
        }
    }
}
