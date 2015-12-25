using System;
using System.IO;
using System.Text.RegularExpressions;
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
		private string m_config_file = null;

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
			this.m_config_file = file_path;
			this.LoadConfig (file);
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="PluginLoader.Configure.ConfigureManager"/> class.
		/// </summary>
		/// <param name="type">the plugin's type</param>
		public ConfigureManager (Type type)
		{
			string path = type.Assembly.Location;
			if (path == "")
				path = ".";
			DirectoryInfo dir = Directory.GetParent (path);
			PluginInfoAttribute attr = CheckHasAttribute (type);
			if (attr == null)
				throw new AttributeNotFoundException ();
			string config_file = dir.FullName + "/" + attr.GUID + "/"
				+ attr.Name + ".conf";
			FileInfo file = new FileInfo (config_file);
			if (!file.Exists)
				throw new FileNotFoundException ("configure file is not exists");
			this.m_map = new Dictionary<string, string> ();
			this.m_config_file = config_file;
			this.LoadConfig (file);
		}

		/// <summary>
		/// Checks the has attribute.
		/// </summary>
		/// <returns>The has attribute.</returns>
		/// <param name="type">Type.</param>
		private static PluginInfoAttribute CheckHasAttribute (Type type)
		{
			object[] all_Attribute = type.GetCustomAttributes (false);
			foreach (object i in all_Attribute) {
				PluginInfoAttribute attr = i as PluginInfoAttribute;
				if (attr != null) {
					//now we check the GUID 
					Regex reg = new Regex ("^[a-fA-F0-9]{64}$");
					if (reg.IsMatch (attr.GUID))
						return attr;
					else
						return null;
				}
			}
			return null;
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
					//if the line is empty
					if (line == "")
						continue;
					//if the line of the first char is '#'
					//we should ignore it
					if (line [0] == '#')
						continue;
					int index = line.IndexOf ('=');
					string Key = line.Substring (0, index).Trim ();
					string Value = line.Substring (index + 1, line.Length - index - 1).Trim ();
					this.m_map.Add (Key, Value);
				}
				sr.Close ();
			}
			return true;
		}

		/// <summary>
		/// Saves all config.
		/// </summary>
		/// <returns><c>true</c>, if all config was saved, <c>false</c> otherwise.</returns>
		public bool SaveAllConfig ()
		{
			if (this.m_map == null)
				return false;
			if (this.m_config_file == null)
				return false;
			FileInfo file = new FileInfo (this.m_config_file);
			if (!file.Exists)
				return false;
			using (StreamWriter sw = file.CreateText()) {
				foreach (string key in this.m_map.Keys) {
					sw.WriteLine (string.Format ("{0}={1}", key, this.m_map [key]));
				}
				sw.Flush ();
				sw.Close ();
				return true;
			}
		}

		/// <summary>
		/// Determines whether this instance is config key exists the specified Key.
		/// </summary>
		/// <returns><c>true</c> if this instance is config key exists the specified Key; otherwise, <c>false</c>.</returns>
		/// <param name="Key">Key.</param>
		public bool IsConfigKeyExists (string Key)
		{
			return this.m_map.ContainsKey (Key);
		}

		/// <summary>
		/// Gets the config directory.
		/// </summary>
		/// <value>The config directory.</value>
		public string ConfigDirectory {
			get {
				return Directory.GetParent (this.m_config_file).FullName;
			}
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

