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

        static HttpNodeTest()
        {

            List<string> jsLibs = new List<string>();
            jsLibs.Add("jsLib\\jquery-1.12.3.min.js");
            FLOW.SetIncludeJsLibs(jsLibs);
        }

        [TestMethod]
        public void HttpNodeGetTest()
        { 

        }


    }
}
