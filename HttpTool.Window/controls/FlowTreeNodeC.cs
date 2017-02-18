using HttpTool.Core.Model;
using HttpTool.Window.tool;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HttpTool.Window.controls
{
    public class FlowTreeNodeC : AbsTreeNode
    {
        public SingleHttpFlow HttpFlow { get; set; }

        public FlowBreviaryNodeC[] BreviaryNodes { get; set; }

        private FlowBreviaryNodeC currentNode;

        public FlowTreeNodeC(SingleHttpFlow singleHttpFlow, FlowLayoutPanel parentPnl, Panel contentPnl, ContextMenuStrip ctxMenu)
            : base(parentPnl, contentPnl, ctxMenu)
        {
            HttpFlow = singleHttpFlow;
            Text = singleHttpFlow.Name;
            AbsFlowNode node = HttpFlow.HeadNode;
           
            ImageKey = ResourcesHelper.IMG_FLOW_KEY;
            SelectedImageKey = ImageKey;      
            List<FlowBreviaryNodeC> breviaryNodes = new List<FlowBreviaryNodeC>();
            breviaryNodes.Add(new FlowBreviaryNodeC(singleHttpFlow, this));

            while (node != null)
            {
                breviaryNodes.Add(new FlowBreviaryNodeC(node, this));
                node = node.NextNode;
            }

            BreviaryNodes = breviaryNodes.ToArray();
        }

        public override void OnAfterSelect()
        {
            base.OnAfterSelect();
            parentPnl.Controls.Clear();
            parentPnl.Controls.AddRange(BreviaryNodes);

            BreviaryNodes[0].Selected();        

        }

        public override void OnMouseDown(MouseButtons mouseButton)
        {
            base.OnMouseDown(mouseButton);
            if (mouseButton == MouseButtons.Right)
            {
                ContextMenuStrip.Items[0].Visible = true;
                ContextMenuStrip.Items[1].Visible = false;
                ContextMenuStrip.Items[2].Visible = false;
                ContextMenuStrip.Items[3].Visible = false;
                ContextMenuStrip.Items[4].Visible = true;
            }
        }

        public FlowBreviaryNodeC AddNode(AbsFlowNode node, FlowBreviaryNodeC prev)
        {
            FlowBreviaryNodeC[] nodes = new FlowBreviaryNodeC[BreviaryNodes.Length + 1];
            int i = 0;
            FlowBreviaryNodeC newNode = null;
            foreach (FlowBreviaryNodeC item in BreviaryNodes)
            {
                nodes[i++] = item;
                if (prev == item)
                {
                    newNode = new FlowBreviaryNodeC(node, this);
                    parentPnl.Controls.Add(newNode);
                    parentPnl.Controls.SetChildIndex(newNode, i);
                    nodes[i++] = newNode;
                }
            }
            BreviaryNodes = nodes;
            return newNode;
        }

        public void RemoveNode(FlowBreviaryNodeC breviaryNode)
        {
            FlowBreviaryNodeC[] nodes = new FlowBreviaryNodeC[BreviaryNodes.Length - 1];
            int i = 0;
            foreach (FlowBreviaryNodeC item in BreviaryNodes)
            {
                if (breviaryNode == item)
                {
                    nodes[i - 1].Selected();
                }
                else
                {
                    nodes[i++] = item;
                }

            }
            BreviaryNodes = nodes;
            HttpFlow.RemoveNode(breviaryNode.FlowNode);
            parentPnl.Controls.Remove(breviaryNode);
        }


        public void SelectNotice(FlowBreviaryNodeC node)
        {

            if (currentNode != null && currentNode != node)
            {
                currentNode.CancelSelection();
            }

            currentNode = node;
            contentPnl.Controls.Clear();
            contentPnl.Controls.Add(currentNode.ContentNodeC);
        }

        

        public override string GetPath()
        {
            return GetParentPath();
        }
    }
}
