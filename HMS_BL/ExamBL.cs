using System;
using System.Collections.Generic;
using System.Text;
using HMS_BO;
using HMS_DL;

namespace HMS_BL
{
    public class ExamBL
    {
        ResponseData objres = new ResponseData();
        ExamDL ObjExamDl = new ExamDL();
        public ResponseData onLineExaminationGetQuestionList()
        {
            objres = ObjExamDl.onLineExaminationGetQuestionList();
            return objres;
        }
        public ResponseData studentExamSubmit(studentExamSubmitlist objExamAns)
        {
            objres = ObjExamDl.studentExamSubmit(objExamAns);
            return objres;
        }
    }
}
