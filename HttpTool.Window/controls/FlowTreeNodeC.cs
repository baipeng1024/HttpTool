﻿using HttpTool.Core.Model;
using HttpTool.Window.tool;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HttpTool.Window.controls
{
    public class FlowTreeNodeC : AbsTreeNode
    {
        public SingleHttpFlow HttpFlow { get; set; }

        public BreviaryNodeC[] BreviaryNodes { get; set; }

        private BreviaryNodeC currentNode;

        private FlowLayoutPanel parentPnl;

        private Panel contentPnl;

        public FlowTreeNodeC(SingleHttpFlow singleHttpFlow, FlowLayoutPanel parentPnl, Panel contentPnl, ContextMenuStrip ctxMenu)
        {
            HttpFlow = singleHttpFlow;
            Text = singleHttpFlow.Name;
            AbsFlowNode node = HttpFlow.HeadNode;
            this.parentPnl = parentPnl;
            this.contentPnl = contentPnl;
            ContextMenuStrip = ctxMenu;
            ImageKey = ResourcesHelper.IMG_FLOW_KEY;
            SelectedImageKey = ResourcesHelper.IMG_FLOW_KEY;      
            List<BreviaryNodeC> breviaryNodes = new List<BreviaryNodeC>();
            breviaryNodes.Add(new BreviaryNodeC(singleHttpFlow, this));

            while (node != null)
            {
                breviaryNodes.Add(new BreviaryNodeC(node, this));
                node = node.NextNode;
            }

            BreviaryNodes = breviaryNodes.ToArray();
        }

        public BreviaryNodeC AddNode(AbsFlowNode node, BreviaryNodeC prev)
        {
            BreviaryNodeC[] nodes = new BreviaryNodeC[BreviaryNodes.Length + 1];
            int i = 0;
            BreviaryNodeC newNode = null;
            foreach (BreviaryNodeC item in BreviaryNodes)
            {
                nodes[i++] = item;
                if (prev == item)
                {
                    newNode = new BreviaryNodeC(node, this);
                    parentPnl.Controls.Add(newNode);
                    parentPnl.Controls.SetChildIndex(newNode, i);
                    nodes[i++] = newNode;
                }
            }
            BreviaryNodes = nodes;
            return newNode;
        }

        public void RemoveNode(BreviaryNodeC breviaryNode)
        {
            BreviaryNodeC[] nodes = new BreviaryNodeC[BreviaryNodes.Length - 1];
            int i = 0;
            foreach (BreviaryNodeC item in BreviaryNodes)
            {
                if (breviaryNode == item)
                {
                    nodes[i - 1].Selected();
                }
                else
                {
                    nodes[i++] = item;
                }

            }
            BreviaryNodes = nodes;
            HttpFlow.RemoveNode(breviaryNode.Node);
            parentPnl.Controls.Remove(breviaryNode);
        }


        public void SelectNotice(BreviaryNodeC node)
        {

            if (currentNode != null && currentNode != node)
            {
                currentNode.CancelSelection();
            }

            currentNode = node;
            contentPnl.Controls.Clear();
            contentPnl.Controls.Add(currentNode.ContentNodeC);
        }

        public override string GetPath()
        {
            return GetParentPath();
        }
    }
}
