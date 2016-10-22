using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentLibrary
{
    public class Documentation
    {
        public string GetFormattedComment(string text)
        {
            return GetCommentPrefix() + text;
        }

        protected virtual string GetCommentPrefix()
        {
            return "//";
        }
    }
}
