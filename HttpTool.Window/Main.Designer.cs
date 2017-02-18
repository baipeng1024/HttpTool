namespace HttpTool.Window
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.spcMain = new System.Windows.Forms.SplitContainer();
            this.tvwFlows = new System.Windows.Forms.TreeView();
            this.spcRight = new System.Windows.Forms.SplitContainer();
            this.flpnl = new System.Windows.Forms.FlowLayoutPanel();
            this.menus = new System.Windows.Forms.MenuStrip();
            this.菜单ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.创建目录ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.创建流程ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.创建流程节点ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.移除ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.运行ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.spcMain)).BeginInit();
            this.spcMain.Panel1.SuspendLayout();
            this.spcMain.Panel2.SuspendLayout();
            this.spcMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spcRight)).BeginInit();
            this.spcRight.Panel1.SuspendLayout();
            this.spcRight.SuspendLayout();
            this.menus.SuspendLayout();
            this.ctxMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // spcMain
            // 
            this.spcMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.spcMain.IsSplitterFixed = true;
            this.spcMain.Location = new System.Drawing.Point(0, 28);
            this.spcMain.Name = "spcMain";
            // 
            // spcMain.Panel1
            // 
            this.spcMain.Panel1.Controls.Add(this.tvwFlows);
            // 
            // spcMain.Panel2
            // 
            this.spcMain.Panel2.Controls.Add(this.spcRight);
            this.spcMain.Size = new System.Drawing.Size(1006, 700);
            this.spcMain.SplitterDistance = 217;
            this.spcMain.TabIndex = 0;
            // 
            // tvwFlows
            // 
            this.tvwFlows.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvwFlows.Indent = 19;
            this.tvwFlows.ItemHeight = 20;
            this.tvwFlows.LabelEdit = true;
            this.tvwFlows.Location = new System.Drawing.Point(0, 0);
            this.tvwFlows.Name = "tvwFlows";
            this.tvwFlows.Size = new System.Drawing.Size(217, 700);
            this.tvwFlows.TabIndex = 0;
            this.tvwFlows.AfterLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.tvwFlows_AfterLabelEdit);
            this.tvwFlows.AfterCollapse += new System.Windows.Forms.TreeViewEventHandler(this.tvwFlows_AfterCollapse);
            this.tvwFlows.AfterExpand += new System.Windows.Forms.TreeViewEventHandler(this.tvwFlows_AfterExpand);
            this.tvwFlows.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvwFlows_AfterSelect);
            this.tvwFlows.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tvwFlows_KeyDown);
            this.tvwFlows.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tvwFlows_MouseDown);
            // 
            // spcRight
            // 
            this.spcRight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.spcRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spcRight.IsSplitterFixed = true;
            this.spcRight.Location = new System.Drawing.Point(0, 0);
            this.spcRight.Name = "spcRight";
            this.spcRight.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // spcRight.Panel1
            // 
            this.spcRight.Panel1.Controls.Add(this.flpnl);
            this.spcRight.Size = new System.Drawing.Size(785, 700);
            this.spcRight.SplitterDistance = 54;
            this.spcRight.TabIndex = 0;
            // 
            // flpnl
            // 
            this.flpnl.AutoScroll = true;
            this.flpnl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpnl.Location = new System.Drawing.Point(0, 0);
            this.flpnl.Name = "flpnl";
            this.flpnl.Size = new System.Drawing.Size(783, 52);
            this.flpnl.TabIndex = 0;
            this.flpnl.WrapContents = false;
            // 
            // menus
            // 
            this.menus.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.menus.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.菜单ToolStripMenuItem});
            this.menus.Location = new System.Drawing.Point(0, 0);
            this.menus.Name = "menus";
            this.menus.Size = new System.Drawing.Size(1008, 25);
            this.menus.TabIndex = 1;
            this.menus.Text = "menuStrip1";
            // 
            // 菜单ToolStripMenuItem
            // 
            this.菜单ToolStripMenuItem.Name = "菜单ToolStripMenuItem";
            this.菜单ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.菜单ToolStripMenuItem.Text = "菜单";
            // 
            // ctxMenu
            // 
            this.ctxMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.运行ToolStripMenuItem,
            this.创建目录ToolStripMenuItem,
            this.创建流程ToolStripMenuItem,
            this.创建流程节点ToolStripMenuItem,
            this.移除ToolStripMenuItem});
            this.ctxMenu.Name = "ctxMenu";
            this.ctxMenu.Size = new System.Drawing.Size(153, 136);
            // 
            // 创建目录ToolStripMenuItem
            // 
            this.创建目录ToolStripMenuItem.Name = "创建目录ToolStripMenuItem";
            this.创建目录ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.创建目录ToolStripMenuItem.Text = "创建目录";
            this.创建目录ToolStripMenuItem.Click += new System.EventHandler(this.OnCreateDirMenuItem_Click);
            // 
            // 创建流程ToolStripMenuItem
            // 
            this.创建流程ToolStripMenuItem.Name = "创建流程ToolStripMenuItem";
            this.创建流程ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.创建流程ToolStripMenuItem.Text = "创建流程";
            this.创建流程ToolStripMenuItem.Click += new System.EventHandler(this.OnCreateFlowMenuItem_Click);
            // 
            // 创建流程节点ToolStripMenuItem
            // 
            this.创建流程节点ToolStripMenuItem.Name = "创建流程节点ToolStripMenuItem";
            this.创建流程节点ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.创建流程节点ToolStripMenuItem.Text = "创建流程节点";
            this.创建流程节点ToolStripMenuItem.Click += new System.EventHandler(this.OnCreateFlowNodeMenuItem_Click);
            // 
            // 移除ToolStripMenuItem
            // 
            this.移除ToolStripMenuItem.Name = "移除ToolStripMenuItem";
            this.移除ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.移除ToolStripMenuItem.Text = "移除";
            this.移除ToolStripMenuItem.Click += new System.EventHandler(this.OnRemoveMenuItem_Click);
            // 
            // 运行ToolStripMenuItem
            // 
            this.运行ToolStripMenuItem.Name = "运行ToolStripMenuItem";
            this.运行ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.运行ToolStripMenuItem.Text = "运行";
            this.运行ToolStripMenuItem.Click += new System.EventHandler(this.OnRunMenuItem_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 730);
            this.Controls.Add(this.spcMain);
            this.Controls.Add(this.menus);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.MainMenuStrip = this.menus;
            this.MaximumSize = new System.Drawing.Size(1024, 768);
            this.MinimumSize = new System.Drawing.Size(1024, 768);
            this.Name = "Main";
            this.Text = "Main";
            this.Load += new System.EventHandler(this.Main_Load);
            this.spcMain.Panel1.ResumeLayout(false);
            this.spcMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spcMain)).EndInit();
            this.spcMain.ResumeLayout(false);
            this.spcRight.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spcRight)).EndInit();
            this.spcRight.ResumeLayout(false);
            this.menus.ResumeLayout(false);
            this.menus.PerformLayout();
            this.ctxMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer spcMain;
        private System.Windows.Forms.TreeView tvwFlows;
        private System.Windows.Forms.MenuStrip menus;
        private System.Windows.Forms.ToolStripMenuItem 菜单ToolStripMenuItem;
        private System.Windows.Forms.SplitContainer spcRight;
        private System.Windows.Forms.FlowLayoutPanel flpnl;
        private System.Windows.Forms.ContextMenuStrip ctxMenu;
        private System.Windows.Forms.ToolStripMenuItem 创建目录ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 创建流程ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 创建流程节点ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 移除ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 运行ToolStripMenuItem;
    }
}