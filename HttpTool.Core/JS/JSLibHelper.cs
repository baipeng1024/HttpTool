using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace HttpTool.Core.JS
{
    public class JSLibHelper
    {

        private static Dictionary<string, string> JS_CACHE = new Dictionary<string, string>();

        private static readonly string LIB_PATH = System.IO.Directory.GetCurrentDirectory() + "\\jsLib";

        static JSLibHelper()
        {
            JSLibHelper.Refresh();
        }

        private JSLibHelper() { }

        public static void Refresh()
        {

            if (!Directory.Exists(LIB_PATH))
            {
                return;
            }

            string[] fils = Directory.GetFiles(LIB_PATH, "*.js", SearchOption.AllDirectories);
            string appDir = System.IO.Directory.GetCurrentDirectory() + "\\";
            foreach (string path in fils)
            {
                string relativePath = path.Replace(appDir, "");
                using (StreamReader sr = new StreamReader(relativePath))
                {
                    string jqueryLib = sr.ReadToEnd();
                    if (JS_CACHE.ContainsKey(relativePath))
                    {
                        JS_CACHE[relativePath] = jqueryLib;
                    }
                    else
                    {
                        JS_CACHE.Add(relativePath, jqueryLib);
                    }

                }

            }
        }

        public static string GetJSLibContent(List<string> jsLibs)
        {
            StringBuilder sb = new StringBuilder("\n");
            foreach (string libName in jsLibs)
            {
                string val;
                if (!JS_CACHE.TryGetValue(libName, out val))
                {
                    throw new Exception(string.Format("加载脚本:{0} 失败", libName));
                }
                sb.Append(val);
                sb.Append("\n");
            }
            return sb.ToString();
        }

 


    }
}
