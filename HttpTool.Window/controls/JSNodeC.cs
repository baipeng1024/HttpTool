﻿using System;
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
    public partial class JSNodeC : NodeC
    {
        private JSNode jsNode;

        public JSNodeC(JSNode jsNode)
            : base(jsNode)
        {
            InitializeComponent();
            this.jsNode = jsNode;
            Load();
            LockEdit();
        }

        protected override void Load()
        {
            base.Load();
            tacScript.SetText(jsNode.JS);
        }

        protected override void LockEdit()
        {
            base.LockEdit();
            tacScript.Enabled = false;
        }

        protected override void EnableEdit()
        {
            base.EnableEdit();
            tacScript.Enabled = true;
        }

        protected override bool Save()
        {
            if (base.Save()) {
                jsNode.JS = tacScript.GetText();
                return true;
            }
            return false;
        }

    }
}