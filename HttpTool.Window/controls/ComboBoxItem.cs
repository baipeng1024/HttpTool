using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HttpTool.Window.controls
{
    public class ComboBoxItem<KEY, VALUE>
    {
        public ComboBoxItem(KEY key, VALUE val)
        {
            this.key = key;
            this.val = val;
        }

        public KEY key { get; set; }

        public VALUE val { get; set; }

        public override string ToString()
        {
            return this.key.ToString();
        }
    }
}
