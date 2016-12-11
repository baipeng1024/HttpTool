using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HttpTool.Core.Model;

namespace HttpTool.Window.controls
{
    public partial class HttpNodeC : NodeC
    {
        private HttpNode node;

        public HttpNodeC(HttpNode node)
        {
            this.node = node;
            InitializeComponent();
        }

        
    }
}
