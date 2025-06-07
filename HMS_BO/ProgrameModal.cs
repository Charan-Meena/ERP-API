using System;
using System.Collections.Generic;
using System.Text;

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

    public class courseScheme {
        public string courseSchemeID { get; set; } 
        public string courseSchemeName { get; set; }
        public int programeID { get; set; }
        public int isActive { get; set; } 
    }
}
