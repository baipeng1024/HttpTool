using HttpTool.Window.tool;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HttpTool.Window.controls
{
    public class DirTreeNodeC : TreeNode
    {
        public DirTreeNodeC(string text) {
            this.Text = text;
            this.ImageIndex = Convert.ToInt32(EIcons.folder_open);
        }

    }
}
