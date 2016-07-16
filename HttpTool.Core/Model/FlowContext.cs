﻿using HttpTool.Core.Common;
using HttpTool.Core.JS;
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

        public static readonly string INIT_JS_CTX_FUN_NAME = "httpToolInitJsCtx_" + System.Guid.NewGuid().ToString();

        public static readonly string GET_JS_CTX_FUN_NAME = "httpToolGetJsCtx" + System.Guid.NewGuid().ToString();

        private static readonly string CTX_INIT = "\n var SYS_CTX;\n function " + INIT_JS_CTX_FUN_NAME + "(ctx){  SYS_CTX = ctx;}\n function " + GET_JS_CTX_FUN_NAME + "(){return SYS_CTX;}\n";

        private WebBrowser wb;

        public ILogger Logger { get; set; }

        public object JsCtx { get; set; }

        public string IncludeJSContent { get; set; }


        public void Init(WebBrowser wb,List<string> IncludeJSLib)
        {

            this.wb = wb;
            this.JsCtx = new object();
            if (IncludeJSLib != null)
            {
                this.IncludeJSContent = JSLibHelper.GetJSLibContent(IncludeJSLib);
            }

        }
        public WebBrowser GetWebBrowser()
        {
            return this.wb;
        }

        public string GetInitScript()
        {
            return this.IncludeJSContent == null ? CTX_INIT : this.IncludeJSContent + CTX_INIT;
        }



    }
}
