using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;
using Newtonsoft.Json;
using System.IO;
using StarPeace.Admin.Contexts;
using StarPeace.Admin.Services;


namespace StarPeace.Admin.Helpers
{
    public class ApiCall : IApiCall
    {
        public string AssemblyName { get; set; }
        public string ClassName { get; set; }
        public string MethodName { get; set; }
        public List<string> Parameters { get; set; }

        public void Interpret(InterpreterContext context)
        {
            Assembly assembly = Assembly.LoadFile(context.AssemblyStore + $"\\{AssemblyName}");
            Type type = assembly.GetType(ClassName);
            object obj = Activator.CreateInstance(type, context.BasePath);
            MethodInfo method = type.GetMethod(MethodName);
            method.Invoke(obj, Parameters.ToArray());
        }
    }
}
