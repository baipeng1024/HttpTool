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

  


    /**
     * 流程上下文
     * */
    public class FlowContext
    {
        private class Navigation
        {
            public Navigation(FlowContext ctx,string url, byte[] parsData)
            {
                this.Ctx = ctx;
                this.Uri = new Uri(url);
                this.ParsData = parsData;
            }

           public FlowContext Ctx { get; set; }

           public Uri Uri { get; set; }

           public byte[] ParsData { get; set; }
        }


        public static readonly string INIT_JS_CTX_FUN_NAME = "httpToolInitJsCtx_" + System.Guid.NewGuid().ToString().Replace("-", "");

        public static readonly string GET_JS_CTX_FUN_NAME = "httpToolGetJsCtx" + System.Guid.NewGuid().ToString().Replace("-", "");

        private static readonly string CTX_INIT = "\n var SYS_CTX;function " + INIT_JS_CTX_FUN_NAME + "(ctx){  SYS_CTX = ctx;};function " + GET_JS_CTX_FUN_NAME + "(){return SYS_CTX;};";

        private WebBrowser wb;

        private volatile bool isSuspend;

        public ILogger Logger { get; set; }

        public object JsCtx { get; set; }

        public string IncludeJSContent { get; set; }


        public void Init(WebBrowser wb, List<string> IncludeJSLib)
        {
            
            this.wb = wb;
            Control.CheckForIllegalCrossThreadCalls = false;
            if (IncludeJSLib != null)
            {
                this.IncludeJSContent = JSLibHelper.GetJSLibContent(IncludeJSLib);
            }

            Tool.SetWebBrowserDocumentText(wb, "<!DOCTYPE html><html><head> <title></title></head><body><script type=\"text/javascript\">var SYS_CTX = {};function getJsCtx(){return SYS_CTX;};</script></body></html>");
            this.JsCtx = this.wb.Document.InvokeScript("getJsCtx");
        }
        public WebBrowser GetWebBrowser()
        {
            return this.wb;
        }

        public string GetInitScript()
        {
            return this.IncludeJSContent == null ? CTX_INIT : this.IncludeJSContent + CTX_INIT;
        }


        public bool Navigate(string url,byte[] parsData) {
            
            this.isSuspend = true;
            Thread t = new Thread(new ParameterizedThreadStart(Navigate));
            t.IsBackground = true;
            t.Start(new Navigation(this,url,parsData));

            while (this.isSuspend)
            {
                Thread.Sleep(10);
            }

            return true;
        
        }

        static void Navigate(object o) {

            Navigation ngn = (Navigation)o;
            WebBrowser wb = ngn.Ctx.GetWebBrowser();
            wb.Tag = ngn.Ctx;
            wb.DocumentCompleted += wb_DocumentCompleted;
            try
            {
                if (ngn.ParsData == null)
                {
                    wb.Navigate(ngn.Uri);
                }
                else {
                    wb.Navigate(ngn.Uri,null,ngn.ParsData,null);
                }
            }
            catch (Exception ex)
            {
                wb.DocumentCompleted -= wb_DocumentCompleted;
                throw;
            }
           
        
        }

        static void wb_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            WebBrowser wb = (WebBrowser)sender;
            FlowContext ctx = (FlowContext)wb.Tag;
            wb.Tag = null;
            wb.DocumentCompleted -= wb_DocumentCompleted;
            ctx.isSuspend = false;
        }
    }
}
