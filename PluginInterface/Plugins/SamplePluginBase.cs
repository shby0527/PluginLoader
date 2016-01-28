using System;
using PluginLoader.Plugins;

namespace PluginInterface.Plugins
{
	/// <summary>
	/// Sample plugin base.
	/// it is the sample base plugin
	/// </summary>
	public abstract class SamplePluginBase:IPlugin
	{
		protected SamplePluginBase ()
		{
		}

		public virtual bool Loading()
		{
			return true;
		}

		public virtual bool UnLoading()
		{
			return true;
		}
		/// <summary>
		/// Start the specified args.
		/// </summary>
		/// <param name="args">Arguments.</param>
		public virtual void Start(object[] args)
		{
		}
	}
}

