using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Reflection;
using PluginLoader.Plugins;

namespace PluginLoader.Loader
{
	[DebuggerDisplay("PluginCount={PluginCount}")]
	internal sealed class PluginCollection<T> :IPluginArray<T>,ICollection<PluginInfo>
		where T:IPlugin, new()
	{
		private List<PluginInfo> m_lstPlugin;

		public  PluginCollection ()
		{
			this.m_lstPlugin = new List<PluginInfo> ();
		}
		#region IPluginArray implementation
		public string[] GetPluginsName ()
		{
			throw new NotImplementedException ();
		}

		public T this [int Index] {
			get {
				throw new NotImplementedException ();
			}
		}

		public T this [string Hash] {
			get {
				throw new NotImplementedException ();
			}
		}

		public int PluginCount {
			get {
				throw new NotImplementedException ();
			}
		}
		#endregion
		#region IEnumerable implementation
		IEnumerator<T> IEnumerable<T>.GetEnumerator ()
		{
			foreach (var i in m_lstPlugin) {
				yield return i.PluginAssembly.CreateInstance (i.PluginFullName);
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

