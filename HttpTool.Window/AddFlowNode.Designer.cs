namespace HttpTool.Window
{
    partial class AddFlowNode
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
            this.label1 = new System.Windows.Forms.Label();
            this.cbxNodeType = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tcName = new HttpTool.Window.controls.TextC();
            this.label3 = new System.Windows.Forms.Label();
            this.cbxReferenceNode = new System.Windows.Forms.ComboBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "节点类型：";
            // 
            // cbxNodeType
            // 
            this.cbxNodeType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxNodeType.FormattingEnabled = true;
            this.cbxNodeType.Location = new System.Drawing.Point(95, 28);
            this.cbxNodeType.Name = "cbxNodeType";
            this.cbxNodeType.Size = new System.Drawing.Size(166, 20);
            this.cbxNodeType.TabIndex = 1;
            this.cbxNodeType.SelectedIndexChanged += new System.EventHandler(this.OnSelectedValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "节点名称：";
            // 
            // tcName
            // 
            this.tcName.Location = new System.Drawing.Point(95, 69);
            this.tcName.Name = "tcName";
            this.tcName.Size = new System.Drawing.Size(166, 21);
            this.tcName.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 115);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "引用节点：";
            // 
            // cbxReferenceNode
            // 
            this.cbxReferenceNode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxReferenceNode.FormattingEnabled = true;
            this.cbxReferenceNode.Location = new System.Drawing.Point(95, 111);
            this.cbxReferenceNode.Name = "cbxReferenceNode";
            this.cbxReferenceNode.Size = new System.Drawing.Size(166, 20);
            this.cbxReferenceNode.TabIndex = 5;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(105, 159);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.OnSave);
            // 
            // AddFlowNode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 204);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.cbxReferenceNode);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tcName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbxNodeType);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(300, 243);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(300, 243);
            this.Name = "AddFlowNode";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "新增节点";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbxNodeType;
        private System.Windows.Forms.Label label2;
        private controls.TextC tcName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbxReferenceNode;
        private System.Windows.Forms.Button btnSave;
    }
}