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
    public class JSNode : AbsFlowNode
    {
        public JSNode(string id):base(id){ 
         
        }

        public JSNode() { }

        public string Js { get; set; }

        public override void Exec(FlowContext ctx)
        {
            base.Exec(ctx);
            if (string.IsNullOrEmpty(this.Js)) {
                return;
            }

            WebBrowser wb = ctx.GetWebBrowser();
            string jsContent = this.GetIncludeJsSnippet(ctx);

            string funName = "f" + Guid.NewGuid().ToString().Replace("-", "");
            string jsFun = "function "+ funName +"(){"+ this.Js +" };";
            string content = string.Format("<!DOCTYPE html><html><head> <title></title></head><body><script type=\"text/javascript\"> {0} \n {1} \n</script></body></html>", jsContent, jsFun);
            Tool.SetWebBrowserDocumentText(wb, content);

            object[] args = { ctx.JsCtx };
            HtmlDocument doc = wb.Document;
            doc.InvokeScript(FlowContext.INIT_JS_CTX_FUN_NAME, args);
            doc.InvokeScript(funName);
            ctx.JsCtx = doc.InvokeScript(FlowContext.GET_JS_CTX_FUN_NAME);
            
            while (wb.ReadyState != WebBrowserReadyState.Complete) Application.DoEvents();

            if (this.NextNode != null) {
                this.NextNode.Exec(ctx);
            }
        }

   

        

    }
}
