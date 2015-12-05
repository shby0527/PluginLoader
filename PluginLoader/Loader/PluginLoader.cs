using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using PluginLoader.PluginAttribute;
using PluginLoader.Plugins;
using PluginLoader.Configure;
/// <summary>
/// Plugin loader.
/// </summary>
namespace PluginLoader.Loader
{
	/// <summary>
	/// Plugin loader.
	/// </summary>
	public static class PluginLoader<T> 
		where T:class, IPlugin
	{
		/// <summary>
		/// The m_ plugin array.
		/// </summary>
		private static PluginCollection<T> m_PluginArray = null;
		private static StreamWriter sw;

		/// <summary>
		/// Load the specified assembly.
		/// load from assmbly's full path
		/// </summary>
		/// <param name="assembly">Assembly.</param>
		public static IPluginArray<T> Load (Assembly assembly)
		{
			string path = assembly.Location;
			if (path == "")
				return Load (".");
			DirectoryInfo info = Directory.GetParent (path);
			return Load (info.FullName);
		}

		/// <summary>
		/// Load the specified Path.
		/// </summary>
		/// <param name="Path">Path. the Path is Full Path or reletivite Path</param>
		/// <exception cref="System.IO.DirectoryNotFoundException">the Path was not found</exception>
		public static IPluginArray<T> Load (string argPath)
		{
			if (m_PluginArray != null)
				return m_PluginArray;
			DirectoryInfo dir = new DirectoryInfo (argPath);
			if (!dir.Exists)
				throw new DirectoryNotFoundException (dir.FullName + " was not found");
			//the we should get the full path
			m_PluginArray = new PluginCollection<T> ();
			string plugin_full_path = dir.FullName;
			StartLoad (plugin_full_path);
			m_PluginArray.Sort ();
			return m_PluginArray;
		}

		/// <summary>
		/// Start load.
		/// we show start load
		/// </summary>
		/// <param name="FullPath">Full path.</param>
		private static void StartLoad (string FullPath)
		{
			string[] AllFile = Directory.GetFiles (FullPath, "*.dll", SearchOption.TopDirectoryOnly);
			sw = File.AppendText (FullPath + "/logfile.log");
			sw.AutoFlush = true;
			foreach (string file_full_path in AllFile) {
				//Now we try to load the file 
				try {
					Assembly assmbly = Assembly.LoadFrom (file_full_path);
					sw.WriteLine (string.Format ("{0}:we loaded {1}"
					                             , DateTime.UtcNow.ToString ()
					                             , assmbly.GetName ().Name));
					foreach (Module mod in assmbly.GetModules(false)) {
						TypeCheck (mod);
					}
				} catch (Exception e) {
					sw.WriteLine (string.Format ("{0}:we get an exception {1} in {2}"
					                             , DateTime.UtcNow.ToString ()
					                             , e.Message
					                             , e.StackTrace));
				}
			}
			sw.Close ();
			sw.Dispose ();
		}

		/// <summary>
		/// Types the check. <br />
		///
		/// OK,we get all type<br />
		/// now we should check the class,<br />
		/// if it not implement IPlugin,<br />
		/// we should ignore it<br />
		/// then we check it's attribute<br />
		/// if not found,we shoud not <br />
		/// add it to collection,<br />
		/// write to log file ,load fail<br />
		/// the Plugin Priority is Load from
		/// configure file.
		/// the file is from the Plugins Assembly's
		/// localtion directory/plugin Hash/plugin name.conf,
		/// you can write you own config in this file.
		/// if this file not exists ,we will create it
		/// and the default priority is the author define in
		/// his plugin's information attribute
		/// </summary>
		/// <param name="ModuleArr">Module arr.</param>.
		private static void TypeCheck (Module Mod)
		{
			//start to find class
			foreach (Type type in Mod.GetTypes()) {
				if (!CheckImplement (type))
					continue;
				if (!CheckExtends (type)) //if it not extends type T, we should igonre it
					continue;
				PluginInfoAttribute attr = CheckHasAttribute (type);
				if (attr == null) {
					sw.WriteLine (
						string.Format ("{0}:we didn't found the attribute or the attribute GUID not checked in the plugin class {1}"
					               , DateTime.UtcNow.ToString ()
					               , type.Name));
					continue;
				}
				//OK the class who implement the interface and it has attribute
				if (CheckSame (attr.GUID)) {
					sw.WriteLine (string.Format ("{0}:the plugin {1} we found the same in collection"
					                             , DateTime.UtcNow.ToString ()
					                             , type.Name));
					continue;
				}
				int priority = ConfCheck (type, attr);
				PluginInfo pli = new PluginInfo ();
				pli.PluginAssembly = type.Assembly;
				pli.PluginFullName = type.FullName;
				pli.PluginGUID = attr.GUID;
				pli.PluginPriority = priority;
				m_PluginArray.Add (pli);
				sw.WriteLine (string.Format ("{0}:the plugin {1} was loaded"
				                             , DateTime.UtcNow.ToString ()
				                             , type.Name));
			}
		}

		/// <summary>
		/// Configure file read and check it Priority config
		/// </summary>
		/// <returns>The check.</returns>
		/// <param name="plugin">Plugin.</param>
		private static int ConfCheck (Type plugin, PluginInfoAttribute attr)
		{
			string path = plugin.Assembly.Location;
			DirectoryInfo dir = null;
			if (path == "") {
				//if the assembly is load from memory
				//we load config file from the 
				//work directory
				dir = new DirectoryInfo (".");
			} else {
				path = Directory.GetParent (path).FullName;
				dir = new DirectoryInfo (path + "/" + attr.GUID);
			}
			if (!dir.Exists)
				dir.Create ();
			string config_file = dir.FullName + "/" + attr.Name + ".conf";
			FileInfo file = new FileInfo (config_file);
			if (!file.Exists) {
				file.Create ();
				using (StreamWriter swf = file.AppendText ()) {
					swf.WriteLine ("priority = {0}", attr.Priority);
					swf.Flush ();
					swf.Close ();
				}
			}
			ConfigureManager manager = new ConfigureManager (config_file);
			return Convert.ToInt32 (manager ["priority"]);
		}

		/// <summary>
		/// Checks the implement.
		/// </summary>
		/// <returns><c>true</c>, if implement was checked, <c>false</c> otherwise.</returns>
		/// <param name="type">Type.</param>
		private static bool CheckImplement (Type type)
		{
			Type[] implement_interfaces = type.GetInterfaces ();
			bool flag = false;
			foreach (Type i in implement_interfaces) {
				if (i == typeof(IPlugin)) {
					//OK we found
					flag = true;
					break;
				}
			}
			return flag;
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
		/// Checks the same.
		/// </summary>
		/// <returns><c>true</c>, if same ,return true <c>false</c> otherwise.</returns>
		/// <param name="GUID">GUI.</param>
		private static bool CheckSame (string GUID)
		{
			bool flag = false;
			foreach (PluginInfo w in m_PluginArray) {
				if (w.PluginGUID == GUID) {
					flag = true;
					break;
				}
			}
			return flag;
		}

		/// <summary>
		/// Checks the extends.
		/// who is entends type T
		/// </summary>
		/// <returns><c>true</c>, if extends was checked, <c>false</c> otherwise.</returns>
		/// <param name="type">Type.</param>
		private static bool CheckExtends (Type type)
		{
			Type base_type = typeof(T);
			bool flag = false;
			Type tmp = type;
			//if the type is a interface ,it's base type is null
			//base type is null, mean the super class
			while (tmp.BaseType != null) {
				if (tmp.BaseType == base_type && !tmp.IsAbstract) {
					flag = true;
					break;
				}
				tmp = tmp.BaseType;
			}
			return flag;
		}
	}
}

