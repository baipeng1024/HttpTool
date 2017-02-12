using HttpTool.Core.Model;
using HttpTool.Window.tool;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HttpTool.Window.controls
{
    public class IndependentTreeNodeC : AbsTreeNode
    {

        public AbsFlowNode IndependentNode { get; set; }

        public BreviaryNodeC BreviaryNode { get; set; }

        public IndependentTreeNodeC(AbsFlowNode node, FlowLayoutPanel parentPnl, Panel contentPnl, ContextMenuStrip ctxMenu)
            : base(parentPnl, contentPnl, ctxMenu)
        {
            Text = node.Name;
            if (node is HttpNode)
            {
                ImageKey = ResourcesHelper.IMG_HTTP_KEY;
            }
            else if (node is JSNode)
            {
                ImageKey = ResourcesHelper.IMG_JS_KEY;
            }
            SelectedImageKey = ImageKey;

            BreviaryNode = new BreviaryNodeC(node);
        }

        public override void OnAfterSelect()
        {
            base.OnAfterSelect();
            parentPnl.Controls.Clear();
            parentPnl.Controls.Add(BreviaryNode);

            contentPnl.Controls.Clear();
            contentPnl.Controls.Add(BreviaryNode.ContentNodeC);
        }

        public override void OnMouseDown(MouseButtons mouseButton)
        {
            base.OnMouseDown(mouseButton);
            if (mouseButton == MouseButtons.Right)
            {
                ContextMenuStrip.Items[0].Visible = false;
                ContextMenuStrip.Items[1].Visible = false;
                ContextMenuStrip.Items[2].Visible = false;
                ContextMenuStrip.Items[3].Visible = true;
            }
        }
    }
}
