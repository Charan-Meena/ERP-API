using System;
using System.Collections.Generic;
using System.Text;
using HMS_BO;
using System.Data.SqlClient;
using System.Data;
using Newtonsoft.Json;
namespace HMS_DL
{
    public class ProgrameDL
    {
        ResponseData objResponseData = new ResponseData();
        ResponseTableData bojTableResponce = new ResponseTableData();
        public ResponseData programeMasterRegistration(ProgrameModal objprograme)
        {
            SqlParameter[] param = new SqlParameter[5];
             string ActionString="";
            if (objprograme.ProgrameID == "0" || objprograme.ProgrameID == "null" || objprograme.ProgrameID==null) { ActionString = "InsertProgrameMaster";
                objprograme.ProgrameID = null;}
            else {
                ActionString = "UpdateProgrameMaster";
            }
            param[0] = new SqlParameter("@Action", ActionString);
            param[1] = new SqlParameter("@ProgrameName", objprograme.ProgrameName);
            param[2] = new SqlParameter("@ProgrameDuration",objprograme.ProgrameDuration);
            param[3] = new SqlParameter("@ProgrameLebel", objprograme.ProgrameLebel);
            param[4] = new SqlParameter("@ProgrameID",objprograme.ProgrameID);
            DataSet ds = DBOperation.FillDataSet("Sp_ProgrameManagment", param);
            if (ds != null || ds.Tables[0].Rows.Count > 0)
            {
                objResponseData.ResponseCode = "000";
                objResponseData.Data = ds.Tables[0];
                objResponseData.Message = ds.Tables[0].Rows[0][1].ToString(); //"User Registration Successfully";
                objResponseData.statusCode = Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());
            }
            else
            {
                objResponseData.ResponseCode = "001";
                objResponseData.Message = "No Data Available...";
                objResponseData.statusCode = -1;
            }
            return objResponseData;
        }

        public ResponseTableData programeList(tableParam objTblParam)
        {
            try
            {
                SqlParameter[] param = new SqlParameter[4];
                param[0] = new SqlParameter("@Action", "GetProgrameList");
                param[1] = new SqlParameter("@PageNumber ", objTblParam.PageNumber);
                param[2] = new SqlParameter("@RowsOfPage", objTblParam.RowsOfPage);
                param[3] = new SqlParameter("@SearchText", objTblParam.searchText);
                // DataTable dt = DBOperation.FillDataTable("Sp_ProgrameManagment", param);
                DataSet ds = DBOperation.FillDataSet("Sp_ProgrameManagment", param);
                if (ds != null || ds.Tables[0].Rows.Count > 0)
                {
                    // var jsonString = ds.Tables[0].Rows[0]["dataObject"].ToString();
                    // Deserialize first-level JSON string
                    // var result = JsonConvert.DeserializeObject<dynamic>(jsonString);
                    // bojTableResponce.statusCode = "000";
                    // bojTableResponce.Data = result;

                    //  bojTableResponce.Data = JsonSerializer.Deserialize<JsonTextWriter>(ds.Tables[0].ToString());
                    // bojTableResponce.Data = System.Text.Json.JsonSerializer.Deserialize<dynamic>((ds.Tables[0].ToString()));
                    //bojTableResponce.totalRecords = Convert.ToInt32(ds.Tables[1].Rows[0][0].ToString());
                    //bojTableResponce.totalPages = Convert.ToInt32(ds.Tables[1].Rows[0][1].ToString());
                    bojTableResponce.Data = ds.Tables[0];
                    bojTableResponce.totalRecords = Convert.ToInt32(ds.Tables[1].Rows[0][0].ToString());
                    bojTableResponce.totalPages = Convert.ToInt32(ds.Tables[1].Rows[0][1].ToString());
                }
                else
                {
                    objResponseData.ResponseCode = "001";
                    objResponseData.Message = "No Data Available...";
                    objResponseData.statusCode = -1;
                }
                return bojTableResponce;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ResponseData getProgrameDDL()
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@Action", "GetProgrameDDL");
            DataTable dt = DBOperation.FillDataTable("Sp_ProgrameManagment", param);
            //DataSet ds = DBOperation.FillDataSet("Sp_ProgrameManagment", param);
            if (dt != null)
            {
                objResponseData.Data= dt;
                //objResponseData.Data= ds.Tables[0];
                objResponseData.Message = "Record Fetch Successfully....";
            }
            else
            {
                objResponseData.Message = "No Record Found....";
            }
            return objResponseData;
        }
        public ResponseData courseMasterMasterRegistration(courseScheme objCourse)
        {
            SqlParameter[] param = new SqlParameter[6];
            string ActionString = "";
            if (objCourse.courseSchemeID == "0" || objCourse.courseSchemeID == "null" || objCourse.courseSchemeID == null)
            {
                ActionString = "CourseSchemeRegistration";
                objCourse.courseSchemeID = null;
            }
            else
            {
                ActionString = "UpdateCourseSchemeRegistration";
            }
            param[0] = new SqlParameter("@Action", ActionString);
            param[1] = new SqlParameter("@courseSchemeID", objCourse.courseSchemeID);
            param[2] = new SqlParameter("@courseSchemeName", objCourse.courseSchemeName);
            param[3] = new SqlParameter("@isActive", objCourse.isActive);
            param[4] = new SqlParameter("@ProgrameID", objCourse.programeID);
            param[5] = new SqlParameter("@examPattern", objCourse.examPattern);

            DataSet ds = DBOperation.FillDataSet("Sp_CourseScheme", param);
            if (ds != null || ds.Tables[0].Rows.Count > 0)
            {
                objResponseData.ResponseCode = "000";
                objResponseData.Data = ds.Tables[0];
                objResponseData.Message = ds.Tables[0].Rows[0][1].ToString(); //"User Registration Successfully";
                objResponseData.statusCode = Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());
            }
            else
            {
                objResponseData.ResponseCode = "001";
                objResponseData.Message = "No Data Available...";
                objResponseData.statusCode = -1;
            }
            return objResponseData;
        }

        public ResponseTableData courseSchemeList(tableParam objTblParam)
        {
            try
            {
                SqlParameter[] param = new SqlParameter[4];
                param[0] = new SqlParameter("@Action", "CourseSchemeList");
                param[1] = new SqlParameter("@PageNumber ", objTblParam.PageNumber);
                param[2] = new SqlParameter("@RowsOfPage", objTblParam.RowsOfPage);
                param[3] = new SqlParameter("@SearchText", objTblParam.searchText);
                DataSet ds = DBOperation.FillDataSet("[Sp_CourseScheme]", param);
                if (ds != null || ds.Tables[0].Rows.Count > 0)
                {
                    bojTableResponce.Data = ds.Tables[0];
                    bojTableResponce.totalRecords = Convert.ToInt32(ds.Tables[1].Rows[0][0].ToString());
                    bojTableResponce.totalPages = Convert.ToInt32(ds.Tables[1].Rows[0][1].ToString());
                }
                else
                {
                    objResponseData.ResponseCode = "001";
                    objResponseData.Message = "No Data Available...";
                    objResponseData.statusCode = -1;
                }
                return bojTableResponce;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // 
        public ResponseData examPaperAdd(examPaper objexamPaper)
        {
            DataSet ds = new DataSet();
            try
            {

            foreach (SubjectDetail item in objexamPaper.SubjectDetails1)
            {
                SqlParameter[] param = new SqlParameter[16];
                param[0] = new SqlParameter("@Action", "InsertPaper");
                param[1] = new SqlParameter("@courseSchemeID", objexamPaper.courseSchemeID);
                param[2] = new SqlParameter("@IsCompulsory", item.IsCompulsory);
                param[3] = new SqlParameter("@SubjSeq", item.SubjSeq);
                param[4] = new SqlParameter("@SubjName", item.SubjName);
                param[5] = new SqlParameter("@SubjectCode", item.SubjectCode);
                param[6] = new SqlParameter("@TheoryMax", item.TheoryMax);
                param[7] = new SqlParameter("@TheoryMin", item.TheoryMin);
                param[8] = new SqlParameter("@PractMax", item.PractMax);
                param[9] = new SqlParameter("@SesMax", item.SesMax);
                param[10] = new SqlParameter("@SesMin", item.SesMin);
                param[11] = new SqlParameter("@PractMin", item.PractMin);
                param[12] = new SqlParameter("@MaxTotal", item.MaxTotal);
                param[13] = new SqlParameter("@ActiveStatus", item.ActiveStatus);
                param[14] = new SqlParameter("@examPattern", objexamPaper.examPattern);
                param[15] = new SqlParameter("@SemYear", objexamPaper.SemYear);
                ds = DBOperation.FillDataSet("Sp_ExamPaper", param);
            }

            if (ds != null || ds.Tables[0].Rows.Count > 0)
                {
                    objResponseData.Data = ds.Tables[0].Rows[0][0];
                    objResponseData.Message = ds.Tables[0].Rows[0][1].ToString();
                    objResponseData.statusCode = Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());
                }
                else
                {
                    objResponseData.ResponseCode = "001";
                    objResponseData.Message = "No Data Available...";
                    objResponseData.statusCode = -1;
                }
                return objResponseData;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public ResponseTableData coursePaperList(tableParam objTblParam)
        {
            try
            {
                SqlParameter[] param = new SqlParameter[4];
                param[0] = new SqlParameter("@Action", "paperList");
                param[1] = new SqlParameter("@PageNumber ", objTblParam.PageNumber);
                param[2] = new SqlParameter("@RowsOfPage", objTblParam.RowsOfPage);
                param[3] = new SqlParameter("@SearchText", objTblParam.searchText);
                DataSet ds = DBOperation.FillDataSet("[Sp_ExamPaper]", param);
                if (ds != null || ds.Tables[0].Rows.Count > 0)
                {
                    bojTableResponce.Data = ds.Tables[0];
                    bojTableResponce.totalRecords = Convert.ToInt32(ds.Tables[1].Rows[0][0].ToString());
                    bojTableResponce.totalPages = Convert.ToInt32(ds.Tables[1].Rows[0][1].ToString());
                }
                else
                {
                    objResponseData.ResponseCode = "001";
                    objResponseData.Message = "No Data Available...";
                    objResponseData.statusCode = -1;
                }
                return bojTableResponce;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
