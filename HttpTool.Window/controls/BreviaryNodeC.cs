using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HttpTool.Core.Model;

namespace HttpTool.Window.controls
{
    public partial class BreviaryNodeC : UserControl
    {

        private bool isSelected;
        private FlowTreeNodeC parent;


        public AbsFlowNode Node { get; set; }

        public NodeC ContentNodeC { get; set; }

        public BreviaryNodeC(AbsFlowNode node, FlowTreeNodeC parent)
        {
            InitializeComponent();
            this.Node = node;
            this.parent = parent;
            lblName.Text = node.Name;
            ctxMenu.Hide();
            if (node is SingleHttpFlow)
            {
                this.pbxIcon.Image = Resource.flow;
                ContentNodeC = new FlowNodeC((SingleHttpFlow)node);
            }
            else if (node is JSNode)
            {
                this.pbxIcon.Image = Resource.js;
                ContentNodeC = new JSNodeC((JSNode)node);
            }
            else if (node is HttpNode)
            {
                this.pbxIcon.Image = Resource.http;
                ContentNodeC = new HttpNodeC((HttpNode)node);
            }

            this.MouseEnter += OnMouseEnter;
            this.MouseLeave += OnMouseLeave;
            this.MouseDown += OnMouseDown;
            foreach (Control c in this.Controls)
            {
                c.MouseEnter += OnMouseEnter;
                c.MouseLeave += OnMouseLeave;
                c.MouseDown += OnMouseDown;
            }



        }

        public void CancelSelection()
        {
            this.isSelected = false;
            this.BackColor = SystemColors.Control;
        }


        public void Selected()
        {
            BackColor = Color.Red;
            isSelected = true;
            parent.SelectNotice(this);

        }

        public void AddFlowNodeCallback(AbsFlowNode node)
        {
            BreviaryNodeC newBreviaryNodeC = parent.AddNode(node, this);
            newBreviaryNodeC.Selected();
        }



        private void OnMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (this.isSelected)
                {
                    return;
                }
                this.BackColor = Color.Red;
                this.isSelected = true;
                this.parent.SelectNotice(this);
            }
            else if (e.Button == MouseButtons.Right)
            {

                if (this.isSelected)
                {
                    if (Node is SingleHttpFlow)
                    {
                        ctxMenu.Items[1].Visible = false;
                    }
                    else
                    {
                        ctxMenu.Items[1].Visible = true;
                    }
                    ctxMenu.Show();
                }
            }

        }


        private void OnMouseEnter(object sender, EventArgs e)
        {
            if (this.isSelected)
            {
                return;
            }
            this.BackColor = Color.Red;
        }

        private void OnMouseLeave(object sender, EventArgs e)
        {
            if (this.isSelected)
            {
                return;
            }
            this.BackColor = SystemColors.Control;
            ctxMenu.Hide();
        }



        private void AddMenuItem_Click(object sender, EventArgs e)
        {
            AddFlowNode win = new AddFlowNode(this);
            win.ShowDialog();
        }

        private void DeleteMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("是否要移除：" + Node.Name, "提示", MessageBoxButtons.OKCancel);
            if (result == DialogResult.OK)
            {
                parent.RemoveNode(this);
            }
        }



    }
}
