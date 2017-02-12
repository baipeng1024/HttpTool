using HttpTool.Window.tool;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HttpTool.Window.controls
{
    public class DirTreeNodeC : AbsTreeNode
    {


        public DirTreeNodeC(string text, FlowLayoutPanel parentPnl, Panel contentPnl, ContextMenuStrip ctxMenu)
            : base(parentPnl, contentPnl, ctxMenu)
        {
            this.Text = text;
            ImageKey = ResourcesHelper.IMG_FOLDER_CLOSE_KEY;
            SelectedImageKey = ImageKey;
        }

        public override void OnMouseDown(MouseButtons mouseButton)
        {
            base.OnMouseDown(mouseButton);
            if (mouseButton == MouseButtons.Right)
            {
                ContextMenuStrip.Items[0].Visible = true;
                ContextMenuStrip.Items[1].Visible = true;
                ContextMenuStrip.Items[2].Visible = true;
                if (Parent == null)
                {
                    ContextMenuStrip.Items[3].Visible = false;
                }
                else
                {
                    ContextMenuStrip.Items[3].Visible = true;
                }
            }
        }

    }
}
