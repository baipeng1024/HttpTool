using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HttpTool.Core.Model
{
    public interface IIncludeJsLibs
    {
        List<string> GetIncludeJSLibs();

        void SetIncludeJsLibs(List<string> jsLibs);


    }
}
