using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HttpTool.Core.Model
{
    public class JSFunMeta
    {
        public string FunName { get; set; }

        public string FunBody { get; set; }

        public int ParCount { get; set; }

        public string GetFunSignature()
        {
            return GetFunSignature(FunName, ParCount);
        }

        public static string GetFunSignature(string funName, int parCount)
        {
            return funName + "@" + parCount;
        }

    }
}
