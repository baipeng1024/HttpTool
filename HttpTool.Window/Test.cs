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
using HttpTool.Core.Model;
using System.Threading;

namespace HttpTool.Window
{
    public partial class Test : Form
    {
        public Test()
        {
            InitializeComponent();
          
        }

       
        static Test()
        {

            List<string> jsLibs = new List<string>();
            jsLibs.Add("jsLib\\jquery-1.12.3.min.js");
            FLOW.SetIncludeJsLibs(jsLibs);
            
        }

        static readonly SingleHttpFlow FLOW = new SingleHttpFlow();
        WebBrowser wb = new WebBrowser();

        private void button1_Click(object sender, EventArgs e)
        {
            
            //wb.DocumentCompleted += wb_DocumentCompleted;
             
            //wb.Navigate(tbxUrl.Text.Trim());
            //for (int i = 0; i < 100000; i++)
            //{
            //    Console.WriteLine(i);
            //}
           
        }

        

        void wb_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            MessageBox.Show("ok");
            wb.DocumentCompleted -= wb_DocumentCompleted;
             
        }
    }
}
