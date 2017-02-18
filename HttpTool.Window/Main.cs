using HttpTool.Core.Model;
using HttpTool.Window.controls;
using HttpTool.Window.tool;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HttpTool.Window
{
    public partial class Main : Form
    {

        public Main()
        {
            InitializeComponent();
            ctxMenu.Hide();
        }


        private void Main_Load(object sender, EventArgs e)
        {
            try
            {
                tvwFlows.ImageList = ResourcesHelper.IMAGES;
                tvwFlows.Nodes.Add(new DirTreeNodeC("flows", flpnl, spcRight.Panel2, ctxMenu));
                GlobalObj.FLOWS.Load("flows.xml");
            }
            catch (Exception ex)
            {
                MessageBox.Show("初始化失败:" + ex.Message);
                return;
            }

            foreach (KeyValuePair<string, SingleHttpFlow> item in GlobalObj.FLOWS.HttpFlows)
            {
                FindAndTryBuild(item.Key).Nodes.Add(new FlowTreeNodeC(item.Value, flpnl, spcRight.Panel2, ctxMenu));
            }

            foreach (KeyValuePair<string, AbsFlowNode> item in GlobalObj.FLOWS.IndependentNodes)
            {
                FindAndTryBuild(item.Key).Nodes.Add(new IndependentTreeNodeC(item.Value, flpnl, spcRight.Panel2, ctxMenu));

            }


        }


        private TreeNode FindAndTryBuild(string path)
        {
            if (string.IsNullOrEmpty(path))
            {
                return tvwFlows.TopNode;
            }

            string[] split = { Flows.PATH_SPLIT };
            string[] nameArr = path.Split(split, StringSplitOptions.RemoveEmptyEntries);
            if (nameArr.Length == 0)
            {
                return tvwFlows.TopNode;
            }

            TreeNode node = tvwFlows.TopNode.FirstNode;
            IEnumerator nameIter = nameArr.GetEnumerator();
            nameIter.MoveNext();
            string name = (string)nameIter.Current;

            while (true)
            {
                if (node == null)
                {
                    tvwFlows.TopNode.Nodes.Add((node = new DirTreeNodeC(name, flpnl, spcRight.Panel2, ctxMenu)));
                }
                else if (node.Text == name)
                {
                    if (nameIter.MoveNext())
                    {
                        name = (string)nameIter.Current;
                        if (node.FirstNode == null)
                        {
                            node.Nodes.Add(new DirTreeNodeC(name, flpnl, spcRight.Panel2, ctxMenu));
                        }
                        node = node.FirstNode;
                    }
                    else
                    {
                        return node;
                    }
                }
                else if (node.NextNode == null)
                {
                    node.Parent.Nodes.Add((node = new DirTreeNodeC(name, flpnl, spcRight.Panel2, ctxMenu)));
                }
                else
                {
                    node = node.NextNode;
                }
            }
        }



        private void tvwFlows_AfterSelect(object sender, TreeViewEventArgs e)
        {
            ((AbsTreeNode)e.Node).OnAfterSelect();
        }

        private void tvwFlows_MouseDown(object sender, MouseEventArgs e)
        {
            TreeNode currentNode = tvwFlows.GetNodeAt(new Point(e.X, e.Y));
            if (currentNode != null)
            {
                ((AbsTreeNode)currentNode).OnMouseDown(e.Button);
            }
        }


        private void tvwFlows_KeyDown(object sender, KeyEventArgs e)
        {
            TreeNode node = tvwFlows.SelectedNode;
            if (node.Parent != null && e.KeyData == Keys.F2)
            {
                node.BeginEdit();
            }

        }

        private void tvwFlows_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            if (e.Node.Parent == null || e.Label == null)
            {
                return;
            }

            if (e.Label == string.Empty || e.Label == e.Node.Text)
            {
                e.CancelEdit = true;
                return;
            }

            foreach (TreeNode node in e.Node.Parent.Nodes)
            {
                if (e.Node != node)
                {
                    if (e.Label == node.Text)
                    {
                        e.CancelEdit = true;
                        return;
                    }
                }
            }



        }

        private void OnCreateDirMenuItem_Click(object sender, EventArgs e)
        {
            TreeNode node = tvwFlows.SelectedNode;
            if (node is DirTreeNodeC)
            {
                node.Nodes.Add(new DirTreeNodeC("未命名", flpnl, spcRight.Panel2, ctxMenu));
            }
        }

        private void OnCreateFlowMenuItem_Click(object sender, EventArgs e)
        {
            AbsTreeNode node = (AbsTreeNode)tvwFlows.SelectedNode;
            SingleHttpFlow flowNode = new SingleHttpFlow();
            string t = node.GetPath();
            GlobalObj.FLOWS.HttpFlows.Add(new KeyValuePair<string, SingleHttpFlow>(node.GetPath(), flowNode));
            flowNode.Name = "未命名";
            node.Nodes.Add(new FlowTreeNodeC(flowNode, flpnl, spcRight.Panel2, ctxMenu));
        }

        private void OnCreateFlowNodeMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void OnRemoveMenuItem_Click(object sender, EventArgs e)
        {
            TreeNode node = tvwFlows.SelectedNode;
            if (node is DirTreeNodeC)
            {
                if (node.Nodes.Count == 0)
                {
                    node.Remove();
                }
            }
        }

        private void tvwFlows_AfterCollapse(object sender, TreeViewEventArgs e)
        {
            DirTreeNodeC dirNode = (DirTreeNodeC)e.Node;
            dirNode.ImageKey = ResourcesHelper.IMG_FOLDER_CLOSE_KEY;
            dirNode.SelectedImageKey = dirNode.ImageKey;
        }

        private void tvwFlows_AfterExpand(object sender, TreeViewEventArgs e)
        {
            DirTreeNodeC dirNode = (DirTreeNodeC)e.Node;
            dirNode.ImageKey = ResourcesHelper.IMG_FOLDER_OPEN_KEY;
            dirNode.SelectedImageKey = dirNode.ImageKey;
        }






    }
}
