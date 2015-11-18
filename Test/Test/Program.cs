using System;
using PluginLoader.Plugins;
using PluginLoader.Loader;
//we should not reference TestPlugin
namespace Test
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			IPluginArray<TestPluginFather> arr =  PluginLoader<TestPluginFather>.Load ("./plugins");
			TestPluginFather w = arr [0];
			Console.WriteLine (arr.PluginCount);
		}
	}
	public abstract class TestPluginFather :IPlugin
	{

		#region IPlugin implementation

		public abstract bool Loading ();

		public abstract bool UnLoading ();

		#endregion
	}
}
