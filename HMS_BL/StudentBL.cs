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
        ResponseTableData objTableResponce = new ResponseTableData();
        StudentDL ObjStudentDl = new StudentDL();
        public ResponseData stdentsRegistration( StudentModal ObjStudent)
        {
            objres = ObjStudentDl.stdentsRegistration(ObjStudent);
            return objres;
        }
        public ResponseTableData studentList(tableParam objTblParam)
        {
            objTableResponce= ObjStudentDl.studentList(objTblParam);
            return objTableResponce;
        }
        public ResponseData examScheduleforStudents(int id = 0, int studentID = 0)
        {
            objres = ObjStudentDl.examScheduleforStudents(id, studentID);
            return objres;
        }
        public ResponseData getPaperforExam(int batch_Id = 0, int semester_year = 0,int studentID=0)
        {
            objres = ObjStudentDl.getPaperforExam(batch_Id, semester_year, studentID);
            return objres;
        }
        public ResponseData studentExamSlotCreate(ExamSlotsModal objExamSlots)
        {
            objres = ObjStudentDl.studentExamSlotCreate(objExamSlots);
            return objres;

        }
    }


}
