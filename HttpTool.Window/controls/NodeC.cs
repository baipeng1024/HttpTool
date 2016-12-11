using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HttpTool.Window.controls
{
    public partial class NodeC : UserControl
    {

        private const string EDIT_TEXT = "编辑";

        private const string SAVE_TEXT = "保存";


        public NodeC()
        {
            InitializeComponent();

            this.pnlNode.Enabled = false;
            this.btnEdit.Text = EDIT_TEXT;
        }

        protected virtual void Load() { }

        protected virtual bool Save()
        {
            return false;
        }

        protected virtual void btnEdit_Click(object sender, EventArgs e)
        {
            if (this.pnlNode.Enabled && Save())
            {
                this.pnlNode.Enabled = false;
                this.btnEdit.Text = EDIT_TEXT;
            }
            else
            {
                this.pnlNode.Enabled = true;
                this.btnEdit.Text = SAVE_TEXT;
            }
        }

    }
}
