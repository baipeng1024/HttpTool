using HttpTool.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace HttpTool.Core.Model
{

    public class SingleHttpFlow
    {


        public string Name { get; set; }

        public string Desc { get; set; }

        public AbsNode HeadNode { get; set; }

        public List<string> IncludeJSLib { get; set; }

        public FlowContext Run(ILogger logger)
        {

            if (logger == null)
            {
                logger = new DefaultLogger();
            }

            if (HeadNode == null)
            {
                logger.Error("没有任何可执行节点");
                return null;
            }

            FlowContext ctx = new FlowContext();
            Thread t = new Thread(() =>
            {

                try
                {
                    ctx.Init(new WebBrowser(), IncludeJSLib);
                    ctx.Logger = logger;
                    ctx.Logger.Infor("开始执行。。。");
                    HeadNode.Exec(ctx);
                }
                catch (Exception ex)
                {
                    ctx.Logger.Error(string.Format("{0} 节点执行异常，异常信息:{1}", HeadNode.Name, ex.Message), ex);
                }

                ctx.Logger.Infor("执行结束。。。");

            });
            t.SetApartmentState(ApartmentState.STA);
            t.Start();

            return ctx;

        }



    }
}
