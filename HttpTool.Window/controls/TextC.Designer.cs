namespace HttpTool.Window.controls
{
    partial class TextC
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
            this.tbx = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // tbx
            // 
            this.tbx.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbx.Location = new System.Drawing.Point(0, 0);
            this.tbx.Name = "tbx";
            this.tbx.Size = new System.Drawing.Size(455, 21);
            this.tbx.TabIndex = 0;
            this.tbx.Enter += new System.EventHandler(this.OnEnter);
            this.tbx.Leave += new System.EventHandler(this.OnLeave);
            // 
            // TextC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tbx);
            this.Name = "TextC";
            this.Size = new System.Drawing.Size(455, 21);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbx;
    }
}
