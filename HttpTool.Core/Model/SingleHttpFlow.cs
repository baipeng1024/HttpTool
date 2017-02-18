using HttpTool.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace HttpTool.Core.Model
{

    public class SingleHttpFlow : AbsFlowNode
    {

        public SingleHttpFlow(string id)
            : base(id)
        {

        }

        public SingleHttpFlow() { }

        public AbsFlowNode HeadNode { get; set; }


        public override void Exec(FlowContext ctx)
        {
            try
            {
                ctx.Logger.Infor("开始执行。。。");
                HeadNode.Exec(ctx);
            }
            catch (Exception ex)
            {
                ctx.Logger.Error(string.Format("{0} 节点执行异常，异常信息:{1}", this.Name, ex.Message), ex);
            }
            ctx.Logger.Infor("执行结束。。。");

        }

        public FlowContext Run(WebBrowser wb, ILogger logger)
        {

            if (logger == null)
            {
                logger = new DefaultLogger();
            }

            FlowContext ctx = new FlowContext();
            ctx.Logger = logger;
            ctx.Init(wb, includeJSLibs);

            try
            {
                Exec(ctx);
            }
            catch (Exception ex)
            {
                ctx.Logger.Error(string.Format("流程执行异常，异常信息:{0}", ex.Message), ex);
            }


            return ctx;
        }

        public void AppendNode(AbsFlowNode node)
        {
            if (HeadNode == null)
            {
                HeadNode = node;
            }
            else
            {
                AbsFlowNode tempNode = HeadNode;
                while (tempNode.NextNode != null) { tempNode = tempNode.NextNode; }
                tempNode.NextNode = node;
            }

        }

        public void RemoveNode(AbsFlowNode node)
        {
            AbsFlowNode tempNode = HeadNode;
            while (tempNode.NextNode != null)
            {
                if (tempNode.NextNode == node)
                {
                    node.NextNode = tempNode.NextNode.NextNode;
                    tempNode.NextNode = node;
                    return;
                }
                tempNode = tempNode.NextNode;
            }
        }

    }
}
