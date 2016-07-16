using HttpTool.Core.JS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HttpTool.Core.Model
{
    public class JSNode : AbsNode
    {

        public string JS { get; set; }

        public override void Exec(FlowContext ctx)
        {
            if (string.IsNullOrEmpty(this.JS)) {
                return;
            }

            WebBrowser wb = ctx.GetWebBrowser();           
            string jsContent = ctx.GetInitScript();
            if (this.IncludeJSLib != null) {
               jsContent += JSLibHelper.GetJSLibContent(this.IncludeJSLib);        
            }

            string funName = Guid.NewGuid().ToString();
            string jsFun = "function "+ funName +"(){\n "+ this.JS +" \n}\n";
            string content = string.Format("<!DOCTYPE html><html><head> <title></title></head><body><script type=\"text/javascript\"> {0} \n {1} </script></body></html>", jsContent, jsFun);
            
            wb.Navigate("about:blank");
            wb.DocumentText = content;
            object[] args = { ctx.JsCtx };
            HtmlDocument doc = wb.Document;
            doc.InvokeScript(FlowContext.INIT_JS_CTX_FUN_NAME, args);
            doc.InvokeScript(funName);
            ctx.JsCtx = doc.InvokeScript(FlowContext.GET_JS_CTX_FUN_NAME);

            if (this.NexNode != null) {
                this.NexNode.Exec(ctx);
            }
        }

    }
}
