using HttpTool.Core.JS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HttpTool.Core.Model
{
    public abstract class AbsFlowNode : IIncludeJsLibs
    {

        public AbsFlowNode()
        {

            this.id = Guid.NewGuid().ToString();
        }


        public AbsFlowNode(string id)
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
        public AbsFlowNode NextNode { get; set; }

        public List<string> includeJSLibs;

        public virtual void Exec(FlowContext ctx) {
            ctx.Logger.Infor(string.Format("节点:{0}开始执行....",Name));
         
        }

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
