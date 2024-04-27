using EJFilter.Models.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJFilter.Models.Entity
{
    public class Result : IResult
    {
        public Guid ID
        {
            get;
            private set;
        }

        public bool Success
        {
            get;
            set;
        }

        public string ReturnMessage
        {
            get;
            set;
        }

        public Exception Exception
        {
            get;
            set;
        }

        public List<IResult> InnerResults
        {
            get;
            protected set;
        }

        public int Source { get; set; }
        public int Action { get; set; }
        public string TargetSite { get; set; }
        public string StackTrace { get; set; }
        public string InnerException { get; set; }
        public string Environment { get; set; }
        public int ErrorCode { get; set; }
        public int ResultID { get; set; }

        public int ReturnQueueNum { get; set; }
        public int ReturnQueueIndex { get; set; }
        public string ReturnPrefixCode { get; set; }

        public int ReturnValue { get; set; }

        public Result()
            : this(false)
        {
        }

        public Result(bool success)
        {
            ID = Guid.NewGuid();
            Success = success;
            InnerResults = new List<IResult>();
        }
    }

}
