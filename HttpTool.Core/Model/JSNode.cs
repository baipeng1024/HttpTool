using HttpTool.Core.JS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using HttpTool.Core.Common;

namespace HttpTool.Core.Model
{
    public class JSNode : AbsNode
    {
        public JSNode(string id):base(id){ 
         
        }

        public JSNode() { }

        public string JS { get; set; }

        public override void Exec(FlowContext ctx)
        {
            if (string.IsNullOrEmpty(this.JS)) {
                return;
            }

            WebBrowser wb = ctx.GetWebBrowser();
            string jsContent = this.GetIncludeJsSnippet(ctx);

            string funName = "f" + Guid.NewGuid().ToString().Replace("-", "");
            string jsFun = "function "+ funName +"(){"+ this.JS +" };";
            string content = string.Format("<!DOCTYPE html><html><head> <title></title></head><body><script type=\"text/javascript\"> {0} \n {1} \n</script></body></html>", jsContent, jsFun);
            Tool.SetWebBrowserDocumentText(wb, content);

            object[] args = { ctx.JsCtx };
            HtmlDocument doc = wb.Document;
            doc.InvokeScript(FlowContext.INIT_JS_CTX_FUN_NAME, args);
            doc.InvokeScript(funName);
            ctx.JsCtx = doc.InvokeScript(FlowContext.GET_JS_CTX_FUN_NAME);

            if (this.NextNode != null) {
                this.NextNode.Exec(ctx);
            }
        }

   

        

    }
}
