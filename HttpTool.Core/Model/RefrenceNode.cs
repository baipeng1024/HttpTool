using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HttpTool.Core.Model
{
    public class RefrenceNode : AbsFlowNode
    {
        public AbsFlowNode RealNode { get; set; }

        public override void Exec(FlowContext ctx)
        {
            RealNode.Exec(ctx);

            if (this.NextNode != null)
            {
                this.NextNode.Exec(ctx);
            }
        }
    }
}
