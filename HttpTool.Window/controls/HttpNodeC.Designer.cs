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
            this.lblRequestType = new System.Windows.Forms.Label();
            this.cbxRequestType = new System.Windows.Forms.ComboBox();
            this.lblRequestUrl = new System.Windows.Forms.Label();
            this.tcRequestUrl = new HttpTool.Window.controls.TextC();
            this.lblPostPars = new System.Windows.Forms.Label();
            this.tcPostPars = new HttpTool.Window.controls.TextC();
            this.label4 = new System.Windows.Forms.Label();
            this.tacScript = new HttpTool.Window.controls.TextAreaC();
            this.pnl.SuspendLayout();
            this.pnlNode.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlNode
            // 
            this.pnlNode.Controls.Add(this.tacScript);
            this.pnlNode.Controls.Add(this.label4);
            this.pnlNode.Controls.Add(this.lblPostPars);
            this.pnlNode.Controls.Add(this.tcPostPars);
            this.pnlNode.Controls.Add(this.tcRequestUrl);
            this.pnlNode.Controls.Add(this.lblRequestUrl);
            this.pnlNode.Controls.Add(this.cbxRequestType);
            this.pnlNode.Controls.Add(this.lblRequestType);
            // 
            // lblRequestType
            // 
            this.lblRequestType.AutoSize = true;
            this.lblRequestType.Location = new System.Drawing.Point(16, 12);
            this.lblRequestType.Name = "lblRequestType";
            this.lblRequestType.Size = new System.Drawing.Size(65, 12);
            this.lblRequestType.TabIndex = 0;
            this.lblRequestType.Text = "请求类型：";
            // 
            // cbxRequestType
            // 
            this.cbxRequestType.FormattingEnabled = true;
            this.cbxRequestType.Location = new System.Drawing.Point(87, 8);
            this.cbxRequestType.Name = "cbxRequestType";
            this.cbxRequestType.Size = new System.Drawing.Size(209, 20);
            this.cbxRequestType.TabIndex = 1;
            // 
            // lblRequestUrl
            // 
            this.lblRequestUrl.AutoSize = true;
            this.lblRequestUrl.Location = new System.Drawing.Point(362, 12);
            this.lblRequestUrl.Name = "lblRequestUrl";
            this.lblRequestUrl.Size = new System.Drawing.Size(161, 12);
            this.lblRequestUrl.TabIndex = 2;
            this.lblRequestUrl.Text = "FunctionNameOfRequestUrl：";
            // 
            // tcRequestUrl
            // 
            this.tcRequestUrl.Location = new System.Drawing.Point(529, 8);
            this.tcRequestUrl.Name = "tcRequestUrl";
            this.tcRequestUrl.Size = new System.Drawing.Size(224, 21);
            this.tcRequestUrl.TabIndex = 3;
            // 
            // lblPostPars
            // 
            this.lblPostPars.AutoSize = true;
            this.lblPostPars.Location = new System.Drawing.Point(16, 49);
            this.lblPostPars.Name = "lblPostPars";
            this.lblPostPars.Size = new System.Drawing.Size(167, 12);
            this.lblPostPars.TabIndex = 4;
            this.lblPostPars.Text = "FunctionNameOfPostParsStr：";
            // 
            // tcPostPars
            // 
            this.tcPostPars.Location = new System.Drawing.Point(187, 45);
            this.tcPostPars.Name = "tcPostPars";
            this.tcPostPars.Size = new System.Drawing.Size(224, 21);
            this.tcPostPars.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 86);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 5;
            this.label4.Text = "脚本：";
            // 
            // tacScript
            // 
            this.tacScript.Location = new System.Drawing.Point(61, 87);
            this.tacScript.Name = "tacScript";
            this.tacScript.Size = new System.Drawing.Size(692, 131);
            this.tacScript.TabIndex = 6;
            // 
            // HttpNodeC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "HttpNodeC";
            this.pnl.ResumeLayout(false);
            this.pnl.PerformLayout();
            this.pnlNode.ResumeLayout(false);
            this.pnlNode.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblRequestType;
        private System.Windows.Forms.ComboBox cbxRequestType;
        private System.Windows.Forms.Label lblRequestUrl;
        private System.Windows.Forms.Label lblPostPars;
        private TextC tcRequestUrl;
        private System.Windows.Forms.Label label4;
        private TextC tcPostPars;
        private TextAreaC tacScript;
    }
}
