using System;
using System.Reflection;
namespace PluginLoader.Loader
{
	internal struct PluginInfo : IComparable<PluginInfo>,IComparable
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

		#region IComparable implementation
		/// <Docs>To be added.</Docs>
		/// <para>Returns the sort order of the current instance compared to the specified object.</para>
		/// <summary>
		/// Compares to.
		/// </summary>
		/// <returns>The to.</returns>
		/// <param name="other">Other.</param>
		public int CompareTo (PluginInfo other)
		{
			return  this.PluginPriority - other.PluginPriority;
		}

		#endregion

		#region IComparable implementation
		/// <Docs>To be added.</Docs>
		/// <para>Returns the sort order of the current instance compared to the specified object.</para>
		/// <summary>
		/// Compares to.
		/// </summary>
		/// <returns>The to.</returns>
		/// <param name="obj">Object.</param>
		public int CompareTo (object obj)
		{
			return this.PluginPriority -  ((PluginInfo)obj).PluginPriority;
		}

		#endregion
	}
}

