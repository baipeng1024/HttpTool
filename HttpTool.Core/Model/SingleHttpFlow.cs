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

        public List<AbsNode> Nodes { get; set; }

        public List<string> IncludeFlowJSLib { get; set; }

        public void Run(ILogger logger) {
          
            if (Nodes == null) {
                logger.Error("没有任何可执行节点");
                return;
            }
            logger.Infor("开始执行。。。");
            FlowContext ctx = new FlowContext();
            WebBrowser wb = ctx.GetWebBrowser();
            foreach (AbsNode node in Nodes)
            {                
                try
                {
                    node.Exec(ctx);
                    logger.Infor(string.Format("%s 节点执行结束", node.Name));
                }
                catch (Exception ex)
                {
                    logger.Error(string.Format("%s 节点执行异常，异常信息:%s",node.Name,ex.Message),ex);
                }
            }
            logger.Infor("执行结束。。。");

        }

     

    }
}
