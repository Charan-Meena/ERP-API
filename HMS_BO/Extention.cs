using System;
using System.Collections.Generic;
using System.Text;

namespace HMS_BO
{
    public static class Extention
    {
        public static string NulllToString(this object value)
        {
            try
            {
                if (value != null && !string.IsNullOrWhiteSpace(Convert.ToString(value)))
                {
                    return Convert.ToString(value);
                }
                else
                {
                    return string.Empty;
                }
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }
    }
}
