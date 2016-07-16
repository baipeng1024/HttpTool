using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HttpTool.Core.Common
{
    public class DefaultLogger : ILogger
    {

        public void Infor(string log)
        {
            Console.WriteLine(string.Format("{0}[infor]:{1}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), log));
        }

        public void Error(string log)
        {
            Console.WriteLine(string.Format("{0}[error]:{1}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), log));
        }

        public void Error(string log, Exception ex)
        {
            if (ex == null)
            {
                Error(log);
            }
            else
            {
                Console.WriteLine(string.Format("{0}[error]:{1},exception:{2}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), log, ex.Message));
            }

        }
    }
}
