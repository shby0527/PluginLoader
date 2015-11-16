using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using PluginLoader.Plugins;

namespace PluginLoader.Loader
{
	[DebuggerDisplay("PluginCount={PluginCount}")]
	internal sealed class PluginCollection<T> :IPluginArray<T>,ICollection<PluginInfo>
		where T:class,IPlugin,new()
	{
		private List<PluginInfo> m_lstPlugin;

		public  PluginCollection ()
		{
			this.m_lstPlugin = new List<PluginInfo> ();
		}
		#region IPluginArray implementation
		public string[] GetPluginsName ()
		{
			List<string> lst = new List<string> ();
			foreach (var i in this.m_lstPlugin) {
				lst.Add (i.PluginFullName);
			}
			return lst.ToArray ();
		}

		public T this [int Index] {
			get {
				return this.m_lstPlugin [Index].PluginAssembly.CreateInstance (this.m_lstPlugin [Index].PluginFullName) as T;
			}
		}

		public T this [string GUID] {
			get {
				var obj = from t in this.m_lstPlugin where t.PluginGUID == GUID select t;
				if(obj.Count() == 0)
					return null;
				else
				{
					PluginInfo plg = obj.First();
					return plg.PluginAssembly.CreateInstance(plg.PluginFullName) as T;
				}
			}
		}

		public int PluginCount {
			get {
				return this.m_lstPlugin.Count;
			}
		}
		#endregion
		#region IEnumerable implementation
		IEnumerator<T> IEnumerable<T>.GetEnumerator ()
		{
			foreach (var i in m_lstPlugin) {
				yield return i.PluginAssembly.CreateInstance (i.PluginFullName) as T ;
			}
		}
		#endregion
		#region IEnumerable implementation
		System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator ()
		{
			foreach (var i in m_lstPlugin) {
				yield return i.PluginAssembly.CreateInstance (i.PluginFullName);
			}
		}
		#endregion
		#region ICollection implementation
		public void Add (PluginInfo item)
		{
			this.m_lstPlugin.Add (item);
		}

		public void Clear ()
		{
			this.m_lstPlugin.Clear ();
		}

		public bool Contains (PluginInfo item)
		{
			return this.m_lstPlugin.Contains (item);
		}

		public void CopyTo (PluginInfo[] array, int arrayIndex)
		{
			this.m_lstPlugin.CopyTo (array, arrayIndex);
		}

		public bool Remove (PluginInfo item)
		{
			return this.m_lstPlugin.Remove (item);
		}

		public int Count {
			get {
				return this.m_lstPlugin.Count;
			}
		}

		public bool IsReadOnly {
			get {
				return true;
			}
		}
		#endregion
		#region IEnumerable implementation
		public IEnumerator<PluginInfo> GetEnumerator ()
		{
			return this.m_lstPlugin.GetEnumerator ();
		}
		#endregion
	}
}

