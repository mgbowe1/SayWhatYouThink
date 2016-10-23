using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Documentation
{
    public class Documentation
    {
        public string Message { get; set; }

        public virtual string getDocumentedString()
        {
            return Message;
        }
    }
}
