using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HttpTool.Core.Model
{
    public class HttpNode : AbsNode
    {
        public override void Exec(FlowContext ctx)
        {
            throw new NotImplementedException();
        }

        public string RequestType { get; set; }

        /**
        * 处理请求的脚本
        *
        **/
        public string HandleRequestScript { get; set; }


        /**
        * 处理响应的脚本
        *
        **/
        public string HandleResponseScript { get; set; }


        
        public string RequestUrlFunctionName { get; set; }


        /**
        * 请求参数串的方法名称
        *
        **/
        public string RequestParsStrFunctionName { get; set; }
    }
}
