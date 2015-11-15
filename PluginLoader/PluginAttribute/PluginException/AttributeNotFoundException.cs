using System;

namespace PluginLoader.PluginAttribute.PluginException
{
	/// <summary>
	/// Attribute not found exception.
	/// </summary>
	public sealed class AttributeNotFoundException : Exception
	{
		/// <summary>
		/// get a message,this is Adv.
		/// </summary>
		/// <value>The get adv.</value>
		public string GetAdv{
			get{
				return "This class maybe not a plugin,if it is,please check this have plugin attribute?";
			}
		}
		/// <summary>
		/// Initializes a new instance of the
		/// <see cref="PluginLoader.PluginAttribute.PluginException.AttributeNotFoundException"/> class.
		/// </summary>
		public AttributeNotFoundException ():
			base("Plugin Information Attribute Not Found")
		{

		}
	}
}

