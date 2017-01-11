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


        public AbsNode Node { get; set; }


        public BreviaryNodeC(AbsNode node, FlowTreeNodeC parent)
        {
            InitializeComponent();
            this.Node = node;
            this.parent = parent;
            this.Name = node.Name;
            if (node is JSNode)
            {
                this.pbxIcon.Image = Resource.js;
            }
            else if (node is HttpNode)
            {
                this.pbxIcon.Image = Resource.http;
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
                //this.ContextMenuStrip
               
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
        }

        

        private void AddMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void DeleteMenuItem_Click(object sender, EventArgs e)
        {

        }

    }
}
