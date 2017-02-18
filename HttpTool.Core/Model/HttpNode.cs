using HttpTool.Core.Common;
using HttpTool.Core.JS;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace HttpTool.Core.Model
{


    public class HttpNode : AbsFlowNode
    {

        public HttpNode(string id)
            : base(id)
        {

        }

        public HttpNode() { }

        public string InitRequestJs { get; set; }

        public string OnLoadJs { get; set; }

        public override void Exec(FlowContext ctx)
        {

            base.Exec(ctx);
            WebBrowser wb = ctx.GetWebBrowser();
            string jsContent = this.GetIncludeJsSnippet(ctx);

            string insertJs = "var request = {};\r\n";
            string appendJs = "\r\nfunction getUrl(){return request.url;};\r\nfunction getType(){return request.type;};\r\nfunction getHeaders(){return request.headers;};\r\nfunction getPostPars(){return request.postPars;};";
            string content = string.Format("<!DOCTYPE html><html><head> <title></title></head><body><script type=\"text/javascript\"> {0} \r\n {1} \r\n {2} \r\n{3}</script></body></html>", jsContent, insertJs, InitRequestJs, appendJs);
            Tool.SetWebBrowserDocumentText(wb, content);

            object[] args = { ctx.JsCtx };
            HtmlDocument doc = wb.Document;
            doc.InvokeScript(FlowContext.INIT_JS_CTX_FUN_NAME, args);

            string url = "", type = "", headers = "", postPars = "";
            object urlO = doc.InvokeScript("getUrl");
            object typeO = doc.InvokeScript("getType");
            object headersO = doc.InvokeScript("getHeaders");
            object postParsO = doc.InvokeScript("getPostPars");

            if (urlO != null) { url = urlO.ToString(); }
            if (typeO != null) { type = typeO.ToString(); }
            if (headersO != null){ headers = headersO.ToString();}
            if (postParsO != null) { postPars = postParsO.ToString(); }


            ctx.JsCtx = doc.InvokeScript(FlowContext.GET_JS_CTX_FUN_NAME);

            if (type.ToLower().Trim() == "post")
            {
                wb.Navigate(url, null, UTF8Encoding.UTF8.GetBytes(postPars), null);
            }
            else
            {
                wb.Navigate(url);
            }


            while (wb.ReadyState != WebBrowserReadyState.Complete) Application.DoEvents();

            string includeJsSnippet = this.GetIncludeJsSnippet(ctx);
            string funName = "f" + Guid.NewGuid().ToString().Replace("-", "");
            string fun = includeJsSnippet + "\n function " + funName + "(){ " + OnLoadJs + " };";
            Tool.AppendJavaScriptSnippet(doc, fun);
            doc.InvokeScript(FlowContext.INIT_JS_CTX_FUN_NAME, args);
            doc.InvokeScript(funName);

            ctx.JsCtx = doc.InvokeScript(FlowContext.GET_JS_CTX_FUN_NAME);
            
            while (wb.ReadyState != WebBrowserReadyState.Complete) Application.DoEvents();

            if (this.NextNode != null)
            {
                this.NextNode.Exec(ctx);
            }
        }




    }
}
