using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
namespace HttpTool.Core.Model
{
    public class Flows
    {
        public const string PATH_SPLIT = "/";

        public List<KeyValuePair<string, SingleHttpFlow>> HttpFlows { get; set; }

        public List<KeyValuePair<string, AbsFlowNode>> IndependentNodes { get; set; }


        public void Load(string filePath)
        {
            HttpFlows = new List<KeyValuePair<string, SingleHttpFlow>>();
            IndependentNodes = new List<KeyValuePair<string, AbsFlowNode>>();
            XmlDocument doc = new XmlDocument();

            try
            {
                doc.Load(filePath);
            }
            catch (Exception e)
            {
                throw new Exception("加载流程文件失败：" + e.Message);
            }

            foreach (XmlNode childNode in doc.SelectSingleNode("flows").ChildNodes)
            {
                string tag = childNode.Name.ToLower();
                if (tag == "directory")
                {
                    LoadDirectoryNode("", childNode);
                }
                else if (tag == "singlehttpflow")
                {
                    LoadSingleHttpFlowNode("", childNode);
                }
                else if (tag == "httpnode")
                {
                    HttpNode httpNode = ConvertToHttpNode(childNode);
                    IndependentNodes.Add(new KeyValuePair<string, AbsFlowNode>("", httpNode));
                }
                else if (tag == "jsnode")
                {
                    JSNode jsNode = ConvertToJSNode(childNode);
                    IndependentNodes.Add(new KeyValuePair<string, AbsFlowNode>("", jsNode));
                }
            }
        }

        public void Save(string filePath)
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml("<?xml version=\"1.0\" encoding=\"utf-8\"?>\r\n<flows></flows>");
            XmlNode root = doc.SelectSingleNode("flows");

            string[] split = { PATH_SPLIT };
            foreach (KeyValuePair<string, SingleHttpFlow> kv in HttpFlows)
            {
                string[] path = kv.Key.Split(split, StringSplitOptions.RemoveEmptyEntries);
                string selectPath = path[0];
                XmlNode dirNode = root;

                foreach (string str in path)
                {
                    XmlNode tempNode = doc.SelectSingleNode(selectPath);
                    if (tempNode == null)
                    {
                        XmlNode newNode = doc.CreateNode(XmlNodeType.Element, "directory", null);
                        XmlAttribute attr = doc.CreateAttribute("name");
                        attr.Value = selectPath;
                        newNode.Attributes.Append(attr);
                        dirNode = dirNode.AppendChild(newNode);
                    }
                    else
                    {
                        dirNode = tempNode;
                    }
                    selectPath = selectPath + "/" + str;
                }

                XmlNode flowNode = doc.CreateNode(XmlNodeType.Element, "singleHttpFlow", null);
                dirNode.AppendChild(flowNode);

                XmlAttribute idAttr = doc.CreateAttribute("id");
                idAttr.Value = kv.Value.GetId();
                XmlAttribute nameAttr = doc.CreateAttribute("name");
                nameAttr.Value = kv.Value.Name;
                XmlAttribute descAttr = doc.CreateAttribute("desc");
                descAttr.Value = kv.Value.Desc;
                flowNode.Attributes.Append(idAttr);
                flowNode.Attributes.Append(nameAttr);
                flowNode.Attributes.Append(descAttr);

                if (kv.Value.includeJSLibs != null && kv.Value.includeJSLibs.Count > 0)
                {
                    flowNode.AppendChild(ConvertToXmlNode(doc, kv.Value.includeJSLibs));
                }

                XmlNode nodesNode = doc.CreateNode(XmlNodeType.Element, "nodes", null);
                flowNode.AppendChild(nodesNode);

                AbsFlowNode absNode = kv.Value.HeadNode;
                while (absNode != null)
                {
                    if (absNode is JSNode)
                    {
                        nodesNode.AppendChild(ConvertToXmlNode(doc, (JSNode)absNode));
                    }
                    else if (absNode is HttpNode)
                    {
                        nodesNode.AppendChild(ConvertToXmlNode(doc, (HttpNode)absNode));
                    }
                    absNode = absNode.NextNode;
                }
            }


            try
            {
                doc.Save(filePath);
            }
            catch (Exception ex)
            {
                throw new Exception("保存文件失败:" + ex.Message);
            }

        }

        private void LoadDirectoryNode(string parentPath, XmlNode xmlNode)
        {
            XmlAttribute nameAttr = xmlNode.Attributes["name"];
            if (nameAttr == null || nameAttr.Value.Trim().Length == 0)
            {
                throw new Exception("directory节点没有name属性");
            }
            string path = parentPath + PATH_SPLIT + nameAttr.Value.Trim();
            foreach (XmlNode childNode in xmlNode.ChildNodes)
            {
                string tag = childNode.Name.ToLower();
                if (tag == "directory")
                {
                    LoadDirectoryNode(path, childNode);
                }
                else if (tag == "singlehttpflow")
                {
                    LoadSingleHttpFlowNode(path, childNode);
                }
                else if (tag == "httpnode")
                {
                    HttpNode httpNode = ConvertToHttpNode(childNode);
                    IndependentNodes.Add(new KeyValuePair<string, AbsFlowNode>(path, httpNode));
                }
                else if (tag == "jsnode")
                {
                    JSNode jsNode = ConvertToJSNode(childNode);
                    IndependentNodes.Add(new KeyValuePair<string, AbsFlowNode>(path, jsNode));
                }
            }
        }

        private void LoadSingleHttpFlowNode(string path, XmlNode xmlNode)
        {

            XmlAttribute idAttr = xmlNode.Attributes["id"];
            if (idAttr == null || idAttr.Value.Trim().Length == 0)
            {
                throw new Exception("singleHttpFlow节点没有id属性");
            }
            SingleHttpFlow singleHttpFlow = new SingleHttpFlow(idAttr.Value.Trim());

            XmlAttribute nameAttr = xmlNode.Attributes["name"];
            if (nameAttr != null)
            {
                singleHttpFlow.Name = nameAttr.Value.Trim();
            }

            XmlAttribute descAttr = xmlNode.Attributes["desc"];
            if (descAttr != null)
            {
                singleHttpFlow.Desc = descAttr.Value;
            }


            HttpFlows.Add(new KeyValuePair<string, SingleHttpFlow>(path, singleHttpFlow));
            foreach (XmlNode childNode in xmlNode.ChildNodes)
            {
                string tag = childNode.Name.ToLower();
                if (tag == "jslibs")
                {
                    LoadJsLibs(singleHttpFlow, childNode.ChildNodes);
                }
                else if (tag == "nodes")
                {
                    foreach (XmlNode grandsonNode in childNode.ChildNodes)
                    {
                        string grandsonNodeTag = grandsonNode.Name.ToLower();
                        if (grandsonNodeTag == "httpnode")
                        {
                            singleHttpFlow.AppendNode(ConvertToHttpNode(grandsonNode));
                        }
                        else if (grandsonNodeTag == "jsnode")
                        {
                            singleHttpFlow.AppendNode(ConvertToJSNode(grandsonNode));

                        }
                        else
                        {
                            throw new Exception("无效节点:" + tag);
                        }

                    }
                }

            }

        }




        private JSNode ConvertToJSNode(XmlNode xmlNode)
        {
            XmlAttribute idAttr = xmlNode.Attributes["id"];
            if (idAttr == null || idAttr.Value.Trim().Length == 0)
            {
                throw new Exception("JSNode节点id属性不能为空");
            }

            JSNode jsNode = new JSNode(idAttr.Value);
            XmlAttribute nameAttr = xmlNode.Attributes["name"];
            if (nameAttr != null)
            {
                jsNode.Name = nameAttr.Value.Trim();
            }

            XmlAttribute descAttr = xmlNode.Attributes["desc"];
            if (descAttr != null)
            {
                jsNode.Desc = descAttr.Value;
            }

            foreach (XmlNode childNode in xmlNode.ChildNodes)
            {
                string childTag = childNode.Name.Trim().ToLower();
                if (childTag == "jslibs")
                {
                    LoadJsLibs(jsNode, childNode.ChildNodes);
                }
            }
            return jsNode;
        }

        private HttpNode ConvertToHttpNode(XmlNode xmlNode)
        {
            XmlAttribute idAttr = xmlNode.Attributes["id"];
            if (idAttr == null || idAttr.Value.Trim().Length == 0)
            {
                throw new Exception("HttpNode节点id属性不能为空");
            }
            HttpNode httpNode = new HttpNode(idAttr.Value);
            XmlAttribute nameAttr = xmlNode.Attributes["name"];
            if (nameAttr != null)
            {
                httpNode.Name = nameAttr.Value.Trim();
            }
            XmlAttribute descAttr = xmlNode.Attributes["desc"];
            if (descAttr != null)
            {
                httpNode.Desc = descAttr.Value;
            }

            foreach (XmlNode childNode in xmlNode.ChildNodes)
            {
                string childTag = childNode.Name.Trim().ToLower();
                if (childTag == "jslibs")
                {
                    LoadJsLibs(httpNode, childNode.ChildNodes);
                }
                else if (childTag == "initrequestjs")
                {
                    httpNode.InitRequestJs = childNode.InnerText;
                }
                else if (childTag == "onloadjs")
                {
                    httpNode.OnLoadJs = childNode.InnerText;
                }
            }

            return httpNode;

        }


        private XmlNode ConvertToXmlNode(XmlDocument doc, JSNode jsNode)
        {
            XmlNode node = doc.CreateNode(XmlNodeType.Element, "jsNode", null);
            AppendXmlAttributes(doc, node, jsNode);

            if (jsNode.includeJSLibs != null && jsNode.includeJSLibs.Count > 0)
            {
                node.AppendChild(ConvertToXmlNode(doc, jsNode.includeJSLibs));
            }

            XmlNode js = doc.CreateNode(XmlNodeType.Element, "js", null);
            js.InnerText = jsNode.Js;
            node.AppendChild(js);
            return node;
        }

        private XmlNode ConvertToXmlNode(XmlDocument doc, HttpNode httpNode)
        {
            XmlNode node = doc.CreateNode(XmlNodeType.Element, "httpNode", null);
            AppendXmlAttributes(doc, node, httpNode);


            if (httpNode.includeJSLibs != null && httpNode.includeJSLibs.Count > 0)
            {
                node.AppendChild(ConvertToXmlNode(doc, httpNode.includeJSLibs));
            }

            XmlNode initRequestJs = doc.CreateNode(XmlNodeType.Element, "initRequestJs", null);
            initRequestJs.InnerText = httpNode.InitRequestJs;
            XmlNode onLoadJs = doc.CreateNode(XmlNodeType.Element, "onLoadJs", null);
            onLoadJs.InnerText = httpNode.OnLoadJs;
            node.AppendChild(initRequestJs);
            node.AppendChild(onLoadJs);
            return node;
        }

        private XmlNode ConvertToXmlNode(XmlDocument doc, List<string> includeJSLibs)
        {
            XmlNode node = doc.CreateNode(XmlNodeType.Element, "jslibs", null);
            foreach (string str in includeJSLibs)
            {
                XmlNode includeNode = doc.CreateNode(XmlNodeType.Element, "include", null);
                XmlAttribute attr = doc.CreateAttribute("path");
                attr.Value = str;
                includeNode.Attributes.Append(attr);
                node.AppendChild(includeNode);
            }
            return node;
        }


        private void AppendXmlAttributes(XmlDocument doc, XmlNode xmlNode, AbsFlowNode node)
        {
            XmlAttribute idAttr = doc.CreateAttribute("id");
            idAttr.Value = node.GetId();
            XmlAttribute nameAttr = doc.CreateAttribute("name");
            nameAttr.Value = node.Name;
            XmlAttribute descAttr = doc.CreateAttribute("desc");
            descAttr.Value = node.Desc;
            xmlNode.Attributes.Append(idAttr);
            xmlNode.Attributes.Append(nameAttr);
            xmlNode.Attributes.Append(descAttr);
        }

        private void LoadJsLibs(IIncludeJsLibs node, XmlNodeList includeNodes)
        {
            List<string> includeJSLibs = new List<string>();
            node.SetIncludeJsLibs(includeJSLibs);
            foreach (XmlNode include in includeNodes)
            {
                if (include.Name.Trim().ToLower() == "include")
                {
                    XmlAttribute pathAttr = include.Attributes["path"];
                    if (pathAttr != null)
                    {
                        string path = pathAttr.Value.Trim();
                        if (!string.IsNullOrEmpty(path))
                        {
                            includeJSLibs.Add(path);
                        }
                    }
                }
            }
        }

    }
}
