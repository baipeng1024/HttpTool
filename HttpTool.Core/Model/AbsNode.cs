using HttpTool.Core.JS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HttpTool.Core.Model
{
    public abstract class AbsNode : IIncludeJsLibs
    {

        public AbsNode()
        {

            this.id = Guid.NewGuid().ToString();
        }


        public AbsNode(string id)
        {
            this.id = id;
        }

        private string id;
        public string GetId()
        {
            return id;
        }

        public string Name { get; set; }

        public string Desc { get; set; }
        public AbsNode NextNode { get; set; }

        public List<string> includeJSLibs;

        public abstract void Exec(FlowContext ctx);

        public string GetIncludeJsSnippet(FlowContext ctx)
        {
            string jsContent = ctx.GetInitScript();
            if (this.includeJSLibs != null)
            {
                jsContent += JSLibHelper.GetJSLibContent(this.includeJSLibs);
            }
            return jsContent;
        }


        public List<string> GetIncludeJSLibs()
        {
            return this.includeJSLibs;
        }

        public void SetIncludeJsLibs(List<string> jsLibs)
        {
            this.includeJSLibs = jsLibs;
        }
    }
}
