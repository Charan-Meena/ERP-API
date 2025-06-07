using HMS_BO;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
namespace HMS_DL
{
    public class AdminDL
    {
        ResponseData objResponseData = new ResponseData();
        //public static IConfiguration _configuration;
        //string connectionString = DBCS.GetConnectionString();

        public ResponseData GetLocation()
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@Action", "GetAllRoll");
            DataSet ds = DBOperation.FillDataSet("[dbo].[Sp_Role]", param);
            if (ds != null && ds.Tables != null)
            {
                objResponseData.ResponseCode = "000";
                objResponseData.Data = ds.Tables[0];
                objResponseData.Message = "Data Fetched Successfully...!";
                objResponseData.statusCode = 1;
            }
            else
            {
                objResponseData.ResponseCode = "001";
                objResponseData.Message = "No Data Available...";
                objResponseData.statusCode = -1;
            }
            return objResponseData;
        }

        public ResponseData SaveLocation(Location_Master ObjLm)
        {
            SqlParameter[] param = new SqlParameter[2];
            //param[0] = new SqlParameter("@Action", "InsertLocationMaster");
            param[0] = new SqlParameter("@LName", ObjLm.LName);
            param[1] = new SqlParameter("@createdby", "Admin1");

            DataSet ds = DBOperation.FillDataSet("[dbo].[Sp_LInsert]", param);
            if (ds != null && ds.Tables != null)
            {
                objResponseData.ResponseCode = "000";
                objResponseData.Data = ds.Tables[0];
                objResponseData.Message = "Data Inserted Successfully...!";
                objResponseData.statusCode = 1;
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
