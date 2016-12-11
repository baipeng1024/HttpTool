namespace HttpTool.Window
{
    partial class Test
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.tbxUrl = new System.Windows.Forms.TextBox();
            this.rtbMyJs = new System.Windows.Forms.RichTextBox();
            this.rtbConsole = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(25, 38);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "运行";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(139, 38);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "下一页";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // tbxUrl
            // 
            this.tbxUrl.Location = new System.Drawing.Point(25, 90);
            this.tbxUrl.Name = "tbxUrl";
            this.tbxUrl.Size = new System.Drawing.Size(674, 21);
            this.tbxUrl.TabIndex = 3;
            // 
            // rtbMyJs
            // 
            this.rtbMyJs.Location = new System.Drawing.Point(25, 156);
            this.rtbMyJs.Name = "rtbMyJs";
            this.rtbMyJs.Size = new System.Drawing.Size(674, 174);
            this.rtbMyJs.TabIndex = 4;
            this.rtbMyJs.Text = "";
            // 
            // rtbConsole
            // 
            this.rtbConsole.Location = new System.Drawing.Point(25, 392);
            this.rtbConsole.Name = "rtbConsole";
            this.rtbConsole.Size = new System.Drawing.Size(674, 139);
            this.rtbConsole.TabIndex = 4;
            this.rtbConsole.Text = "";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(917, 665);
            this.Controls.Add(this.rtbConsole);
            this.Controls.Add(this.rtbMyJs);
            this.Controls.Add(this.tbxUrl);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "Main";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox tbxUrl;
        private System.Windows.Forms.RichTextBox rtbMyJs;
        private System.Windows.Forms.RichTextBox rtbConsole;
    }
}

