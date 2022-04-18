using StarPeace.Admin.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarPeace.Admin.Services
{
    public interface IApiCall
    {
        string AssemblyName { get; set; }
        string ClassName { get; set; }
        string MethodName { get; set; }
        List<string> Parameters { get; set; }

        void Interpret(InterpreterContext context);
    }
}
