using System;
using System.Collections.Generic;
using System.Text;
using HMS_BO;
using HMS_DL;

namespace HMS_BL
{
    
    public class userBL
    {
        userDL objUserDL = new userDL();
        //public ResponseData userLogin(UserModel ObjUm)
        //{
        //    return objUserDL.userLogin(ObjUm);
        //}
        public ResponseData userLogin(UserModel ObjUm)
        {
            return objUserDL.userLogin(ObjUm);
        }
        public ResponseData UserRegistration(UserModel ObjUm)
        {
            return objUserDL.UserRegistration(ObjUm);
        }
        //UserList
        public ResponseData UserList(tableParam objpara)
        {
            return objUserDL.UserList(objpara);
        }
    }
    //

}
