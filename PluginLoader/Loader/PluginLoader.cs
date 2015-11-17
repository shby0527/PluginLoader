using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Reflection;
using PluginLoader.Plugins;
using PluginLoader.PluginAttribute;

/// <summary>
/// Plugin loader.
/// </summary>
namespace PluginLoader.Loader
{
	/// <summary>
	/// Plugin loader.
	/// </summary>
	public static class PluginLoader<T> 
		where T:class, IPlugin, new()
	{
		/// <summary>
		/// The m_ plugin array.
		/// </summary>
		private static PluginCollection<T> m_PluginArray = null;
		private static StreamWriter sw;

		/// <summary>
		/// Load the specified Path.
		/// </summary>
		/// <param name="Path">Path. the Path is Full Path or reletivite Path</param>
		/// <exception cref="System.IO.DirectoryNotFoundException">the Path was not found</exception>
		public static IPluginArray<T> Load (string argPath)
		{
			if (m_PluginArray != null)
				return m_PluginArray;
			m_PluginArray = new PluginCollection<T> ();
			DirectoryInfo dir = new DirectoryInfo (argPath);
			if (!dir.Exists)
				throw new DirectoryNotFoundException (dir.FullName + " was not found");
			//the we should get the full path
			string plugin_full_path = dir.FullName;
			StartLoad (plugin_full_path);
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
			sw = File.AppendText ("./logfile.log");
			foreach (string file_full_path in AllFile) {
				//Now we try to load the file 
				try {
					Assembly assmbly = Assembly.LoadFrom (file_full_path);
					sw.WriteLine (string.Format ("we loaded {0}", assmbly.GetName ().Name));
					foreach (Module mod in assmbly.GetModules(false)) {
						TypeCheck (mod);
					}
				} catch (Exception e) {
					sw.WriteLine (string.Format ("we get an exception {0} in {1}", e.Message, e.StackTrace));
				}
			}
			sw.Close ();
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
		/// </summary>
		/// <param name="ModuleArr">Module arr.</param>
		private static void TypeCheck (Module Mod)
		{
			//start to find class
			foreach (Type type in Mod.GetTypes()) {
				if (!CheckImplement (type))
					continue;
				PluginInfoAttribute attr = CheckHasAttribute (type);
				if (attr == null) {
					sw.WriteLine (string.Format ("we didn't found the attribute in the plugin class {0}", type.Name));
					continue;
				}
				//OK the class who implement the interface and it has attribute
				if (CheckSame (attr.GUID)) {
					sw.WriteLine (string.Format ("the plugin{0} we found the same in collection", type.Name));
					continue;
				}
				PluginInfo pli = new PluginInfo ();
				pli.PluginAssembly = type.Assembly;
				pli.PluginFullName = type.FullName;
				pli.PluginGUID = attr.GUID;
				pli.PluginPriority = attr.Priority;
				m_PluginArray.Add (pli);
				sw.WriteLine (string.Format ("the plugin{0} was loaded", type.Name));
			}
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
					return attr;
				}
			}
			return null;
		}
		/// <summary>
		/// Checks the same.
		/// </summary>
		/// <returns><c>true</c>, if same ,return true <c>false</c> otherwise.</returns>
		/// <param name="GUID">GUI.</param>
		private static bool CheckSame(string GUID)
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
	}
}

