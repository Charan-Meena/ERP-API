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
        public ResponseData onLineExaminationGetQuestionList()
        {
            try
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@Action", "GetQuestion");
                param[1] = new SqlParameter("@paperID", 1);

                DataSet ds = DBOperation.FillDataSet("[Sp_ExamPaperQuestionBank]", param);
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
                    SqlParameter[] param = new SqlParameter[07];
                    param[0] = new SqlParameter("@Action", "ExamAnswerSubmit");
                    param[1] = new SqlParameter("@studentID", item.studentID);
                    param[2] = new SqlParameter("@paperID", item.paperID);
                    param[3] = new SqlParameter("@questionId", item.questionId);
                    param[4] = new SqlParameter("@answer", item.answer);
                    param[5] = new SqlParameter("@givenAnswer", item.givenAnswer);
                    param[6] = new SqlParameter("@examSession", item.examSession);                  
                    ds = DBOperation.FillDataSet("[Sp_ExamPaperQuestionBank]", param);
                }
                if (ds != null || ds.Tables[0].Rows.Count > 0)
                {
                    objres.Data = "";
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
    }
}
