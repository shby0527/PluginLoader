using System;
/// <summary>
/// I plugin.
/// </summary>
namespace PluginLoader.Plugins
{
	/// <summary>
	/// I plugin.
	/// signed interface
	/// </summary>
	public interface IPlugin
	{
		/// <summary>
		/// the plugin is loading
		/// </summary>
		/// <returns><c>true</c>Loading success<c>false</c>otherwise</returns>
		bool Loading();
		/// <summary>
		/// the plugin is unloading
		/// </summary>
		/// <returns><c>true</c> Unloading success<c>false</c> otherwise.</returns>
		bool UnLoading();
	}
}

