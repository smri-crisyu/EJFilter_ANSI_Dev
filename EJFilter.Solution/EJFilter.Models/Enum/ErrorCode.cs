using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJFilter.Models.Enum
{
    public enum ErrorCode
    {
        ParameterCannotBeEmpty = 1,
        ObjectCannotBeNull = 2,
        AddDataFailed = 3,
        UpdateDataFailed = 4,
        DeleteDataFailed = 5
    }
}
