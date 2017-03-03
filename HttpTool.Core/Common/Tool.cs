using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace HttpTool.Core.Common
{
    public class Tool
    {

        public static WebBrowser SetWebBrowserDocumentText(WebBrowser wb,string html) {

            wb.DocumentText = string.Empty;
            wb.Document.OpenNew(false);
            wb.Document.Write(html);
            
            return wb;

        }

        public static HtmlDocument AppendJavaScriptSnippet(HtmlDocument doc, string jsSnippet)
        {
            HtmlElementCollection eles = doc.GetElementsByTagName("html");
            if (eles == null || eles.Count == 0) {
                throw new Exception("Tool.AppendJavaScriptSnippet failure:no html element.");
            }

            HtmlElement htmlEle = eles[0];
            HtmlElement jsEle = doc.CreateElement("script");
            jsEle.SetAttribute("text", jsSnippet);
            htmlEle.AppendChild(jsEle);
            return doc;
        }


        

    }
}
