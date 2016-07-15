using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace HttpTool.Core.JS
{
    public class JSLibHelper
    {
        private JSLibHelper() { }

        private static Dictionary<string, string> JS_CACHE = new Dictionary<string, string>();

       // public static void 

        public static string GetJSLibContent(List<string> jsLibs) {
            StringBuilder sb = new StringBuilder("\n");
            foreach (string libName in jsLibs)
            {
               string val;
               if(!JS_CACHE.TryGetValue(libName,out val)){
                   throw new Exception(string.Format("加载脚本:%s 失败",libName));
               }
               sb.Append(val);
               sb.Append("\n");
            }
            return sb.ToString();
        }




    }
}
