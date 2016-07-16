using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HttpTool.Core.Model
{
    public class BindHostHttpNode : HttpNode
    {

        /**
         * 
         *是否迭代，若迭代，将按照IP列表来执行后续的节点 
         **/
        public bool IsIteration { get; set; }


        /**
        * 
        *获取IP列表的方法名称
        **/
        public string FunctionNameOfIPArray { get; set; }
    }
}
