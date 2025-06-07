using HMS_BO;
using HMS_DL;
using System;
using System.Collections.Generic;
using System.Text;
namespace HMS_BL
{
    public class RollBL
    {
        RollDL objAdminDL = new RollDL();
        public ResponseData GetLocation()
        {
            return objAdminDL.GetLocation();
        }
        public ResponseData SaveLocation(Location_Master ObjLm)
        {
            return objAdminDL.SaveLocation(ObjLm);
        }
    }
}
