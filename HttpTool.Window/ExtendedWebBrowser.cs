using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
 

namespace HttpTool.Window
{
    public class ExtendedWebBrowser : WebBrowser
    {
        public ExtendedWebBrowser()
        {
            DocumentCompleted += SetupBrowser;

            //this will cause SetupBrowser to run (we need a document object)
            Navigate("about:blank");
        }

        void SetupBrowser(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            DocumentCompleted -= SetupBrowser;
            SHDocVw.WebBrowser xBrowser = (SHDocVw.WebBrowser)ActiveXInstance;
            xBrowser.BeforeNavigate2 += BeforeNavigate;
            DocumentCompleted += PageLoaded;
            
        }

        void PageLoaded(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }

        void BeforeNavigate(object pDisp, ref object url, ref object flags, ref object targetFrameName,
            ref object postData, ref object headers, ref bool cancel)
        {
            headers += string.Format("Host: {0}\r\n", "test.jd.com");
        }
    }
}
