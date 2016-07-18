﻿using HttpTool.Core.JS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HttpTool.Core.Model
{
    public abstract class AbsNode
    {

        public string Id { get; set; }

        public string Name { get; set; }

        public string Desc { get; set; }
        public AbsNode NexNode { get; set; }

        public List<string> IncludeJSLib { get; set; }

        public abstract void Exec(FlowContext ctx);

        public string GetIncludeJsSnippet(FlowContext ctx)
        {
            string jsContent = ctx.GetInitScript();
            if (this.IncludeJSLib != null)
            {
                jsContent += JSLibHelper.GetJSLibContent(this.IncludeJSLib);
            }
            return jsContent;
        }

     
    }
}
