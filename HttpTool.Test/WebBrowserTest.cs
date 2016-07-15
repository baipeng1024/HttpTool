using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Windows.Forms;
using System.Text;
using System.Threading;
namespace HttpTool.Test
{
    [TestClass]
    public class WebBrowserTest
    {
        WebBrowser wb = new WebBrowser();

        [TestMethod]
        public void TestMethod1()
        {            
        
            WebClientEx client = new WebClientEx();
            client.Headers.Set("Host", "pricecallback.jd.local");
            string[] ips = { "10.187.184.157", "10.187.184.157" };
            for (int i = 0; i < ips.Length; i++)
            {
                try
                {
                    string result = client.DownloadString("http://" + ips[i] + ":80/getEndTimePriceList.action?skuids=10185399240");
                    Console.WriteLine(result);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("error:" + ex.Message);
                }
                
            }

            Console.WriteLine("----------------------");
        }

        
    }
}
