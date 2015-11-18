using System;
using System.IO;
using Test;
using PluginLoader.PluginAttribute;
namespace TestPlugin
{
	[PluginInfo("1625F2E078F4216D1BFCA925E68DE795CC0C5FDD62B312D0C22135D211AF86BA",1)]
	public class MyPlugin :TestPluginFather
	{
		#region implemented abstract members of TestPluginFather

		public override bool Loading ()
		{
			StreamWriter sw = File.AppendText ("./logfile.log");
			sw.WriteLine ("I am loaded");
			sw.Close ();
			return true;
		}

		public override bool UnLoading ()
		{
			Console.WriteLine ("I am unloading");
			return true;
		}

		#endregion
	}
}

