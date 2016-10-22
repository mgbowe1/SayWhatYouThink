using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Documentation
{
    public abstract class Documentation
    {
        protected string Message { get; set; }

        public abstract string getDocumentedString();
    }
}
