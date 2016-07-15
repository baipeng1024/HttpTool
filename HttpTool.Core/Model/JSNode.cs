using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HttpTool.Core.Model
{
    public class JSNode : AbsNode
    {

        public string JS { get; set; }

        public override void Exec(FlowContext ctx)
        {
             
        }
    }
}
