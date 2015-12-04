using System;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using PluginLoader.Plugins;
using PluginLoader.Loader;
using PluginLoader.PluginAttribute;
using PluginLoader.PluginAttribute.PluginException;

namespace PluginLoader.Configure
{
	/// <summary>
	/// Configure manager.
	/// to load the plugin configure file
	/// </summary>
	public sealed class ConfigureManager
	{
		private Dictionary<string,string> m_map = null;

		/// <summary>
		/// Initializes a new instance of the <see cref="PluginLoader.Configure.ConfigureManager"/> class.
		/// </summary>
		/// <param name="file_path">File_path.</param>
		public ConfigureManager (string file_path)
		{
			FileInfo file = new FileInfo (file_path);
			if (!file.Exists)
				throw new FileNotFoundException ("the configure file is not found");
			this.m_map = new Dictionary<string, string> ();
			this.LoadConfig (file);
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="PluginLoader.Configure.ConfigureManager"/> class.
		/// </summary>
		/// <param name="type">the plugin's type</param>
		public ConfigureManager (Type type)
		{
			string path = type.Assembly.Location;
			DirectoryInfo dir = Directory.GetParent (path);
			PluginInfoAttribute attr = PluginLoader<IPlugin>.CheckHasAttribute (type);
			if (attr == null)
				throw new AttributeNotFoundException ();
			string config_file = dir.FullName + "/" + attr.GUID + "/"
				+ attr.Name + ".conf";
			FileInfo file = new FileInfo (config_file);
			if (!file.Exists)
				throw new FileNotFoundException ("configure file is not exists");
			this.m_map = new Dictionary<string, string> ();
			this.LoadConfig (file);
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="PluginLoader.Configure.ConfigureManager"/> class.
		/// </summary>
		/// <param name="instance">the plugin instance</param>
		public ConfigureManager (IPlugin instance)
			:this(instance.GetType())
		{

		}

		/// <summary>
		/// Load the config file to init the plugin
		/// </summary>
		/// <returns><c>true</c>, if config was loaded, <c>false</c> otherwise.</returns>
		/// <param name="file">File.</param>
		private bool LoadConfig (FileInfo file)
		{
			using (StreamReader sr = file.OpenText ()) {
				while (!sr.EndOfStream) {
					string line = sr.ReadLine ().Trim ();
					string[] values = line.Split ('=');
					string Key = values [0].Trim ();
					string Value = values [1].Trim ();
					this.m_map.Add (Key, Value);
				}
				sr.Close ();
			}
			return true;
		}

		/// <summary>
		/// Gets or sets the <see cref="PluginLoader.Configure.ConfigureManager"/> with the specified Key.
		/// </summary>
		/// <param name="Key">Key.</param>
		public string this [string Key] {
			get {
				return this.m_map [Key];
			}
			set {
				if (!this.m_map.ContainsKey (Key))
					this.m_map.Add (Key, value);
				else
					this.m_map [Key] = value;
			}
		}
	}
}

