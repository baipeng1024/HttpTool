using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HttpTool.Core.JS;
using HttpTool.Core.Model;
using System.Collections.Generic;

namespace HttpTool.Test
{
    [TestClass]
    public class JSProcessorTest
    {
        static string JS1 = "<script type=\"text/javascript\">" + //
            "alert(1);SYS_CTX.fun4();\r\n" + //
            "SYS_CTX.fun1 = function(){alert(1)};\r\n" +  //
            "alert(2);\r\n" + //
            "SYS_CTX.fun2 = function(var p1,p2){alert(p1 + p2)};\r\n" +  // 带有参数方法
            "alert(3);\r\n" + //
            "SYS_CTX.fun3 = function(a,b){return SYS_CTX.fun2(a,b);};\r\n" + // 嵌套方法
            "SYS_CTX.fun4 = function(a,b){var val = SYS_CTX.fun3(a,b);SYS_CTX.fun1()};\r\n" + // 多层嵌套方法 & 多引用
            "SYS_CTX.fun5 = function(){ alert('fun5');SYS_CTX.fun6 = function(){alert('fun6')};};SYS_CTX.fun5();SYS_CTX.fun6();" + // 嵌套定义
            "</script>";
        [TestMethod]
        public void ProcessTest()
        {
            Dictionary<string, JSFunMeta> funTable = new Dictionary<string, JSFunMeta>();
            string result = JSProcessor.Process(JS1, funTable);
            Console.WriteLine(result);
        }
    }
}
