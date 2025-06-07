using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace HMS_BO
{
    public class UserModel
    {
       public string loginID { get; set; }
       public string Password { get; set; }
       public string Fullname { get; set; }
       public string Username { get; set; }
       public string Email { get; set; }
       public string PhoneNumber { get; set; }
       public string gender { get; set; }
    }
}
