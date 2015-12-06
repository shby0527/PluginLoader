using System;
using PluginLoader.Plugins;
using PluginLoader.Loader;
using PluginLoader.Configure;

//we should not reference TestPlugin
namespace Test
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			IPluginArray<TestPluginFather> arr = PluginLoader<TestPluginFather>.Load ("./plugins");
			if (arr.PluginCount == 0) 
				return;
			foreach (TestPluginFather i in arr) {
				ConfigureManager cfg = new ConfigureManager (i);
				cfg["w"] = "q";
				cfg["url"] = "http=uuusss=jjj";
				cfg.SaveAllConfig ();
			}
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
