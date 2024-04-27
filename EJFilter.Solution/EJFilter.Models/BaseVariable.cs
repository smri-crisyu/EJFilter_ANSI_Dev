using EJFilter.Models.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJFilter.Models
{
    public class BaseVariable
    {
        public static string ErrorDescription(int errorCode)
        {
            string errMessage = "";
            switch (errorCode)
            {
                case (int)ErrorCode.ObjectCannotBeNull:
                    errMessage = "Object Cannot Be Null";
                    break;
                default:
                    errMessage = "Exception Error";
                    break;
            }
            return errMessage;
        }
    }
}
