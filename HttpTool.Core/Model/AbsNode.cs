using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HttpTool.Core.Model
{
    public abstract class AbsNode
    {

        public string Name { get; set; }

        public string Desc { get; set; }

        public abstract void Exec(FlowContext ctx);
    }
}
