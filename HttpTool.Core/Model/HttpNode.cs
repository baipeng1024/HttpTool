using HttpTool.Core.Common;
using HttpTool.Core.JS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace HttpTool.Core.Model
{

    
    public class HttpNode : AbsNode
    {

        public string RequestType { get; set; }

        /**
        * 处理请求的脚本
        *
        **/
        public string ScriptOfHandleRequest { get; set; }


        /**
        * 处理响应的脚本
        *
        **/
        public string ScriptOfHandleResponse { get; set; }



        public string FunctionNameOfRequestUrl { get; set; }


        /**
        * post请求参数串的方法名称
        *
        **/
        public string FunctionNameOfPostParsStr { get; set; }

        public override void Exec(FlowContext ctx)
        {
           
            bool isGet = this.RequestType.ToLower() == "get";
            WebBrowser wb = ctx.GetWebBrowser();
            string jsContent = this.GetIncludeJsSnippet(ctx);

            string handleRequestFunName = "f" + Guid.NewGuid().ToString().Replace("-", "");
            string requestCtxJs = "var requestCtx = {url:'',parsStr:''};function getUrl(){return requestCtx.url;};function getParsStr(){return requestCtx.parsStr;};";
            string handleRequestFun = "function " + handleRequestFunName + "(){" + this.ScriptOfHandleRequest + "\n requestCtx.url =" + this.FunctionNameOfRequestUrl.Trim() + "();\n";
            if (!(isGet || string.IsNullOrEmpty(this.FunctionNameOfPostParsStr)))
            {
                handleRequestFun += "requestCtx.parsStr = " + this.FunctionNameOfPostParsStr.Trim() + "();\n";
            }
            handleRequestFun += "};";
            string content = string.Format("<!DOCTYPE html><html><head> <title></title></head><body><script type=\"text/javascript\"> {0} \n {1} \n {2} \n</script></body></html>", jsContent, requestCtxJs, handleRequestFun);
            Tool.SetWebBrowserDocumentText(wb, content);

            object[] args = { ctx.JsCtx };
            HtmlDocument doc = wb.Document;
            doc.InvokeScript(FlowContext.INIT_JS_CTX_FUN_NAME, args);
            doc.InvokeScript(handleRequestFunName);
            string url = doc.InvokeScript("getUrl").ToString();
            string parsStr = doc.InvokeScript("getParsStr").ToString();
            ctx.JsCtx = doc.InvokeScript(FlowContext.GET_JS_CTX_FUN_NAME);

            if (string.IsNullOrEmpty(parsStr))
            {
                wb.Navigate(url);
            }
            else {
                wb.Navigate(url, null,UTF8Encoding.UTF8.GetBytes(parsStr),null);
            }


            while (wb.ReadyState != WebBrowserReadyState.Complete) Application.DoEvents();

            if (string.IsNullOrEmpty(this.ScriptOfHandleResponse))
            {
                return;
            }
            string includeJsSnippet = this.GetIncludeJsSnippet(ctx);
            string funName = "f" + Guid.NewGuid().ToString().Replace("-", "");
            string fun = includeJsSnippet + "\n function " + funName + "(){ " + this.ScriptOfHandleResponse + " };";
            Tool.AppendJavaScriptSnippet(doc, fun);
            doc.InvokeScript(FlowContext.INIT_JS_CTX_FUN_NAME, args);
            doc.InvokeScript(funName);
            ctx.JsCtx = doc.InvokeScript(FlowContext.GET_JS_CTX_FUN_NAME);

            if (this.NexNode != null) {
                this.NexNode.Exec(ctx);
            }
        }

       


    }
}
