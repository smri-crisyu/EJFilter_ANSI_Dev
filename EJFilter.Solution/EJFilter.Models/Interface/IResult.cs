using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJFilter.Models.Interface
{
    public interface IResult
    {
        Guid ID { get; }

        bool Success { get; set; }

        string ReturnMessage { get; set; }

        int ErrorCode { get; set; }

        Exception Exception { get; set; }

        List<IResult> InnerResults { get; }

        int Source { get; set; }
        int Action { get; set; }
        string TargetSite { get; set; }
        string StackTrace { get; set; }
        string InnerException { get; set; }
        string Environment { get; set; }
        int ReturnQueueNum { get; set; }
        int ReturnQueueIndex { get; set; }
        string ReturnPrefixCode { get; set; }

        int ResultID { get; set; }

        int ReturnValue { get; set; }
    }

}
