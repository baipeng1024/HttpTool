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

        public IndependentTreeNodeC(AbsFlowNode node, FlowLayoutPanel parentPnl, Panel contentPnl, ContextMenuStrip ctxMenu)
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
        }
    }
}
