using System;
using System.Timers;

namespace testScript
{
	public class Script
	{
		public void Initialize()
		{
			Timer t = new Timer(1000) { Enabled = true };
			t.Elapsed += T_Elapsed;
		}

		public void Dispose()
		{
		}
		
		
		private static void T_Elapsed(object sender, ElapsedEventArgs e)
        {
            Console.WriteLine("herp derp");
        }
	}
}