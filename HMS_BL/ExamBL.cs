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
        public ResponseData examPaperQuestionAdd(paperQuestionBank objexamPaperQuestion)
        {
            objres = ObjExamDl.examPaperQuestionAdd(objexamPaperQuestion);
            return objres;
        }
        public ResponseData onLineExaminationGetQuestionList(int examStudentSlots_MarksID = 0, int studentID = 0, int PaperID = 0)
        {
            objres = ObjExamDl.onLineExaminationGetQuestionList(examStudentSlots_MarksID,studentID, PaperID);
            return objres;
        }
        public ResponseData studentExamSubmit(studentExamSubmitlist objExamAns)
        {
            objres = ObjExamDl.studentExamSubmit(objExamAns);
            return objres;
        }
        public ResponseData examScheduleCreate(ExamScheduleModal objExamSchedule)
        {
            objres = ObjExamDl.examScheduleCreate(objExamSchedule);
            return objres;
        }
        public ResponseData examScheduleList()
        {
            objres = ObjExamDl.examScheduleList();
            return objres;
        }
        public ResponseData GetPaperListforStudent(int studentID = 0, int semester_year = 0)
        {
            objres = ObjExamDl.GetPaperListforStudent(studentID, semester_year);
            return objres;
        }
    }
}
