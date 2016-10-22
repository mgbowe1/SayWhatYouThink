using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentLibrary
{
    public class PythonStyle : Documentation
    {
        protected override string GetCommentPrefix()
        {
            return "#";
        }
    }
}
