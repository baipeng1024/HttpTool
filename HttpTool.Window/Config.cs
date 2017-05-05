using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace HttpTool.Window
{
    public class Config
    {

        string jvmPath;
        private string httpPort;
        private string jarsPath;

        private Dictionary<string, SysFun> sysFuns;

        public Config()
        {
        }

        public void Load(string path)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(path);
             
            XmlNode javaNode = doc.SelectSingleNode("config/java");
            if (javaNode == null) {
                throw new Exception("配置文件没有配置java节点");
            }

            object jvmAttr = javaNode.Attributes["jvmPath"];
            if (jvmAttr == null || (this.jvmPath = javaNode.Attributes["jvmPath"].Value.Trim()) == string.Empty)
            {
                throw new Exception("配置文件没有配置java虚拟机的路径");
            }

            object httpPortAttr = javaNode.Attributes["httpPort"];
            if (httpPortAttr == null || (this.httpPort = javaNode.Attributes["httpPort"].Value.Trim()) == string.Empty)
            {
                throw new Exception("配置文件没有配置http的端口号");
            }

            object jarsPathAttr = javaNode.Attributes["jarsPath"];
            string jarsPath = string.Empty;
            if (jarsPathAttr != null)
            {
                jarsPath = javaNode.Attributes["jarsPath"].Value.Trim();
            }

            Dictionary<string, SysFun> sysFuns = new Dictionary<string, SysFun>();
            foreach (XmlNode childNode in doc.SelectNodes("config/sysFuns/method"))
            {
                object nameAttr = childNode.Attributes["name"];
                object descAttr = childNode.Attributes["desc"];
                object targetAttr = childNode.Attributes["target"];
                object parsAttr = childNode.Attributes["pars"];

                if (nameAttr == null || targetAttr == null)
                {
                    continue;
                }

                List<string> pars = new List<string>();
                char[] split = { ',' };
                if (parsAttr != null)
                {
                    foreach (string item in parsAttr.ToString().Split(split))
                    {
                        pars.Add(item);
                    }
                }
                sysFuns.Add(GetSysFunKey(nameAttr.ToString(), pars.Count), new SysFun(nameAttr.ToString(), pars, targetAttr.ToString().Trim(), descAttr == null ? "" : descAttr.ToString()));
            }

            this.jarsPath = jarsPath;
            this.sysFuns = sysFuns;
        }

        public string GetJvmPath()
        {
            return jvmPath;
        }


        public string GetHttpPort()
        {
            return httpPort;
        }

        public string GetJarsPath()
        {
            return jarsPath;
        }


        public SysFun GetSysFun(string fun, int parsCount)
        {
            SysFun v;
            sysFuns.TryGetValue(GetSysFunKey(fun, parsCount), out v);
            return v;
        }


        private string GetSysFunKey(string fun, int parsCount)
        {
            return fun + "@" + parsCount;
        }

        public class SysFun
        {
            private string name;
            private List<string> pars;
            private string target;
            private string desc;

            public SysFun(string name, List<string> pars, string target, string desc)
            {
                this.name = name;
                this.pars = pars;
                this.target = target;
                this.desc = desc;
            }

            public string GetName()
            {
                return name;
            }

            public string GetPars()
            {
                return name;
            }

            public string GetTarget()
            {
                return name;
            }

            public string GetDesc()
            {
                return name;
            }
        }

    }


}
