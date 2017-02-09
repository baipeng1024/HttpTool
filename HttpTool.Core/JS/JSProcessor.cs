using HttpTool.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
namespace HttpTool.Core.JS
{
    public class JSProcessor
    {
        public static string Process(string js, Dictionary<string, JSMethodMeta> methodTable)
        {
            string regStr = "(?<funName>" + FlowContext.CTX_NAME + "\\.[\\w\\$_][\\w\\$_\\d]*)(?#匹配方法的变量名称)\\s*=\\s*(?<funBody>function\\s*\\((?<pars>(\\s*(?:var\\s+)?[\\w\\$_][\\w\\$_\\d]*\\s*,?)*)\\s*\\)(?#匹配参数串)\\s*{[^\\{\\}]*(((?<left>{)[^\\{\\}]*)*((?<-left>})[^\\{\\}]*)*)*(?<left>(?!)|})(?#递归匹配大括号的内容))";
            Regex reg = new Regex(regStr, RegexOptions.IgnoreCase | RegexOptions.Singleline);
            foreach (Match match in reg.Matches(js))
            {
                JSMethodMeta methodMeta = new JSMethodMeta();
                methodMeta.MethodName = match.Groups["funName"].Value;
                methodMeta.MethodBody = match.Groups["funBody"].Value;

                string pars = match.Groups["pars"].Value.Trim();
                if (!string.IsNullOrEmpty(pars))
                {
                    char[] spliter = { ',' };
                    methodMeta.ParCount = pars.Split(spliter).Length;
                }

                string key = methodMeta.MethodName + "@" + methodMeta.ParCount;
                if (methodTable.ContainsKey(key))
                {
                    methodTable.Remove(key);
                }
                methodTable.Add(key, methodMeta);
            }

            return js;
        }
    }
}
