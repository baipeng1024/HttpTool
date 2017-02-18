namespace HttpTool.Window.controls
{
    partial class HttpNodeC
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
            this.tacInitRequest = new HttpTool.Window.controls.TextAreaC();
            this.gbxInitRequest = new System.Windows.Forms.GroupBox();
            this.gbxOnLoad = new System.Windows.Forms.GroupBox();
            this.tacOnLoad = new HttpTool.Window.controls.TextAreaC();
            this.pnl.SuspendLayout();
            this.pnlNode.SuspendLayout();
            this.gbxInitRequest.SuspendLayout();
            this.gbxOnLoad.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlNode
            // 
            this.pnlNode.Controls.Add(this.gbxOnLoad);
            this.pnlNode.Controls.Add(this.gbxInitRequest);
            // 
            // tacInitRequest
            // 
            this.tacInitRequest.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tacInitRequest.Location = new System.Drawing.Point(3, 17);
            this.tacInitRequest.Name = "tacInitRequest";
            this.tacInitRequest.Size = new System.Drawing.Size(729, 165);
            this.tacInitRequest.TabIndex = 7;
            // 
            // gbxInitRequest
            // 
            this.gbxInitRequest.Controls.Add(this.tacInitRequest);
            this.gbxInitRequest.Location = new System.Drawing.Point(18, 13);
            this.gbxInitRequest.Name = "gbxInitRequest";
            this.gbxInitRequest.Size = new System.Drawing.Size(735, 185);
            this.gbxInitRequest.TabIndex = 8;
            this.gbxInitRequest.TabStop = false;
            this.gbxInitRequest.Text = "initRequest";
            // 
            // gbxOnLoad
            // 
            this.gbxOnLoad.Controls.Add(this.tacOnLoad);
            this.gbxOnLoad.Location = new System.Drawing.Point(18, 204);
            this.gbxOnLoad.Name = "gbxOnLoad";
            this.gbxOnLoad.Size = new System.Drawing.Size(735, 235);
            this.gbxOnLoad.TabIndex = 9;
            this.gbxOnLoad.TabStop = false;
            this.gbxOnLoad.Text = "onLoad";
            // 
            // tacOnLoad
            // 
            this.tacOnLoad.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tacOnLoad.Location = new System.Drawing.Point(3, 17);
            this.tacOnLoad.Name = "tacOnLoad";
            this.tacOnLoad.Size = new System.Drawing.Size(729, 215);
            this.tacOnLoad.TabIndex = 7;
            // 
            // HttpNodeC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "HttpNodeC";
            this.pnl.ResumeLayout(false);
            this.pnl.PerformLayout();
            this.pnlNode.ResumeLayout(false);
            this.gbxInitRequest.ResumeLayout(false);
            this.gbxOnLoad.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private TextAreaC tacInitRequest;
        private System.Windows.Forms.GroupBox gbxInitRequest;
        private System.Windows.Forms.GroupBox gbxOnLoad;
        private TextAreaC tacOnLoad;
    }
}
