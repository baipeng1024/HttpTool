namespace HttpTool.Window.controls
{
    partial class JSNodeC
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
            this.label1 = new System.Windows.Forms.Label();
            this.tacScript = new HttpTool.Window.controls.TextAreaC();
            this.pnl.SuspendLayout();
            this.pnlNode.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlNode
            // 
            this.pnlNode.Controls.Add(this.tacScript);
            this.pnlNode.Controls.Add(this.label1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "脚本：";
            // 
            // tacScript
            // 
            this.tacScript.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tacScript.Location = new System.Drawing.Point(61, 8);
            this.tacScript.Name = "tacScript";
            this.tacScript.Size = new System.Drawing.Size(692, 207);
            this.tacScript.TabIndex = 1;
            // 
            // JSNodeC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "JSNodeC";
            this.pnl.ResumeLayout(false);
            this.pnl.PerformLayout();
            this.pnlNode.ResumeLayout(false);
            this.pnlNode.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private TextAreaC tacScript;
    }
}
