using HMS_BO;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
//using APIHMS.Services;

namespace HMS_DL
{
    public class userDL
    {
        ResponseData objResponseData = new ResponseData();
        //public ResponseData userLogin(UserModel ObjUm)
        //{
        //    SqlParameter[] param = new SqlParameter[3];

        //    param[0] = new SqlParameter("@loginID", ObjUm.loginID);
        //    param[1] = new SqlParameter("@Password", ObjUm.Password);
        //    param[2] = new SqlParameter("@Action", "UserLogin");

        //    DataSet ds = DBOperation.FillDataSet("Sp_UserAction", param);
        //    if (ds != null && ds.Tables[0].Rows.Count>0)
        //    {
        //        objResponseData.ResponseCode = "000";
        //        objResponseData.Data = ds.Tables[0];
        //        objResponseData.Message = "User Login Successfully";
        //        objResponseData.statusCode = 1;
        //        //objResponseData.JWT = _jwtTokenService.GenerateToken(ObjUm.loginID);
        //    }
        //    else
        //    {
        //        objResponseData.ResponseCode = "001";
        //        objResponseData.Message = "No Data Available...";
        //        objResponseData.statusCode = -1;
        //    }
        //    return objResponseData;
        //}
        public ResponseData userLogin(UserModel ObjUm)
        {
            SqlParameter[] param = new SqlParameter[3];

            param[0] = new SqlParameter("@loginID", ObjUm.loginID);
            param[1] = new SqlParameter("@Password", ObjUm.Password);
            param[2] = new SqlParameter("@Action", "UserLogin11");

            DataSet ds = DBOperation.FillDataSet("Sp_UserAction", param);
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                objResponseData.ResponseCode = "000";
                objResponseData.Data = ds.Tables[0];
                objResponseData.Message = "User Login Successfully";
                objResponseData.statusCode = 1;
                //objResponseData.JWT = _jwtTokenService.GenerateToken(ObjUm.loginID);
            }
            else
            {
                objResponseData.ResponseCode = "001";
                objResponseData.Message = "No Data Available...";
                objResponseData.statusCode = -1;
            }
            return objResponseData;
        }
        public ResponseData UserRegistration(UserModel ObjUm)
        {
            SqlParameter[] param = new SqlParameter[8];

            param[0] = new SqlParameter("@loginID", ObjUm.loginID);
            param[1] = new SqlParameter("@Password", ObjUm.Password);
            param[2] = new SqlParameter("@Action", "UserRegistration");
            param[3] = new SqlParameter("@Fullname", ObjUm.Fullname);
            param[4] = new SqlParameter("@Username", ObjUm.Username);
            param[5] = new SqlParameter("@Email", ObjUm.Email);
            param[6] = new SqlParameter("@PhoneNumber", ObjUm.PhoneNumber);
            param[7] = new SqlParameter("@gender", ObjUm.gender);
            DataSet ds = DBOperation.FillDataSet("Sp_UserAction", param);
            if (ds != null && ds.Tables[0].Rows.Count > 0)
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
        //
        public ResponseData UserList(tableParam objpara)
        {
            SqlParameter[] param = new SqlParameter[4];
            param[0] = new SqlParameter("@Action", "UserList");
            param[1] = new SqlParameter("@PageNumber ", objpara.PageNumber);
            param[2] = new SqlParameter("@RowsOfPage", objpara.RowsOfPage);
            param[3] = new SqlParameter("@SearchText", objpara.searchText);
            DataTable dt = DBOperation.FillDataTable("Sp_UserAction", param);
            if (dt != null )
            {
                objResponseData.ResponseCode = "000";
                objResponseData.Data = dt;
                //objResponseData.Data = ds.Tables[0];
                //objResponseData.Message = ds.Tables[0].Rows[0][1].ToString(); //"User Registration Successfully";
                //objResponseData.statusCode = Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());
            }
            else
            {
                objResponseData.ResponseCode = "001";
                objResponseData.Message = "No Data Available...";
                objResponseData.statusCode = -1;
            }
            return objResponseData;
        }
    }
}
