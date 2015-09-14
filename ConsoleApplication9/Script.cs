using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSScriptLibrary;
using System.Reflection;

namespace Test
{
    public interface Script
    {

        void Initialize();

        void Dispose();
    }
}
