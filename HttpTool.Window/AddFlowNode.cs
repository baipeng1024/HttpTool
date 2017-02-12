using HttpTool.Core.Model;
using HttpTool.Window.tool;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HttpTool.Window.controls;

namespace HttpTool.Window
{
    public partial class AddFlowNode : Form
    {

        private FlowBreviaryNodeC breviaryNode;

        public AddFlowNode(FlowBreviaryNodeC breviaryNode)
        {
            InitializeComponent();
            this.breviaryNode = breviaryNode;
            LoadData();
        }

        private void LoadData()
        {
            cbxNodeType.Items.Add(EFlowNodeType.JS.ToString());
            cbxNodeType.Items.Add(EFlowNodeType.HTTP.ToString());
            cbxNodeType.Items.Add(EFlowNodeType.REFRENCE.ToString());
            foreach (KeyValuePair<string, AbsFlowNode> item in GlobalObj.FLOWS.IndependentNodes)
            {
                cbxReferenceNode.Items.Add(new ComboBoxItem<string, AbsFlowNode>(item.Key + item.Value, item.Value));
            }
        }

        private void OnSave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tcName.GetText()))
            {
                MessageBox.Show("节点名称不可为空");
                return;
            }

            string type = (string)cbxNodeType.SelectedItem;
            if (type == EFlowNodeType.JS.ToString())
            {
                JSNode jsNode = new JSNode();
                jsNode.Name = tcName.GetText();
                jsNode.NextNode = breviaryNode.FlowNode.NextNode;
                breviaryNode.FlowNode.NextNode = jsNode;
            }
            else if (type == EFlowNodeType.HTTP.ToString())
            {
                HttpNode httpNode = new HttpNode();
                httpNode.Name = tcName.GetText();
                httpNode.NextNode = breviaryNode.FlowNode.NextNode;
                breviaryNode.FlowNode.NextNode = httpNode;

            }
            else if (type == EFlowNodeType.REFRENCE.ToString())
            {
                if (cbxNodeType.SelectedItem == null)
                {
                    MessageBox.Show("请选择一个要引用的节点");
                    return;
                }

                ComboBoxItem<string, AbsFlowNode> item = (ComboBoxItem<string, AbsFlowNode>)cbxNodeType.SelectedItem;
                item.val.NextNode = breviaryNode.FlowNode.NextNode;
                breviaryNode.FlowNode.NextNode = item.val;
            }

            breviaryNode.AddFlowNodeCallback(breviaryNode.FlowNode.NextNode);
            this.Close();
        }



        private void OnSelectedValueChanged(object sender, EventArgs e)
        {
            if ((string)cbxNodeType.SelectedItem == EFlowNodeType.REFRENCE.ToString())
            {
                cbxReferenceNode.Enabled = true;
            }
            else
            {
                cbxReferenceNode.SelectedItem = "";
                cbxReferenceNode.Enabled = false;
            }
        }
    }
}
