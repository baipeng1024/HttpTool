using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HttpTool.Window.controls
{
    public partial class TextC : UserControl
    {

        private string tip;

        private string text = string.Empty;


        public TextC()
        {
            InitializeComponent();
        }

        public void SetTip(string tip)
        {
            this.tip = tip;
            ShowTip();
        }

        public void SetText(string text)
        {
            this.text = text;
            tbx.Text = text;
            tbx.ForeColor = SystemColors.Control;
        }

        public string GetText()
        {
            return text;
        }

        private void OnEnter(object sender, EventArgs e)
        {
            tbx.Text = text;
            tbx.ForeColor = SystemColors.Control;
        }

        private void OnLeave(object sender, EventArgs e)
        {
            text = tbx.Text;
            ShowTip();
        }


        private void ShowTip()
        {
            if (text == string.Empty)
            {
                tbx.ForeColor = Color.Gray;
                tbx.Text = tip;
            }
        }


    }
}
