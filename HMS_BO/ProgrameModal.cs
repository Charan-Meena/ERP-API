using System;
using System.Collections.Generic;
using System.Text;
//using System.Text.Json;
using Newtonsoft.Json;

namespace HMS_BO
{
    public class ProgrameModal
    {
        public string ProgrameID { get; set; }
        public string ProgrameName { get; set; }
        public string ProgrameDuration { get; set; }
        public string ProgrameLebel { get; set; }
    }
    public class Pagination
    {
        public int TotalRecords { get; set; }
        public int TotalPages { get; set; }
    }

    public class DataObjectWrapper
    {
        public List<ProgrameModal> Programe { get; set; }
        public Pagination Pagination { get; set; }
    }

    public class courseScheme
    {
        public string courseSchemeID { get; set; }
        public string courseSchemeName { get; set; }
        public string examPattern { get; set; }
        public int programeID { get; set; }
        public int isActive { get; set; }
    }

    public class examPaper
    {
        public int courseSchemeID { get; set; }
        public string examPattern { get; set; }
        public string SemYear { get; set; }
        public string SubjectDetails { get; set; }

        public List<SubjectDetail> SubjectDetails1;
        //public dynamic SubjectDetails
        //{
        //    get => _SubjectDetails;
        //    set
        //    {
        //        try
        //        {
        //            _SubjectDetails = new List<SubjectDetail>();
        //            if (!String.IsNullOrEmpty(value))
        //            {
        //                //_SubjectDetails = JsonSerializer.Deserialize<List<SubjectDetail>>(value);
        //                _SubjectDetails = JsonConvert.DeserializeObject<List<SubjectDetail>>(value);
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            //Console.WriteLine(ex);
        //            _SubjectDetails = new List<SubjectDetail>();
        //        }
        //    }
        //}
    }

    public class SubjectDetail
    {
        public string IsCompulsory { get; set; }
        public string SubjSeq { get; set; }
        public string SubjName { get; set; }
        public string SubjectCode { get; set; }
        public string TheoryMax { get; set; }
        public string TheoryMin { get; set; }
        public string PractMax { get; set; }
        public string PractMin { get; set; }
        public string SesMax { get; set; }
        public string SesMin { get; set; }
        public string MaxTotal { get; set; }
       // public string MinTotal { get; set; }
        public string ActiveStatus { get; set; }
    }
}
