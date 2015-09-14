using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using CSScriptLibrary;

namespace Test
{
    public class ScriptContainer : IDisposable
    {
        public static Dictionary<string, Script> Scripts = new Dictionary<string, Script>();
        public Script Script { get { return Scripts.ContainsKey(_name) ? Scripts[_name] : null; } }
        private string _name;
        public string Name { get { return _name; } }
        private AppDomain _appDomain;


        public ScriptContainer(AppDomain domain, string name)
        {
            _name = name;
            _appDomain = domain;

            _appDomain.Execute<string>(Initialize, name);
        }

        public static void Initialize(string scriptName)
        {
            try
            {

                Script script = CSScript.Evaluator.LoadFile<Script>(scriptName);
                script.Initialize();

                Scripts.Add(scriptName, script);
                foreach (KeyValuePair<string, Script> kvp in Scripts)
                    Console.WriteLine(kvp.Key);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Invalid Script format!");
                Console.WriteLine(ex.ToString());
            }
        }

        public void Dispose()
        {
            Console.WriteLine(Scripts.Count);

            foreach (KeyValuePair<string, Script> kvp in Scripts)
                Console.WriteLine(kvp.Key);

            Console.WriteLine("test");
            if (Script != null)
            {
                Console.WriteLine("test 2");
                Script.Dispose();
                Scripts.Remove(Name);
            }
            _appDomain.Unload();
        }
    }
}
