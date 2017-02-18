using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HttpTool.Core.Model;

namespace HttpTool.Window.controls
{
    public partial class HttpNodeC : NodeC
    {

        private const string DEFATUL_INIT_REQUEST_JS = "//初始化请求对象\r\nvar request = {\r\n" + //
           "    url: \"www.baidu.com\",\r\n" + //
           "    type:\"post\",\r\n" + //
           "    headers:\"host\":\"\"" + //
           "    postPars:\"a=1&b=2\"\r\n" + //
       "};";

        private const string DEFAULT_ON_LAOD_JS = "//页面加载完成后要执行的脚本内容";

        public HttpNodeC()
        {
            InitializeComponent();
        }

        public HttpNodeC(HttpNode node)
            : base(node)
        {
            InitializeComponent();
            Load();
            LockEdit();
        }

        protected override void Load()
        {
            base.Load();
            HttpNode node = (HttpNode)flowNode;
            tacInitRequest.SetText(string.IsNullOrEmpty(node.InitRequestJs) ? DEFATUL_INIT_REQUEST_JS : node.InitRequestJs);
            tacOnLoad.SetText(string.IsNullOrEmpty(node.OnLoadJs) ? DEFAULT_ON_LAOD_JS : node.OnLoadJs);
        }

        protected override void LockEdit()
        {
            base.LockEdit();
            tacInitRequest.Enabled = false;
            tacOnLoad.Enabled = false;
        }

        protected override void EnableEdit()
        {
            base.EnableEdit();
            tacInitRequest.Enabled = true;
            tacOnLoad.Enabled = true;
        }

        protected override bool Save()
        {
            if (base.Save())
            {
                HttpNode node = (HttpNode)flowNode;
                node.InitRequestJs = tacInitRequest.GetText();
                node.OnLoadJs = tacOnLoad.GetText();
                return true;
            }
            return false;
        }


    }
}
