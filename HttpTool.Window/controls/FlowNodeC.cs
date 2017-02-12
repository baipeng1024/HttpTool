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
    public partial class FlowNodeC : NodeC
    {
        public FlowNodeC() {
            InitializeComponent();
        }

        public FlowNodeC(AbsFlowNode node)
            : base(node)
        {
            InitializeComponent();
            tacRemark.Enabled = false;
            Load();
            LockEdit();
        }

        protected override void Load()
        {
            base.Load();
            tacRemark.SetText("流程工具");

        }
    }
}
