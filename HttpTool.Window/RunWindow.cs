using HttpTool.Core.Common;
using HttpTool.Core.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace HttpTool.Window
{
    public partial class RunWindow : Form
    {
        private class Log : ILogger
        {
            RichTextBox appender;

            public Log(RichTextBox appender)
            {
                this.appender = appender;

            }

            public void Infor(string log)
            {
                WriteLog(log, "infor");
            }

            public void Error(string log) { WriteLog(log, "error"); }

            public void Error(string log, Exception ex)
            {
                WriteLog(log, "error");
            }

            private void WriteLog(string content, string mark)
            {
                appender.AppendText(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                appender.AppendText("[" + mark + "]:");
                appender.AppendText(content);
                appender.AppendText("\r\n");

            }
        }

        private Log logger;
        private SingleHttpFlow flow;

        public RunWindow(SingleHttpFlow flow)
        {
            InitializeComponent();
            logger = new Log(rtbLogs);
            this.flow = flow;
        }


        public void Run()
        {
            flow.Run(wb, logger);             
        }
    }
}
