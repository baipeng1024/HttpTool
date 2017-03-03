using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text;

namespace HttpTool.Test
{
    [TestClass]
    public class Test
    {
        [TestMethod]
        public void TestMethod1()
        {

            WebClientEx client = new WebClientEx();
            String response = Encoding.UTF8.GetString(client.UploadData("http://127.0.0.1:20000?a=1",Encoding.UTF8.GetBytes("baipeng=白朋&abc=123")));
            Console.WriteLine(response);
           response =  Encoding.UTF8.GetString(client.UploadData("http://127.0.0.1:20000",null));
           Console.WriteLine(response);
        }
    }
}
