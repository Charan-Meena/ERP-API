using System;
using System.Collections.Generic;
using System.Text;

namespace HMS_BO
{
    public class ExamModal
    {

    }
    public class ExamStudentSlots_Marks
	{
    public int examStudentSlots_MarksID { get; set; }
    
	public int subjectCourseID { get; set; }
	public DateTime? examdate { get; set; }
	public string semYear { get; set; }
	public string theoryMax { get; set; }
	public string theoryMin { get; set; }
	public string obtainTheory { get; set; }
	public string practMax { get; set; }
	public string practMin { get; set; }
	public string obtainPractical { get; set; }
	public string sesMax { get; set; }
	public string sesMin { get; set; }
	public string obtainSess { get; set; }
	public string maxTotal { get; set; }
	public string minTotal { get; set; }
	public string obtainMAx { get; set; }
	}
	public class ExamSlotsModal
    {
		public int examScheduleID { get; set; }
		public int studentID { get; set; }
		public int userID { get; set; }
		public string subject { get; set; }
		public string spAction { get; set; }
		public List<ExamStudentSlots_Marks> subjectList { get; set; }

	}

}
