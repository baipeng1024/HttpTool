using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HttpTool.Core.Model;
using System.Collections.Generic;
using System.Windows.Forms;
using HttpTool.Core.Common;

namespace HttpTool.Test
{
    [TestClass]
    public class SingleHttpFlowTest
    {
        static readonly SingleHttpFlow HTTP_FLOW = new SingleHttpFlow();

        static SingleHttpFlowTest()
        {
            HTTP_FLOW.Name = "SingleHttpFlow 测试";
            List<string> jsLibs = new List<string>();
            jsLibs.Add("jsLib\\jquery-1.12.3.min.js");
            HTTP_FLOW.SetIncludeJsLibs(jsLibs);
           
        }

        [TestMethod]
        public void JSNodeTest()
        {
            string initJS = "SYS_CTX.index = 0;";
            string nodeJs = "SYS_CTX.index++;";
            HTTP_FLOW.HeadNode = CreateJSNode("jsNode1",initJS + nodeJs);
            HTTP_FLOW.HeadNode.NextNode = CreateJSNode("jsNode2",nodeJs);
            HTTP_FLOW.HeadNode.NextNode.NextNode = CreateJSNode("jsNode3", nodeJs);
            FlowContext ctx = HTTP_FLOW.Run(null,null);

            WebBrowser wb = ctx.GetWebBrowser();
            Tool.AppendJavaScriptSnippet(wb.Document,"function getIndex(){return SYS_CTX.index;};");         
            int index = (int)wb.Document.InvokeScript("getIndex");
            Assert.IsTrue(index == 3);
            
        }


        JSNode CreateJSNode(string name,string js) {
            JSNode node = new JSNode(Guid.NewGuid().ToString());
            node.Name = name;
            node.Js = js;
            return node;
        }
    }
}
