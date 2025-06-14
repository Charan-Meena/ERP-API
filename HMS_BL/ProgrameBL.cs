using System;
using System.Collections.Generic;
using System.Text;
using HMS_BO;
using HMS_DL;

namespace HMS_BL
{
    public class ProgrameBL
    {
        ResponseData objres = new ResponseData();
        ResponseTableData bojTableResponce =new ResponseTableData();
        ProgrameDL ObjProgrameDl = new ProgrameDL();
        public ResponseData programeMasterRegistration(ProgrameModal objprograme)
        {
            objres= ObjProgrameDl.programeMasterRegistration(objprograme);
            return objres;
        }
        public ResponseTableData programeList(tableParam objTblParam)
        {
            bojTableResponce = ObjProgrameDl.programeList(objTblParam);
            return bojTableResponce;
        }
        public ResponseData getProgrameDDL()
        {
            objres = ObjProgrameDl.getProgrameDDL();
            return objres;
        }
        //
        public ResponseData courseMasterMasterRegistration(courseScheme objCourse)
        {
            objres = ObjProgrameDl.courseMasterMasterRegistration(objCourse);
            return objres;
        }
        public ResponseTableData courseSchemeList(tableParam objTblParam)
        {
            bojTableResponce = ObjProgrameDl.courseSchemeList(objTblParam);
            return bojTableResponce;
        }
        // examPaperAdd([FromForm] examPaper objexamPaper)
        public ResponseTableData examPaperAdd(examPaper objexamPaper)
        {
            bojTableResponce = ObjProgrameDl.examPaperAdd(objexamPaper);
            return bojTableResponce;
        }
    }
}
