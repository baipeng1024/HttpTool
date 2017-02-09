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
      

        public DirTreeNodeC(string text,ContextMenuStrip ctxMenu) {
            this.Text = text;
            this.ContextMenuStrip = ctxMenu;
            ImageKey = ResourcesHelper.IMG_FOLDER_CLOSE_KEY;
            SelectedImageKey = ImageKey;            
        }


    }
}
