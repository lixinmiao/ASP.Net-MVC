using Framework.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Contract
{
    public class Request : ModelBase
    {
        public Request()
        {
            PageSize = 5000;
        }

        public int Top
        {
            set
            {
                this.PageSize = value;
                this.PageIndex = 1;
            }
        }

        public int PageSize { get; set; }
        public int PageIndex { get; set; }
    }
}
