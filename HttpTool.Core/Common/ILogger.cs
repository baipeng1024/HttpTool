using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HttpTool.Core.Common
{
    public interface ILogger
    {
        void Infor(string log);

        void Error(string log);

        void Error(string log,Exception ex);
        
        
    }
}
