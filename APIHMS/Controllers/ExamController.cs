using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using HMS_BO;
using HMS_BL;
using Microsoft.AspNetCore.Authorization;
using System;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace APIHMS.Controllers
{
    [Route("api/Examination")]
    [ApiController]
    public class ExamController : ControllerBase
    {
        ResponseData objres = new ResponseData();
        ExamBL ObExamBl = new ExamBL();
        [Route("examQuestionRegistration")]
        [HttpPost]
        [Authorize]
        public ResponseData examPaperQuestionAdd([FromForm] paperQuestionBank objexamPaperQuestion)
        {
            try
            {
                objres = ObExamBl.examPaperQuestionAdd(objexamPaperQuestion);
                return objres;
            }
            catch (Exception ex)
            {
                // throw ex.Message;
            }
            return objres;

        }

        [Route("getQuestionforExam")]
        [HttpGet]
        [Authorize]
        public ResponseData onLineExaminationGetQuestionList()
        {
            try
            {
                objres = ObExamBl.onLineExaminationGetQuestionList();
                return objres;
            }
            catch (Exception ex)
            {
                // throw ex.Message;
            }
            return objres;
        }
        [Route("studentExamSubmit")]
        [HttpPost]
        [Authorize]
        public ResponseData studentExamSubmit([FromForm] studentExamSubmitlist objExamAns )
        {
            objExamAns.answerLsit=JsonConvert.DeserializeObject<List<studentExamSubmit>>(objExamAns.questionList);
            try
            {
                objres = ObExamBl.studentExamSubmit(objExamAns);
                return objres;
            }
            catch (Exception ex)
            {
                // throw ex.Message;
            }
            return objres;
        }
        [Route("examScheduleCreate")]
        [HttpPost]
        [Authorize]
        public ResponseData examScheduleCreate([FromForm] ExamScheduleModal objExamSchedule)
        {
            try
            {
                objres = ObExamBl.examScheduleCreate(objExamSchedule);
                return objres;
            }
            catch (Exception ex)
            {
                // throw ex.Message;
            }
            return objres;
        }
        [Route("examScheduleList")]
        [HttpGet]
        [Authorize]
        public ResponseData examScheduleList()
        {
            try
            {
                objres = ObExamBl.examScheduleList();
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
