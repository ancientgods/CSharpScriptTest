using System;
using CSScriptLibrary;

using System.Timers;

namespace Test
{
    class Solution
    {
        static void Main(String[] args)
        {
            ScriptContainer container = new ScriptContainer(AppDomain.CurrentDomain.Clone(), "Script.cs");

            container.Dispose();

            Console.ReadLine();
        }
    }
}