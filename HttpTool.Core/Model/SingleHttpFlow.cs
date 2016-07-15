using HttpTool.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HttpTool.Core.Model
{

    public class SingleHttpFlow
    {


        public string Name { get; set; }

        public string Desc { get; set; }

        public AbsNode HeadNode { get; set; }

        public List<string> IncludeFlowJSLib { get; set; }

        public void Run(ILogger logger)
        {

            if (logger == null)
            {
                logger = new DefaultLogger();
            }

            if (HeadNode == null)
            {
                logger.Error("没有任何可执行节点");
                return;
            }
            FlowContext ctx = new FlowContext();
            ctx.Logger = logger;
            ctx.Logger.Infor("开始执行。。。");
            WebBrowser wb = ctx.GetWebBrowser();
            try
            {
                HeadNode.Exec(ctx);
            }
            catch (Exception ex)
            {
                ctx.Logger.Error(string.Format("%s 节点执行异常，异常信息:%s", HeadNode.Name, ex.Message), ex);
            }
            ctx.Logger.Infor("执行结束。。。");

        }



    }
}
