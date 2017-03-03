using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace HttpTool.Window
{
    public class Config
    {
       

        private string jvmPath;
        private string httpPort;
        private string jarsPath;

        private Dictionary<string, SysFun> sysFuns = new Dictionary<string,SysFun>();



        public Config Load(string path) {
            XmlDocument doc = new XmlDocument();
            doc.Load(path);

            Config conf = new Config();

            XmlNode javaNode = doc.SelectSingleNode("java");
            
            return conf;
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


        public SysFun GetSysFun(string fun,int parsCount)
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
            private List<string> pars = new List<string>();
            private string target;
            private string desc;

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
