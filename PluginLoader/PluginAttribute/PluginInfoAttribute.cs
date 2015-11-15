using System;
/// <summary>
/// this is a Plugins Information Attribute
/// this attribute is signed the plugin globe
/// unique information
/// this file is release in GPLv2
/// 这是一个描述插件基础信息的特性类
/// 该信息因该是具有唯一性的
/// 这个文件发布与GPLv2
/// 你可以随意在发布以及分发
/// 但是请保留该声明
/// </summary>
namespace PluginLoader.PluginAttribute
{
	/// <summary>
	/// Plugin infomation attribute.
	/// </summary>
	[AttributeUsage(AttributeTargets.Class,AllowMultiple = false,Inherited = true)]
	public class PluginInfoAttribute:Attribute
	{
		/// <summary>
		/// Gets the author.
		/// </summary>
		/// <value>The author.</value>
		public string Author{ get; set;}
		/// <summary>
		/// Gets the version.
		/// </summary>
		/// <value>The version.</value>
		public string Version{ get;set;}
		/// <summary>
		/// Gets the GUI.
		/// </summary>
		/// <value>The GUI.</value>
		public string GUID{ get;set;}
		/// <summary>
		/// Gets the priority.
		/// </summary>
		/// <value>The priority.</value>
		public int Priority{ get; set;}
		/// <summary>
		/// Gets or sets the name.
		/// </summary>
		/// <value>The name.</value>
		public string Name{ get; set; }
		/// <summary>
		/// Initializes a new instance of the <see cref="PluginLoader.PluginAttribute.PluginInfoAttribute"/> class.
		/// </summary>
		/// <param name="guid">GUID.</param>
		/// <param name="priority">Priority.</param>
		public PluginInfoAttribute (string guid,int priority)
		{
			this.GUID = guid;
			this.Priority = priority;
			this.Author = "GPLv2";
			this.Version = "1.0.0";
		}
	}
}

