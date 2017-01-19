﻿using HttpTool.Core.Model;
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
            tvwFlows.Nodes.Add(new DirTreeNodeC("flows"));
            tvwFlows.ImageList = ResourcesHelper.IMAGES;
        }


        private void Main_Load(object sender, EventArgs e)
        {
            try
            {
                GlobalObj.FLOWS.Load("flows.xml");
            }
            catch (Exception ex)
            {
                MessageBox.Show("初始化失败:" + ex.Message);
                return;
            }

            foreach (KeyValuePair<string, SingleHttpFlow> item in GlobalObj.FLOWS.HttpFlows)
            {
                FindAndTryBuild(item.Key).Nodes.Add(new FlowTreeNodeC(item.Value,flpnl,spcRight.Panel2));
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

            TreeNode node = tvwFlows.TopNode;
            IEnumerator nameIter = nameArr.GetEnumerator();
            nameIter.MoveNext();
            string name = (string)nameIter.Current;

            while (true)
            {
                if (node.Text == name)
                {
                    if (nameIter.MoveNext())
                    {
                        name = (string)nameIter.Current;
                        if (node.FirstNode == null)
                        {
                            node.Nodes.Add(new DirTreeNodeC(name));
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
                    if (node.Parent == null)
                    {
                        node.Nodes.Add((node = new DirTreeNodeC(name)));
                    }
                    else
                    {
                        node.Parent.Nodes.Add((node = new DirTreeNodeC(name)));
                    }
                }
                else
                {
                    node = node.NextNode;
                }
            }
        }

        private void tvwFlows_BeforeCollapse(object sender, TreeViewCancelEventArgs e)
        {
            if (e.Node is DirTreeNodeC) {
                ((DirTreeNodeC)e.Node).OnCollapse();
                 
            }
        }

        private void tvwFlows_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            if (e.Node is DirTreeNodeC)
            {
                ((DirTreeNodeC)e.Node).OnExpand();
                 
            }
        }

        private void tvwFlows_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            
        }

        private void tvwFlows_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node is FlowTreeNodeC)
            {
                flpnl.Controls.Clear();
                flpnl.Controls.AddRange(((FlowTreeNodeC)e.Node).BreviaryNodes);
            }
        }


    }
}
