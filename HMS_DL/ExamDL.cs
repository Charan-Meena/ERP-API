using System;
using System.Collections.Generic;
using System.Text;
using HMS_BO;
using System.Data.SqlClient;
using System.Data;

namespace HMS_DL
{
    public class ExamDL
    {
        ResponseData objres = new ResponseData();

        public ResponseData examPaperQuestionAdd(paperQuestionBank objexamPaperQuestion)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlParameter[] param = new SqlParameter[8];
                param[0] = new SqlParameter("@Action", "InsertQuestion");
                param[1] = new SqlParameter("@paperID", objexamPaperQuestion.paperID);
                param[2] = new SqlParameter("@question", objexamPaperQuestion.question);
                param[3] = new SqlParameter("@optionA", objexamPaperQuestion.optionA);
                param[4] = new SqlParameter("@optionB", objexamPaperQuestion.optionB);
                param[5] = new SqlParameter("@optionC", objexamPaperQuestion.optionC);
                param[6] = new SqlParameter("@optionD", objexamPaperQuestion.optionD);
                param[7] = new SqlParameter("@answer", objexamPaperQuestion.answer);
                ds = DBOperation.FillDataSet("Sp_ExamPaperQuestionBank", param);
                if (ds != null || ds.Tables[0].Rows.Count > 0)
                {
                    objres.Data = ds.Tables[0].Rows[0][0];
                    objres.Message = ds.Tables[0].Rows[0][1].ToString();
                    objres.statusCode = Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());
                }
                else
                {
                    objres.ResponseCode = "001";
                    objres.Message = "No Data Available...";
                    objres.statusCode = -1;
                }
                return objres;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public ResponseData onLineExaminationGetQuestionList(int examStudentSlots_MarksID = 0, int studentID = 0,int PaperID=0)
        {
            try
            {
                SqlParameter[] param = new SqlParameter[4];
                param[0] = new SqlParameter("@Action", "GetQuestionForExam");
                param[1] = new SqlParameter("@paperID", PaperID);
                param[2] = new SqlParameter("@studentID", studentID);
                param[3] = new SqlParameter("@examStudentSlots_MarksID", examStudentSlots_MarksID);
                DataSet ds = DBOperation.FillDataSet("[Sp_OnlineExam]", param);
                if (ds != null || ds.Tables[0].Rows.Count > 0)
                {
                    objres.Data = ds.Tables[0];
                    objres.Message = "Question Get Successfully for Examination..";
                }
                else
                {
                    objres.ResponseCode = "001";
                    objres.Message = "No Data Available...";
                    objres.statusCode = -1;
                }
                return objres;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public ResponseData studentExamSubmit(studentExamSubmitlist objExamAns)
        {
            DataSet ds = new DataSet();
            try
            {
                foreach (studentExamSubmit item in objExamAns.answerLsit)
                {
                    SqlParameter[] param = new SqlParameter[08];
                    param[0] = new SqlParameter("@Action", "ExamAnswerSubmit");
                    param[1] = new SqlParameter("@studentID", objExamAns.studentID);
                    param[2] = new SqlParameter("@paperID", item.paperID);
                    param[3] = new SqlParameter("@questionId", item.questionId);
                    param[4] = new SqlParameter("@answer", item.answer);
                    param[5] = new SqlParameter("@givenAnswer", item.givenAnswer);
                    param[6] = new SqlParameter("@examSession", item.examSession);                  
                    param[7] = new SqlParameter("@examStudentSlots_MarksID", objExamAns.examStudentSlots_MarksID);                                 
                    ds = DBOperation.FillDataSet("[Sp_OnlineExam]", param);
                }
                if (ds != null || ds.Tables[0].Rows.Count > 0)
                {
                    objres.Data = ds.Tables[0];
                    objres.Message = "Answer Submited Successfully.....";
                    objres.statusCode = 1;
                }
                else{
                    objres.ResponseCode = "001";
                    objres.Message = "No Data Available...";
                    objres.statusCode = -1;
                }
                return objres;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public ResponseData examScheduleCreate(ExamScheduleModal objExamSchedule)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlParameter[] param = new SqlParameter[07];
                param[0] = new SqlParameter("@Action", "createExameSchedule");
                param[1] = new SqlParameter("@batch_Id", objExamSchedule.batch_Id);
                param[2] = new SqlParameter("@programeId", objExamSchedule.programeId);
                param[3] = new SqlParameter("@semester_year", objExamSchedule.semester_year);
                param[4] = new SqlParameter("@examSession", objExamSchedule.examSession);
                param[5] = new SqlParameter("@openDate", objExamSchedule.openDate);
                param[6] = new SqlParameter("@closeDate", objExamSchedule.closeDate);
                ds = DBOperation.FillDataSet("[Sp_Exam_Schedule]", param);
            
                if (ds != null || ds.Tables[0].Rows.Count > 0)
                {
                    objres.Data = "";
                    objres.Message = "Exam Create Successfully.....";
                    objres.statusCode = 1;
                }
                else
                {
                    objres.ResponseCode = "001";
                    objres.Message = "No Data Available...";
                    objres.statusCode = -1;
                }
                return objres;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public ResponseData examScheduleList()
        {
            DataSet ds = new DataSet();
            try
            {
                SqlParameter[] param = new SqlParameter[01];
                param[0] = new SqlParameter("@Action", "ExameScheduleList");
                ds = DBOperation.FillDataSet("[Sp_Exam_Schedule]", param);
                if (ds != null || ds.Tables[0].Rows.Count > 0)
                {
                    objres.Data = ds.Tables[0];
                    objres.Message = "Data get Successfully.....";
                    objres.statusCode = 1;
                }
                else
                {
                    objres.ResponseCode = "001";
                    objres.Message = "No Data Available...";
                    objres.statusCode = -1;
                }
            }
            catch(Exception e)
            {
                throw e;
            }
            return objres;
        }
        public ResponseData GetPaperListforStudent(int studentID = 0, int semester_year = 0)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlParameter[] param = new SqlParameter[03];
                param[0] = new SqlParameter("@Action", "GetPaperListforStudent");
                param[1] = new SqlParameter("@studentID", studentID);
                param[2] = new SqlParameter("@semester_year", semester_year);
                ds = DBOperation.FillDataSet("[Sp_OnlineExam]", param);
                if (ds != null || ds.Tables[0].Rows.Count > 0)
                {
                    objres.Data = ds.Tables[0];
                    objres.Message = "Data get Successfully.....";
                    objres.statusCode = 1;
                }
                else
                {
                    objres.ResponseCode = "001";
                    objres.Message = "No Data Available...";
                    objres.statusCode = -1;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return objres;
        }
    }
}
