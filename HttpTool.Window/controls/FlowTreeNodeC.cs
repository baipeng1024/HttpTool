using HttpTool.Core.Model;
using HttpTool.Window.tool;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HttpTool.Window.controls
{
    public class FlowTreeNodeC : TreeNode
    {
        public SingleHttpFlow SingleHttpFlow { get; set; }

        public BreviaryNodeC[] BreviaryNodes { get; set; }

        private BreviaryNodeC currentNode;

        private Panel panel;

        public FlowTreeNodeC(SingleHttpFlow singleHttpFlow, Panel panel)
        {
            SingleHttpFlow = singleHttpFlow;
            Text = singleHttpFlow.Name;
            AbsNode node = SingleHttpFlow.HeadNode;
            this.panel = panel;
            List<BreviaryNodeC> breviaryNodes = new List<BreviaryNodeC>();

            while (node != null)
            {
                breviaryNodes.Add(new BreviaryNodeC(node, this));
                node = node.NextNode;
            }

            BreviaryNodes = breviaryNodes.ToArray();
        }


        public void SelectNotice(BreviaryNodeC node)
        {
            if (currentNode != null && currentNode != node)
            {
                currentNode.CancelSelection();               
            }
            currentNode = node;
            NodeC nodeC = null;

            if (node.Node is JSNode)
            {
                nodeC = new JSNodeC((JSNode)node.Node);
            }
            else if (node.Node is HttpNode)
            {
                nodeC = new HttpNodeC((HttpNode)node.Node);
            }

            panel.Controls.Clear();
            panel.Controls.Add(nodeC);
        }
    }
}
