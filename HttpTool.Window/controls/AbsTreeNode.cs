using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HttpTool.Window.controls
{
    public abstract class AbsTreeNode : TreeNode
    {
        public string GetParentPath()
        {
            TreeNode node = this.Parent;
            StringBuilder path = new StringBuilder("");

            while (node != null)
            {
                path.Insert(0, node.Text + "\\");
                node = node.Parent;
            }

            return path.ToString();
        }

        public virtual string GetPath()
        {
            return GetParentPath() + this.Text;
        }

    }
}
