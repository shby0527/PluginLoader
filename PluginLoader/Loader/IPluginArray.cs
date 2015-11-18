using System;
using System.Diagnostics;
using System.Collections.Generic;
using PluginLoader.Plugins;

namespace PluginLoader.Loader
{
	public interface IPluginArray<out T>:IEnumerable<T>
		where T:class,IPlugin
	{
		#region this is get data to get plugin instance
		T this[int Index]{get;}
		T this [string Hash] {get;}
		#endregion
		/// <summary>
		/// Gets the plugin count.
		/// </summary>
		/// <value>The plugin count.</value>
		int PluginCount{ get;}
		/// <summary>
		/// Gets the name of the plugins.
		/// </summary>
		/// <returns>The plugins name.</returns>
		string[] GetPluginsName();

	}
}

