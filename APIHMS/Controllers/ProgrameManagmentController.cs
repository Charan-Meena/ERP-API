using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using HMS_BO;
using HMS_BL;
using System.Collections.Generic;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Authorization;
using System;

namespace APIHMS.Controllers
{
    [Route("api/ProgrameManagment/")]
    [ApiController]
    public class ProgrameManagmentController : ControllerBase
    {
        ResponseData objres =new ResponseData();
      //  HttpContext httpContext;
        ProgrameBL ObjProgrameBl = new ProgrameBL();
        ResponseTableData bojTableResponce = new ResponseTableData();


        [Route("programeMasterRegistration")]
        [HttpPost]
        [Authorize]
        // public ResponseData programeMasterRegistration([FromForm] Dictionary<string,string> ObjProg)
        public ResponseData programeMasterRegistration([FromForm] ProgrameModal ObjProg)
        {
           // ProgrameModal abc =new ProgrameModal();
           //var abc1 = JsonConvert.SerializeObject( ObjProg);
            //abc = System.Text.Json.JsonSerializer.Deserialize<ProgrameModal>(abc1);
            objres = ObjProgrameBl.programeMasterRegistration(ObjProg);
            return objres;
        }
        [Route("programeList")]
        [HttpPost]
        [Authorize]
        public ResponseTableData programeList([FromForm]tableParam objTblParam)
        {
            try
            {
                bojTableResponce = ObjProgrameBl.programeList(objTblParam);
                return bojTableResponce;
            }
            catch (Exception ex)
            {
             // throw ex.Message;
            }
            return bojTableResponce;

        }
        [Route("getProgrameDDL")]
        [HttpGet]
        [Authorize]
        public ResponseData getProgrameDDL()
        {
            objres = ObjProgrameBl.getProgrameDDL();
            return objres;
        }
        [Route("courseMStRegistration")]
        [HttpPost]
        [Authorize]
        public ResponseData courseMasterMasterRegistration([FromForm]courseScheme objCourse)
        {
            objres = ObjProgrameBl.courseMasterMasterRegistration(objCourse);
            return objres;
        }
        [Route("courseSchemeList")]
        [HttpPost]
        [Authorize]
        public ResponseTableData courseSchemeList([FromForm] tableParam objTblParam)
        {
            try
            {
                bojTableResponce = ObjProgrameBl.courseSchemeList(objTblParam);
                return bojTableResponce;
            }
            catch (Exception ex)
            {
                // throw ex.Message;
            }
            return bojTableResponce;

        }

        
        [Route("examPaperAdd")]
        [HttpPost]
        [Authorize]

         public ResponseData examPaperAdd([FromForm] examPaper objexamPaper)
        {
            objexamPaper.SubjectDetails1 = JsonConvert.DeserializeObject<List<SubjectDetail>>(objexamPaper.SubjectDetails);

            try
            {
                objres = ObjProgrameBl.examPaperAdd(objexamPaper);
                return objres;
            }
            catch (Exception ex)
            {
                // throw ex.Message;
            }
            return objres;

        }


    }
}
