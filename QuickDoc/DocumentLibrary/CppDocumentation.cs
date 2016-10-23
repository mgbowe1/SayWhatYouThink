﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Documentation
{
    public class CppDocumentation : Documentation
    {
        private static string COMMENT_PREFIX = "// ";

        public override string getDocumentedString()
        {
            return COMMENT_PREFIX + base.Message + "\n";
        }
    }
}
