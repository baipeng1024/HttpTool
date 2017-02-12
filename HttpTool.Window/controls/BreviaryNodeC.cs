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
    public partial class BreviaryNodeC : UserControl
    {

        public AbsFlowNode FlowNode { get; set; }

        public NodeC ContentNodeC { get; set; }

        public BreviaryNodeC() {
            InitializeComponent();
        }

        public BreviaryNodeC(AbsFlowNode node)
        {
            InitializeComponent();
            this.FlowNode = node;

            if (FlowNode is SingleHttpFlow)
            {
                this.pbxIcon.Image = Resource.flow;
                ContentNodeC = new FlowNodeC((SingleHttpFlow)FlowNode);
            }
            else if (FlowNode is JSNode)
            {
                this.pbxIcon.Image = Resource.js;
                ContentNodeC = new JSNodeC((JSNode)FlowNode);
            }
            else if (FlowNode is HttpNode)
            {
                this.pbxIcon.Image = Resource.http;
                ContentNodeC = new HttpNodeC((HttpNode)FlowNode);
            }
        }  


    }
}
