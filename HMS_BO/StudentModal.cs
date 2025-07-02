using System;
using System.Collections.Generic;
using System.Text;

namespace HMS_BO
{
    public class StudentModal
    {
        public string studentID { get; set; }
        public int userID { get; set; }
        public string fullname { get; set; }
        public string email { get; set; }
        public DateTime dob { get; set; }
        public string phoneNumber { get; set; }
        public string gender { get; set; }
        public string activeStatus { get; set; }
        public int entityType { get; set; }
        public int parentId { get; set; }
        public string userName { get; set; }
        public string passwordhash { get; set; }
        public string userrole { get; set; }
        public string lastLogin { get; set; }

    }
}
