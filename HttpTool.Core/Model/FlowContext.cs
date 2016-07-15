using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HttpTool.Core.Model
{
    /**
     * 流程上下文
     * */
    public class FlowContext
    {

        public const string INIT_JS_CTX_FUN_NAME = "httpToolInitJsCtx";

        public const string GET_JS_CTX_FUN_NAME = "httpToolGetJsCtx";
       
        public FlowContext() {
            this.wb = new WebBrowser();
        }

        private WebBrowser wb;

        public WebBrowser GetWebBrowser() {
            return this.wb;
        }

        public object JsCtx { get; set; }


        public string GetInitScript() {
            return "var SYS_CTX;\n function " + INIT_JS_CTX_FUN_NAME + "(ctx){  SYS_CTX = ctx;}\n function " + GET_JS_CTX_FUN_NAME + "(){return SYS_CTX;}\n";
        }
         


    }
}
