using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Documentation
{
    public abstract class Documentation
    {
        public string Message { get; set; }

        public abstract string getDocumentedString();
    }
}
