using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HMS_BO
{
    public class ResponseData
    {
        public string ResponseCode { get; set; }
        public int statusCode { get; set; }
        public string Message { get; set; }
        public string UserID { get; set; }
        public int ID { get; set; }
        public object Data { get; set; }
        public string Body { get; set; }
        public string JWT { get; set; }
        public string RegistrationId { get; set; }
        public string Error { get; set; }
    }
    public class ResponseTableData
    {
        public string statusCode { get; set; }
        public int totalRecords { get; set; }   
        public int totalPages { get; set; }
        public object Data { get; set; }
        public string Error { get; set; }
    }
    public class JwtSettings
    {
        public string Key { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public double DurationInMinutes { get; set; }
    }
    public class Dropdown
    {
        public int ID { get; set; }
        public string Text { get; set; }

    }
    public class Location_Master
    {
        [Required]
        public string LName { get; set; }
        public string LID { get; set; }
        public string createdby { get; set; }
    }
    public class Roll_Master
    {
        public int roleId { get; set; }
        public string role { get; set; }

    }
    public class tableParam
    {
        public int PageNumber { get; set; }
        public int RowsOfPage { get; set; }
        public string searchText { get; set; }  
    }
}   
