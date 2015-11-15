using System;
/// <summary>
/// Plugin extra info attribute.
/// 插件扩展信息
/// 该文件基于GPLv2发布
/// 可以自由复制和分发
/// </summary>
namespace PluginLoader.PluginAttribute
{
	/// <summary>
	/// Plugin extra info attribute.
	/// </summary>
	[AttributeUsage(AttributeTargets.Class,AllowMultiple = false,Inherited = true)]
	public class PluginExtraInfoAttribute:Attribute
	{
		/// <summary>
		/// Gets or sets the release time.
		/// </summary>
		/// <value>The release time.</value>
		public string ReleaseTime{ get; set;}
		/// <summary>
		/// Gets or sets the update time.
		/// </summary>
		/// <value>The update time.</value>
		public string UpdateTime{ get; set;}
		/// <summary>
		/// Gets or sets the company.
		/// </summary>
		/// <value>The company.</value>
		public string Company{ get; set;}
		/// <summary>
		/// Gets or sets the commit.
		/// </summary>
		/// <value>The commit.</value>
		public string Commit{ get; set;}
		/// <summary>
		/// Initializes a new instance of the <see cref="PluginLoader.PluginAttribute.PluginExtraInfoAttribute"/> class.
		/// </summary>
		public PluginExtraInfoAttribute ()
		{
			this.ReleaseTime = DateTime.Now.ToShortDateString ();
			this.UpdateTime = DateTime.Now.ToLongDateString ();
			this.Company = "GPL";
			this.Commit = "";
		}
	}
}

