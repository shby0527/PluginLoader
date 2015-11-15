using System;
/// <summary>
/// Dinger info attribute.
/// 该文件基于GPLv2
/// </summary>
namespace PluginLoader.PluginAttribute
{
	/// <summary>
	/// Dinger info attribute.
	/// </summary>
	[AttributeUsage(AttributeTargets.Class,AllowMultiple = true,Inherited = true)]
	public class DingerInfoAttribute:Attribute
	{
		/// <summary>
		/// Gets or sets the name.
		/// </summary>
		/// <value>The name.</value>
		public string Name{ get; set;}
		/// <summary>
		/// Gets or sets the phone.
		/// </summary>
		/// <value>The phone.</value>
		public string Phone{ get; set;}
		/// <summary>
		/// Gets or sets the E mail.
		/// </summary>
		/// <value>The E mail.</value>
		public string EMail{ get; set;}
		/// <summary>
		/// Gets or sets the address.
		/// </summary>
		/// <value>The address.</value>
		public string Address{ get; set;}
		/// <summary>
		/// Initializes a new instance of the <see cref="PluginLoader.PluginAttribute.DingerInfoAttribute"/> class.
		/// </summary>
		public DingerInfoAttribute ()
		{
			this.Name ="GPL";
			this.Phone = "";
			this.EMail = "";
			this.Address = "";
		}
	}
}

