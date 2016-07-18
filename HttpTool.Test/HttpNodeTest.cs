using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HttpTool.Core.Model;
using System.Collections.Generic;

namespace HttpTool.Test
{
    [TestClass]
    public class HttpNodeTest
    {

        static readonly SingleHttpFlow FLOW = new SingleHttpFlow();

        static HttpNodeTest() {

            FLOW.IncludeJSLib = new List<string>();
            FLOW.IncludeJSLib.Add("jsLib\\jquery-1.12.3.min.js");
          
        }

        [TestMethod]
        public void HttpNodeGetTest()
        {
            HttpNode node1 = new HttpNode();
            node1.RequestType = "get";
            node1.ScriptOfHandleRequest = "function getUrl(){ return 'http://www.cnblogs.com/';};";
            node1.ScriptOfHandleResponse = "alert(123);";
            node1.FunctionNameOfRequestUrl = "getUrl";
            FLOW.HeadNode = node1;
            FLOW.Run(null);
            
        }


    }
}
