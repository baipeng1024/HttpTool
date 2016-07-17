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

namespace HttpTool.Window
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }
     

        static FlowContext flowCtx = new FlowContext();

        private void button1_Click(object sender, EventArgs e)
        {
            List<string> includeJSLib = new List<string>();
            includeJSLib.Add("jsLib\\jquery-1.12.3.min.js");
            flowCtx.Init(new WebBrowser(), includeJSLib);
            JSNode jsNode = new JSNode();
            jsNode.JS = rtbMyJs.Text;
            flowCtx.GetWebBrowser().Url = new Uri(tbxUrl.Text.Trim());
            jsNode.Exec(flowCtx);

        }   

       

    }
}
