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
        private HttpNode node;

        public HttpNodeC(HttpNode node)
            : base(node)
        {
            this.node = node;
            InitializeComponent();
            Load();
            LockEdit();
        }

        protected override void Load()
        {
            base.Load();
            if (node.RequestType.ToLower() == "post")
            {
                cbxRequestType.SelectedItem = "post";
            }
            else {
                cbxRequestType.SelectedItem = "get";
            }

            tcRequestUrl.SetText(node.FunctionNameOfRequestUrl);
            tcPostPars.SetText(node.FunctionNameOfPostParsStr);
        }

        protected override void LockEdit()
        {
            base.LockEdit();
            cbxRequestType.Enabled = false;
            tcPostPars.Enabled = false;
            tcRequestUrl.Enabled = false;
            tacScript.Enabled = false;
        }

        protected override void EnableEdit()
        {
            base.EnableEdit();
            cbxRequestType.Enabled = true;
            tcPostPars.Enabled = true;
            tcRequestUrl.Enabled = true;
            tacScript.Enabled = true;
        }

        protected override bool Save()
        {
            if (base.Save())
            {
                node.RequestType = (string)cbxRequestType.SelectedItem;
                node.FunctionNameOfRequestUrl = tcRequestUrl.GetText();
                node.FunctionNameOfPostParsStr = tcPostPars.GetText();
                node.Js = tacScript.GetText();
                return true;
            }
            return false;
        }


    }
}
