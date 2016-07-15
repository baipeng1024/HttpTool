using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using HttpTool.Core.JS;
using System.IO;

namespace HttpTool.Window
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            wb.DocumentCompleted += wb_DocumentCompleted;
        }



        WebBrowser wb = new WebBrowser();

        private void button1_Click(object sender, EventArgs e)
        {


            rtbConsole.Text = "";
            string[] ips1 = { "172.16.109.111" };
            string[] ips2 = { "10.187.184.157" };
            string[] ips3 = { "10.187.51.209" };
            string[] ips4 = { "10.190.5.126" };
            TempTest(ips1, "pricecallback.jd.local");
            TempTest(ips2, "pricecallback.jd.local");
            TempTest(ips3, "pricecallback.jd.local");
            TempTest(ips4, "pricecallbacklf.jd.local");
            return;
            //WebClientEx client = new WebClientEx();
            //client.Headers.Set("Host", "pricecallback.jd.local");

            //string result = client.DownloadString("http://172.16.109.111:80/getEndTimePriceList.action?skuids=J_752719");
            //MessageBox.Show(result);

            //return;
            //WebClientEx client = new WebClientEx();
            //string url = tbxUrl.Text.Trim();
            //string content = client.DownloadString(url);
            //Regex regex = new Regex("<\\s*script(.(?!>))*?src\\s*=\\s*\"\\s*(?!http)(?<url>(.(?!>))*?)\"(.(?!>))*?.?>",RegexOptions.IgnoreCase | RegexOptions.Singleline);
            //MatchCollection mc = regex.Matches(content);
            //StringBuilder sb = new StringBuilder(content);
            //if (mc.Count > 0)
            //{
            //    string domain = GetDomain(url);
            //    foreach (Match m in mc)
            //    {
            //       Group g = m.Groups["url"];
            //       string val = g.Value.Trim();
            //       if (val.IndexOf("/") == 0)
            //       {
            //           if (val.IndexOf("//") == 0)
            //           {

            //           }
            //           else
            //           {
            //               val = domain + val;
            //               sb.Insert(g.Index,domain);
            //           }
            //       }
            //       else {
            //           if (url[url.Length - 1] == '/')
            //           {
            //               sb.Insert(g.Index, url);
            //           }
            //           else {
            //               sb.Insert(g.Index, url + "/");
            //           }

            //       }

            //    }
            //}

            //sb.Append(Jquery.GetJqueryLib());
            //sb.Append("<script type=\"text/javascript\">");
            //sb.Append(rtbMyJs);
            //sb.Append("</script>");
            try
            {

                wb.Navigate(tbxUrl.Text.Trim(), "", null, "Host: www.jd.com\r\n");
                //WebClientEx client = new WebClientEx();
                //string s = client.DownloadString(tbxUrl.Text).Trim();
                //wb.Url = new Uri(tbxUrl.Text.Trim());
                //wb.DocumentText = s;
            }
            catch (Exception ex)
            {

                throw;
            }



        }

        void test()
        {

            // wb.ur
        }

        void wb_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            HtmlDocument doc = wb.Document;
            MessageBox.Show(wb.DocumentText);
            HtmlElement head = doc.GetElementsByTagName("head")[0];
            HtmlElement j = doc.CreateElement("script");
            j.SetAttribute("text", Jquery.GetJqueryLib());
            head.AppendChild(j);
            HtmlElement s = doc.CreateElement("script");
            s.SetAttribute("text", rtbMyJs.Text);
            head.AppendChild(s);
            object o = wb.Document.InvokeScript("test");
            if (o != null)
            {
                rtbConsole.AppendText("\n" + o);
                // wb.Document.InvokeScript("testObj",new object[1]{o});

            }
        }

        private string GetDomain(string url)
        {
            int index = url.IndexOf("/");
            if (index > 0)
            {
                url = url.Substring(0, index);
            }
            return url;
        }


        public void TempTest(string[] ips, string host)
        {

            // string[] ips = {};
            for (int i = 0; i < ips.Length; i++)
            {

                WebClientEx client = new WebClientEx();
                try
                {
                    client.Headers.Set("Host", host);
                    string result = client.DownloadString("http://" + ips[i] + ":80/" + tbxUrl.Text.Trim());
                    rtbConsole.Text += result;
                }
                catch (Exception ex)
                {
                    rtbConsole.Text += "error:" + ex.Message;
                }
                finally
                {
                    client.Dispose();
                }

            }

            Console.WriteLine("----------------------");
        }


    }
}
