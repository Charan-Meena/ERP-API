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
        ResponseTableData objTableResponce = new ResponseTableData();
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
        [Route("studentList")]
        [HttpPost]
        [Authorize]
        public ResponseTableData studentList([FromForm] tableParam objTblParam)
        {
            try
            {
                objTableResponce = objStuBl.studentList(objTblParam);
                return objTableResponce;
            }
            catch (Exception ex)
            {
                // throw ex.Message;
            }
            return objTableResponce;

        }
        [Route("examScheduleforStudents")]
        [HttpGet]
        [Authorize]
        public ResponseData examScheduleforStudents(int id=0,int studentID=0)
        {
            try
            {
                objres = objStuBl.examScheduleforStudents(id, studentID);
                return objres;
            }
            catch (Exception ex)
            {
                // throw ex.Message;
            }
            return objres;
        }
        [Route("getPaperforExam")]
        [HttpGet]
        [Authorize]
        public ResponseData getPaperforExam(int batch_Id = 0,int semester_year = 0,int studentID=0)
        {
            try
            {
                objres = objStuBl.getPaperforExam(batch_Id, semester_year, studentID);
                return objres;
            }
            catch (Exception ex)
            {
                // throw ex.Message;
            }
            return objres;
        }
        [Route("studentExamSlotCreate")]
        [HttpPost]
        [Authorize]
        public ResponseData studentExamSlotCreate([FromForm] ExamSlotsModal objExamSlots)
        {
            objExamSlots.subjectList = JsonConvert.DeserializeObject<List<ExamStudentSlots_Marks>>(objExamSlots.subject);

            try
            {
                objres = objStuBl.studentExamSlotCreate(objExamSlots);
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
