using HttpTool.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HttpTool.Window.controls
{
    public class FlowTreeNodeC : TreeNode
    {
        private SingleHttpFlow singleHttpFlow;

        public FlowTreeNodeC(SingleHttpFlow singleHttpFlow) {
            this.singleHttpFlow = singleHttpFlow;
            if (singleHttpFlow.Name == null)
            {
                this.Text = "null";
            }
            else {
                this.Text = singleHttpFlow.Name;
            }
        }
    }
}
