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
    public partial class TextAreaC : UserControl
    {
        public TextAreaC()
        {
            InitializeComponent();
        }

        public void SetText(string content) {
            rtb.Text = content;
        }

        public string GetText() {
            return rtb.Text;
        }
    }
}
