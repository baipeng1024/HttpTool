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
            ImageKey = ResourcesHelper.GetImgKey(Resource.folder_open);
            
        }


        public void OnCollapse() {
            ImageKey = ResourcesHelper.GetImgKey(Resource.folder_close);
        }

        public void OnExpand()
        {
            ImageKey = ResourcesHelper.GetImgKey(Resource.folder_open);
        }

    }
}
