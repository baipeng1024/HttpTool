using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace HttpTool.Core.JS
{
    public class Jquery
    {

        private static string jqueryLib;

        static Jquery()
        {
            Init();
        }


        private Jquery() { }


        public static string GetJqueryLib()
        {
            return jqueryLib;
        }


        private static void Init()
        {
            try
            {
                using (StreamReader sr = new StreamReader("jquery-1.12.3.min.js"))
                {
                    jqueryLib = sr.ReadToEnd();
                }
            }
            catch (Exception e)
            {
                throw new Exception("加载jquery库:jquery-1.12.3.min.js 异常，异常信息:" + e.Message);
            }

        }

    }
}
