using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HttpTool.Core.Model;
using HttpTool.Core.JS;

namespace HttpTool.Window.controls
{
    public partial class NodeC : UserControl
    {

        private const string EDIT_TEXT = "编辑";

        private const string SAVE_TEXT = "保存";

        protected AbsFlowNode flowNode;

        protected NodeC()
        {
            InitializeComponent();
        }

        public NodeC(AbsFlowNode node)
        {
            InitializeComponent();
            btnEdit.Text = EDIT_TEXT;
            this.flowNode = node;
        }

        protected virtual void Load()
        {
            txtName.SetText(flowNode.Name);
            tacDesc.SetText(flowNode.Desc);
            lbxResource.Items.AddRange(JSLibHelper.GetJSLibs().ToArray());
            List<string> jsLibs = flowNode.GetIncludeJSLibs();
            if (jsLibs != null)
            { 
                lbxIncludes.Items.AddRange(jsLibs.ToArray());
            }
        }


        protected virtual void LockEdit()
        {
            txtName.Enabled = false;
            tacDesc.Enabled = false;
            btnAdd.Enabled = false;
            btnRemove.Enabled = false;
        }

        protected virtual void EnableEdit()
        {
            txtName.Enabled = true;
            tacDesc.Enabled = true;
            btnAdd.Enabled = true;
            btnRemove.Enabled = true;
        }

        protected virtual bool Save()
        {
            flowNode.Name = txtName.GetText().Trim();
            flowNode.Desc = tacDesc.GetText();
            flowNode.includeJSLibs = new List<string>();
            foreach (string item in lbxIncludes.Items)
            {
                flowNode.includeJSLibs.Add(item);
            }
            return true;
        }

        protected virtual void btnEdit_Click(object sender, EventArgs e)
        {
            if (btnEdit.Text == SAVE_TEXT && Save())
            {
                LockEdit();
                btnEdit.Text = EDIT_TEXT;
            }
            else
            {
                EnableEdit();
                btnEdit.Text = SAVE_TEXT;
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            if (lbxResource.SelectedItem != null && !lbxIncludes.Items.Contains(lbxResource.SelectedItem))
            {
                lbxIncludes.Items.Add(lbxResource.SelectedItem);
            }
        }

        private void BtnRemove_Click(object sender, EventArgs e)
        {
            if (lbxIncludes.SelectedItem != null)
            {
                lbxIncludes.Items.RemoveAt(lbxIncludes.SelectedIndex);
            }
        }

    }
}
