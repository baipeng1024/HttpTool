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

        public List<KeyValuePair<string, AbsNode>> IndependentNodes { get; set; }


        public void Load(string filePath)
        {
            HttpFlows = new List<KeyValuePair<string, SingleHttpFlow>>();
            IndependentNodes = new List<KeyValuePair<string, AbsNode>>();
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
                    IndependentNodes.Add(new KeyValuePair<string, AbsNode>("", httpNode));
                }
                else if (tag == "jsnode")
                {
                    JSNode jsNode = ConvertToJSNode(childNode);
                    IndependentNodes.Add(new KeyValuePair<string, AbsNode>("", jsNode));
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

                AbsNode absNode = kv.Value.HeadNode;
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
                    IndependentNodes.Add(new KeyValuePair<string, AbsNode>(path, httpNode));
                }
                else if (tag == "jsnode")
                {
                    JSNode jsNode = ConvertToJSNode(childNode);
                    IndependentNodes.Add(new KeyValuePair<string, AbsNode>(path, jsNode));
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
                if (tag == "jsLibs")
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
                if (childTag == "jsLibs")
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
            XmlAttribute requestTypeAttr = xmlNode.Attributes["requestType"];
            if (requestTypeAttr != null)
            {
                httpNode.RequestType = requestTypeAttr.Value.Trim().ToLower();
            }
            XmlAttribute functionNameOfRequestUrlAttr = xmlNode.Attributes["functionNameOfRequestUrl"];
            if (functionNameOfRequestUrlAttr != null)
            {
                httpNode.FunctionNameOfPostParsStr = functionNameOfRequestUrlAttr.Value.Trim();
            }
            XmlAttribute functionNameOfPostParsStrAttr = xmlNode.Attributes["functionNameOfPostParsStr"];
            if (functionNameOfPostParsStrAttr != null)
            {
                httpNode.FunctionNameOfPostParsStr = functionNameOfPostParsStrAttr.Value.Trim();
            }

            foreach (XmlNode childNode in xmlNode.ChildNodes)
            {
                string childTag = childNode.Name.Trim().ToLower();
                if (childTag == "jsLibs")
                {
                    LoadJsLibs(httpNode, childNode.ChildNodes);
                }
                else if (childTag == "scriptofhandlerequest")
                {
                    httpNode.ScriptOfHandleRequest = childNode.InnerText;
                }
                else if (childTag == "scriptofhandleresponse")
                {
                    httpNode.ScriptOfHandleResponse = childNode.InnerText;
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

            return node;
        }

        private XmlNode ConvertToXmlNode(XmlDocument doc, HttpNode httpNode)
        {
            XmlNode node = doc.CreateNode(XmlNodeType.Element, "httpNode", null);
            AppendXmlAttributes(doc, node, httpNode);

            XmlAttribute requestTypeAttr = doc.CreateAttribute("requestType");
            requestTypeAttr.Value = httpNode.RequestType;
            node.Attributes.Append(requestTypeAttr);
            if (!string.IsNullOrEmpty(httpNode.FunctionNameOfRequestUrl))
            {
                XmlAttribute requestUrlAttr = doc.CreateAttribute("functionNameOfRequestUrl");
                requestUrlAttr.Value = httpNode.FunctionNameOfRequestUrl;
                node.Attributes.Append(requestUrlAttr);
            }
            if (!string.IsNullOrEmpty(httpNode.FunctionNameOfPostParsStr))
            {
                XmlAttribute postParsAttr = doc.CreateAttribute("functionNameOfPostParsStr");
                postParsAttr.Value = httpNode.FunctionNameOfPostParsStr;
                node.Attributes.Append(postParsAttr);
            }

            if (httpNode.includeJSLibs != null && httpNode.includeJSLibs.Count > 0)
            {
                node.AppendChild(ConvertToXmlNode(doc, httpNode.includeJSLibs));
            }

            return node;
        }

        private XmlNode ConvertToXmlNode(XmlDocument doc, List<string> includeJSLibs)
        {
            XmlNode node = doc.CreateNode(XmlNodeType.Element, "jsLibs", null);
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


        private void AppendXmlAttributes(XmlDocument doc, XmlNode xmlNode, AbsNode node)
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
                        includeJSLibs.Add(pathAttr.Value.Trim());
                    }
                }
            }
        }

    }
}
