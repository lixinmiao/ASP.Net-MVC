using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Contract
{

    public class BusinessException : Exception
    {
        public BusinessException()
            : this(string.Empty)
        {
        }

        public BusinessException(string message) :
            this("error", message)
        {
        }

        public BusinessException(string name, string message)
            : base(message)
        {
            this.Name = name;
        }

        public BusinessException(string message, Enum errorCode)
            : this("error", message, errorCode)
        {
        }

        public BusinessException(string name, string message, Enum errorCode)
            : base(message)
        {
            this.Name = name;
            this.ErrorCode = errorCode;
        }

        public string Name { get; set; }
        public Enum ErrorCode { get; set; }
    }
}
