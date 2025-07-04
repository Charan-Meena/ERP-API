using HMS_BO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Newtonsoft.Json;

namespace HMS_DL
{
    public class StudentDL
    {
        ResponseData objResponseData = new ResponseData();
        ResponseTableData objTableResponce = new ResponseTableData();
        public ResponseData stdentsRegistration(StudentModal ObjStudent)
        {

            SqlParameter[] param1 = new SqlParameter[7];
            param1[0] = new SqlParameter("@userName", ObjStudent.phoneNumber);
            param1[1] = new SqlParameter("@passwordhash", ObjStudent.passwordhash);
            param1[2] = new SqlParameter("@userrole", ObjStudent.userrole);
            param1[3] = new SqlParameter("@entityType", ObjStudent.entityType);
            param1[4] = new SqlParameter("@parentId", ObjStudent.parentId);
            param1[5] = new SqlParameter("@activeStatus", ObjStudent.activeStatus);
            param1[6] = new SqlParameter("@Action", "InsertLogin");
            var userId = Convert.ToInt32(DBOperation.ExecuteScalarFunction("[Sp_StudentAction]", param1));
            if (userId > 0)
            {
                string ActionString = "";
                if (ObjStudent.studentID == "0" || ObjStudent.studentID == "null" || ObjStudent.studentID == null)
                {
                    ActionString = "InsertStudent";
                    ObjStudent.studentID = null;
                }
                else
                {
                    ActionString = "UpdateStudent";
                }
                SqlParameter[] param = new SqlParameter[10];
                param[0] = new SqlParameter("@Action", ActionString);
                param[1] = new SqlParameter("@userID", userId);
                param[2] = new SqlParameter("@fullname", ObjStudent.fullname);
                param[3] = new SqlParameter("@email", ObjStudent.email);
                param[4] = new SqlParameter("@phoneNumber", ObjStudent.phoneNumber);
                param[5] = new SqlParameter("@dob", ObjStudent.dob);
                param[6] = new SqlParameter("@gender", ObjStudent.gender);
                param[7] = new SqlParameter("@activeStatus", ObjStudent.activeStatus);
                param[8] = new SqlParameter("@entityType", ObjStudent.entityType);
                param[9] = new SqlParameter("@parentId", ObjStudent.parentId);
                DataSet ds = DBOperation.FillDataSet("[Sp_StudentAction]", param);
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
            else
            {
                objResponseData.Message = "User Name Already Exist..";
            }

            return objResponseData;

        }
        public ResponseTableData studentList(tableParam objTblParam)
        {
            try
            {
                SqlParameter[] param = new SqlParameter[4];
                param[0] = new SqlParameter("@Action", "StudentList");
                param[1] = new SqlParameter("@PageNumber ", objTblParam.PageNumber);
                param[2] = new SqlParameter("@RowsOfPage", objTblParam.RowsOfPage);
                param[3] = new SqlParameter("@SearchText", objTblParam.searchText);
                DataSet ds = DBOperation.FillDataSet("[Sp_StudentAction]", param);
                if (ds != null || ds.Tables[0].Rows.Count > 0)
                {
                    objTableResponce.Data = ds.Tables[0];
                    objTableResponce.totalRecords = Convert.ToInt32(ds.Tables[1].Rows[0][0].ToString());
                    objTableResponce.totalPages = Convert.ToInt32(ds.Tables[1].Rows[0][1].ToString());
                }
                else
                {
                    objResponseData.ResponseCode = "001";
                    objResponseData.Message = "No Data Available...";
                    objResponseData.statusCode = -1;
                }
                return objTableResponce;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
