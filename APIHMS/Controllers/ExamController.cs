﻿using Microsoft.AspNetCore.Http;
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
        public ResponseData onLineExaminationGetQuestionList(int examStudentSlots_MarksID = 0, int studentID = 0, int PaperID = 0)
        {
            try
            {
                objres = ObExamBl.onLineExaminationGetQuestionList(examStudentSlots_MarksID, studentID, PaperID);
                return objres;
            }
            catch (Exception ex)
            {
                // throw ex.Message;
            }
            return objres;
        }
        [Route("studentExamSubmitSingle")]
        [HttpPost]
        [Authorize]
        public ResponseData studentExamSubmitSingle([FromForm] studentExamSubmitlist objExamAns )
        {
            if (objExamAns.questionList!=null)
            {
                objExamAns.answerLsitSingle = JsonConvert.DeserializeObject<studentExamSubmit>(objExamAns.questionList);
            }
            
            try
            {
                objres = ObExamBl.studentExamSubmitSingle(objExamAns);
                return objres;
            }
            catch (Exception ex)
            {
                // throw ex.Message;
            }
            return objres;
        }
        [Route("studentExamSubmitFinal")]
        [HttpPost]
        [Authorize]
        public ResponseData studentExamSubmitFinal([FromForm] studentExamSubmitlist objExamAns)
        {
            try
            {
                objres = ObExamBl.studentExamSubmitFinal(objExamAns);
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
        public ResponseData studentExamSubmit([FromForm] studentExamSubmitlist objExamAns)
        {
            objExamAns.answerLsit = JsonConvert.DeserializeObject<List<studentExamSubmit>>(objExamAns.questionList);
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

        [Route("GetPaperListforStudent")]
        [HttpGet]
        [Authorize]
        public ResponseData GetPaperListforStudent(int studentID=0, int semester_year=0)
        {
            try
            {
                objres = ObExamBl.GetPaperListforStudent(studentID, semester_year);
                return objres;
            }
            catch (Exception ex)
            {
                // throw ex.Message;
            }
            return objres;
        }
        [Route("GetPaperListforResult")]
        [HttpGet]
        [Authorize]

        public ResponseData GetPaperListforResult(int programeId = 0, int semester_year = 0)
        {
            try
            {
                objres = ObExamBl.GetPaperListforResult(programeId, semester_year);
                return objres;
            }
            catch (Exception ex)
            {
                // throw ex.Message;
            }
            return objres;
        }
        [Route("GetMarkListByPaper")]
        [HttpGet]
        [Authorize]
        public ResponseData GetMarkListByPaper(int SubjectCourseID = 0)
        {
            try
            {
                objres = ObExamBl.GetMarkListByPaper(SubjectCourseID);
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
