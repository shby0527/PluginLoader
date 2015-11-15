using System;
using System.Reflection;
namespace PluginLoader.Loader
{
	internal struct PluginInfo
	{
		/// <summary>
		/// Gets or sets the name of the plugin full.
		/// </summary>
		/// <value>The name of the plugin full.</value>
		public string PluginFullName{ get;internal set;}
		/// <summary>
		/// Gets or sets the plugin GUI.
		/// </summary>
		/// <value>The plugin GUI.</value>
		public string PluginGUID{ get; internal set;}
		/// <summary>
		/// Gets or sets the plugin priority.
		/// </summary>
		/// <value>The plugin priority.</value>
		public int PluginPriority{ get; internal set;}
		/// <summary>
		/// Gets or sets the plugin assembly.
		/// </summary>
		/// <value>The plugin assembly.</value>
		public Assembly PluginAssembly{ get;internal set;}
	}
}

