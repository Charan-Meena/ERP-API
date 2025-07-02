using HMS_BO;
using System;
using System.Collections.Generic;
using System.Text;
using HMS_DL;

namespace HMS_BL
{
    public class StudentBL
    {
        ResponseData objres = new ResponseData();
        ResponseTableData bojTableResponce = new ResponseTableData();
        StudentDL ObjStudentDl = new StudentDL();
        public ResponseData stdentsRegistration( StudentModal ObjStudent)
        {
            objres = ObjStudentDl.stdentsRegistration(ObjStudent);
            return objres;
        }
    }


}
