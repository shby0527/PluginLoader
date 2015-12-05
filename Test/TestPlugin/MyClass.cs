using System;
using System.IO;
using Test;
using PluginLoader.PluginAttribute;
namespace TestPlugin
{
	[PluginInfo("1625F2E078F4216D1BFCA925E68DE795CC0C5FDD62B312D0C22135D211AF86BA",1,Name = "Test")]
	public class MyPlugin :TestPluginFather
	{
		#region implemented abstract members of TestPluginFather

		public override bool Loading ()
		{
			StreamWriter sw = File.AppendText ("./logfile.log");
			sw.WriteLine ("I am loaded MyPlugin");
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

	[PluginInfo("5BE3BB75CF8873EBC8C131955C54B4BC85BFBBE8DB6CCB134AABFAEEF302D80A",5)]
	public class MyPluginA :TestPluginFather
	{
		#region implemented abstract members of TestPluginFather

		public override bool Loading ()
		{
			StreamWriter sw = File.AppendText ("./logfile.log");
			sw.WriteLine ("I am loaded MyPluginA");
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
	//if the same GUID
	[PluginInfo("5BE3BB75CF8873EBC8C131955C54B4BC85BFBBE8DB6CCB134AABFAEEF302D80A",9)]
	public class MyPluginB :TestPluginFather
	{
		#region implemented abstract members of TestPluginFather

		public override bool Loading ()
		{
			StreamWriter sw = File.AppendText ("./logfile.log");
			sw.WriteLine ("I am loaded MyPluginB");
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

	[PluginInfo("205CC095FB9EA3F3E2D0C1F52551788CA55426C37AB085B88CAC2E33C453512F",-5,Author = "umi")]
	public class MyPluginC :TestPluginFather
	{
		#region implemented abstract members of TestPluginFather

		public override bool Loading ()
		{
			StreamWriter sw = File.AppendText ("./logfile.log");
			sw.WriteLine ("I am loaded MyPluginC");
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

