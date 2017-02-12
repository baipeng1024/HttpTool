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

        public static string Process(string js, Dictionary<string, JSFunMeta> funTable)
        {

            List<JSFunMeta> funMetas = MatchFunMetas(js);
            foreach (JSFunMeta funMeta in funMetas)
            {
                string key = funMeta.GetFunSignature();
                if (funTable.ContainsKey(key))
                {
                    funTable.Remove(key);
                }
                funTable.Add(key, funMeta);
            }

            while (funMetas.Count > 0)
            {
                for (int i = funMetas.Count - 1; i > -1; i--)
                {
                    JSFunMeta funMeta = funMetas[i];
                    string funBody = funMeta.FunBody;
                    if (Inline(ref funBody, funTable) == 0) { funMetas.RemoveAt(i); continue; }
                    funMeta.FunBody = funBody;
                }

            }

            string newJs = js;
            Inline(ref newJs, funTable);
            return newJs;
        }

        private static List<JSFunMeta> MatchFunMetas(string js)
        {
            string regStr = "(?<funName>" + FlowContext.CTX_NAME + "\\.[\\w\\$_][\\w\\$_\\d]*)(?#匹配方法的变量名称)\\s*=\\s*function\\s*\\((?<pars>(\\s*(?:var\\s+)?[\\w\\$_][\\w\\$_\\d]*\\s*,?)*)\\s*\\)(?#匹配参数串)\\s*(?<funBody>{[^\\{\\}]*(((?<left>{)[^\\{\\}]*)*((?<-left>})[^\\{\\}]*)*)*(?<left>(?!)|})(?#递归匹配大括号的内容))";
            List<JSFunMeta> funMetas = new List<JSFunMeta>();
            foreach (Match match in Regex.Matches(js, regStr, RegexOptions.IgnoreCase | RegexOptions.Singleline))
            {
                JSFunMeta funMeta = new JSFunMeta();
                funMeta.FunName = match.Groups["funName"].Value;
                funMeta.FunBody = match.Groups["funBody"].Value;
                funMeta.ParCount = GetParsCount(match.Groups["pars"].Value.Trim());
                funMetas.Add(funMeta);
            }

            return funMetas;
        }


        private static int Inline(ref string js, Dictionary<string, JSFunMeta> funTable)
        {
            string regStr = "(?<funName>" + FlowContext.CTX_NAME + "\\.[\\w\\$_][\\w\\$_\\d]*)(?#匹配方法的变量名称)\\s*\\((?<pars>(\\s*[\\w\\$_][\\w\\$_\\d]*\\s*,?)*)\\s*\\)(?#匹配参数串)";
            MatchCollection matchs = Regex.Matches(js, regStr, RegexOptions.IgnoreCase | RegexOptions.Singleline);
            int replaceCount = 0;

            foreach (Match match in matchs)
            {
                string funName = match.Groups["funName"].Value;
                string pars = match.Groups["pars"].Value.Trim();
                JSFunMeta reference;
                if (funTable.TryGetValue(JSFunMeta.GetFunSignature(funName, GetParsCount(pars)), out reference))
                {
                    js = js.Replace(match.Value, string.Format("function({0}){1}()\r\n", pars, reference.FunBody));
                    replaceCount++;
                }
            }
            return replaceCount;
        }

        private static int GetParsCount(string parsStr)
        {
            if (!string.IsNullOrEmpty(parsStr))
            {
                char[] spliter = { ',' };
                return parsStr.Split(spliter).Length;
            }
            return 0;

        }


    }
}
