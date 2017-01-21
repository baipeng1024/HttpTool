namespace HttpTool.Window.controls
{
    partial class FlowNodeC
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
            this.tacRemark = new HttpTool.Window.controls.TextAreaC();
            this.pnl.SuspendLayout();
            this.pnlNode.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlNode
            // 
            this.pnlNode.Controls.Add(this.tacRemark);
            // 
            // tacRemark
            // 
            this.tacRemark.Location = new System.Drawing.Point(5, 4);
            this.tacRemark.Name = "tacRemark";
            this.tacRemark.Size = new System.Drawing.Size(750, 446);
            this.tacRemark.TabIndex = 0;
            // 
            // StartNodeC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "StartNodeC";
            this.pnl.ResumeLayout(false);
            this.pnl.PerformLayout();
            this.pnlNode.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private TextAreaC tacRemark;

    }
}
