namespace HttpTool.Window.controls
{
    partial class NodeC
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.pnl = new System.Windows.Forms.Panel();
            this.txtName = new HttpTool.Window.controls.TextC();
            this.gbxJSLibs = new System.Windows.Forms.GroupBox();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.lbxIncludes = new System.Windows.Forms.ListBox();
            this.lbxResource = new System.Windows.Forms.ListBox();
            this.tacDesc = new HttpTool.Window.controls.TextAreaC();
            this.lblDesc = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.btnEdit = new System.Windows.Forms.Button();
            this.pnlNode = new System.Windows.Forms.Panel();
            this.pnl.SuspendLayout();
            this.gbxJSLibs.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnl
            // 
            this.pnl.Controls.Add(this.txtName);
            this.pnl.Controls.Add(this.gbxJSLibs);
            this.pnl.Controls.Add(this.tacDesc);
            this.pnl.Controls.Add(this.lblDesc);
            this.pnl.Controls.Add(this.lblName);
            this.pnl.Controls.Add(this.btnEdit);
            this.pnl.Controls.Add(this.pnlNode);
            this.pnl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl.Location = new System.Drawing.Point(0, 0);
            this.pnl.Name = "pnl";
            this.pnl.Size = new System.Drawing.Size(760, 632);
            this.pnl.TabIndex = 0;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(61, 10);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(224, 21);
            this.txtName.TabIndex = 8;
            // 
            // gbxJSLibs
            // 
            this.gbxJSLibs.Controls.Add(this.btnRemove);
            this.gbxJSLibs.Controls.Add(this.btnAdd);
            this.gbxJSLibs.Controls.Add(this.lbxIncludes);
            this.gbxJSLibs.Controls.Add(this.lbxResource);
            this.gbxJSLibs.Location = new System.Drawing.Point(291, 10);
            this.gbxJSLibs.Name = "gbxJSLibs";
            this.gbxJSLibs.Size = new System.Drawing.Size(466, 121);
            this.gbxJSLibs.TabIndex = 7;
            this.gbxJSLibs.TabStop = false;
            this.gbxJSLibs.Text = "脚本库";
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(217, 69);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(33, 23);
            this.btnRemove.TabIndex = 1;
            this.btnRemove.Text = "<";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.BtnRemove_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(217, 29);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(33, 23);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = ">";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
            // 
            // lbxIncludes
            // 
            this.lbxIncludes.FormattingEnabled = true;
            this.lbxIncludes.ItemHeight = 12;
            this.lbxIncludes.Location = new System.Drawing.Point(260, 15);
            this.lbxIncludes.Name = "lbxIncludes";
            this.lbxIncludes.Size = new System.Drawing.Size(202, 100);
            this.lbxIncludes.TabIndex = 0;
            // 
            // lbxResource
            // 
            this.lbxResource.FormattingEnabled = true;
            this.lbxResource.ItemHeight = 12;
            this.lbxResource.Location = new System.Drawing.Point(5, 15);
            this.lbxResource.Name = "lbxResource";
            this.lbxResource.Size = new System.Drawing.Size(202, 100);
            this.lbxResource.TabIndex = 0;
            // 
            // tacDesc
            // 
            this.tacDesc.Location = new System.Drawing.Point(61, 47);
            this.tacDesc.Name = "tacDesc";
            this.tacDesc.Size = new System.Drawing.Size(224, 84);
            this.tacDesc.TabIndex = 5;
            // 
            // lblDesc
            // 
            this.lblDesc.AutoSize = true;
            this.lblDesc.Location = new System.Drawing.Point(16, 47);
            this.lblDesc.Name = "lblDesc";
            this.lblDesc.Size = new System.Drawing.Size(41, 12);
            this.lblDesc.TabIndex = 4;
            this.lblDesc.Text = "描述：";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(16, 10);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(41, 12);
            this.lblName.TabIndex = 2;
            this.lblName.Text = "名称：";
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEdit.Location = new System.Drawing.Point(349, 593);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(62, 23);
            this.btnEdit.TabIndex = 1;
            this.btnEdit.Text = "编辑";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // pnlNode
            // 
            this.pnlNode.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlNode.Location = new System.Drawing.Point(0, 137);
            this.pnlNode.Name = "pnlNode";
            this.pnlNode.Size = new System.Drawing.Size(760, 454);
            this.pnlNode.TabIndex = 0;
            // 
            // NodeC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnl);
            this.Name = "NodeC";
            this.Size = new System.Drawing.Size(760, 632);
            this.pnl.ResumeLayout(false);
            this.pnl.PerformLayout();
            this.gbxJSLibs.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblDesc;
        private TextAreaC tacDesc;
        private System.Windows.Forms.GroupBox gbxJSLibs;
        private System.Windows.Forms.ListBox lbxResource;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.ListBox lbxIncludes;
        private TextC txtName;
        protected System.Windows.Forms.Panel pnl;
        protected System.Windows.Forms.Panel pnlNode;




    }
}
