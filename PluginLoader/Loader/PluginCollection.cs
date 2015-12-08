using System;
using System.IO;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using PluginLoader.Plugins;

namespace PluginLoader.Loader
{
	[DebuggerDisplay("PluginCount={PluginCount}")]
	internal sealed class PluginCollection<T> :IPluginArray<T>,ICollection<PluginInfo>
		where T:class, IPlugin
	{
		//list to save the plugin information
		private List<PluginInfo> m_lstPlugin;

		public  PluginCollection ()
		{
			this.m_lstPlugin = new List<PluginInfo> ();
		}

		/// <summary>
		/// Gets or sets the logfile stream.
		/// </summary>
		/// <value>The logfile stream.</value>
		public StreamWriter LogfileStream{ get; set; }
		#region IPluginArray implementation
		/// <summary>
		/// Gets the name of the plugins.
		/// </summary>
		/// <returns>The plugins name.</returns>
		public string[] GetPluginsName ()
		{
			List<string> lst = new List<string> ();
			foreach (var i in this.m_lstPlugin) {
				lst.Add (i.PluginFullName);
			}
			return lst.ToArray ();
		}

		/// <summary>
		/// Gets the <see cref="PluginLoader.Loader.PluginCollection`1"/> with the specified Index.
		/// </summary>
		/// <param name="Index">Index.</param>
		public T this [int Index] {
			get {
				PluginInfo plg = this.m_lstPlugin [Index];
				T tmp = plg.PluginAssembly.CreateInstance (plg.PluginFullName) as T;
				if (tmp != null) {
					if (tmp.Loading ())
						return tmp;
					else {
						if (this.LogfileStream != null)
							this.LogfileStream.WriteLine (string.Format ("{0}:{1} is loading fail"
							                                           , DateTime.UtcNow.ToShortTimeString ()
							                                           , tmp.GetName ()));
					}
				}
				return null;
			}
		}

		/// <summary>
		/// Gets the <see cref="PluginLoader.Loader.PluginCollection`1"/> with the specified GUID.
		/// if the GUID not found in the collection ,we return null
		/// </summary>
		/// <param name="GUID">GUI.</param>
		public T this [string GUID] {
			get {
				var obj = from t in this.m_lstPlugin where t.PluginGUID == GUID select t;
				if (obj.Count () == 0)
					return null;
				else {
					PluginInfo plg = obj.First ();
					T tmp = plg.PluginAssembly.CreateInstance (plg.PluginFullName) as T;
					if (tmp != null) {
						if (tmp.Loading ())
							return tmp;
						else {
							if (this.LogfileStream != null)
								this.LogfileStream.WriteLine (string.Format ("{0}:{1} is loading fail"
								                                             , DateTime.UtcNow.ToShortTimeString ()
								                                             , tmp.GetName ()));
						}
					}
					return null;
				}
			}
		}

		/// <summary>
		/// Gets the plugin count.
		/// </summary>
		/// <value>The plugin count.</value>
		public int PluginCount {
			get {
				return this.m_lstPlugin.Count;
			}
		}
		#endregion
		#region IEnumerable implementation
		/// <summary>
		/// Gets the enumerator. 
		/// we enum all Plugin instance
		/// if it return null ,may be it is create fail
		/// </summary>
		/// <returns>The enumerator.</returns>
		IEnumerator<T> IEnumerable<T>.GetEnumerator ()
		{
			foreach (var i in m_lstPlugin) {
				T tmp = i.PluginAssembly.CreateInstance (i.PluginFullName) as T;
				if (tmp != null) {
					if (tmp.Loading ())
						yield return tmp;
					else {
						if (this.LogfileStream != null)
							this.LogfileStream.WriteLine (string.Format ("{0}:{1} is loading fail"
							                                             , DateTime.UtcNow.ToShortTimeString ()
							                                             , tmp.GetName ()));
					}
				} else {
					yield return null;
				}
			}
		}
		#endregion
		#region IEnumerable implementation
		/// <summary>
		/// Gets the enumerator.
		/// if it return null,may be it  is create fail
		/// </summary>
		/// <returns>The enumerator.</returns>
		System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator ()
		{
			foreach (var i in m_lstPlugin) {
				T tmp = i.PluginAssembly.CreateInstance (i.PluginFullName) as T;
				if (tmp != null) {
					if (tmp.Loading ())
						yield return tmp;
					else {
						if (this.LogfileStream != null)
							this.LogfileStream.WriteLine (string.Format ("{0}:{1} is loading fail"
							                                             , DateTime.UtcNow.ToShortTimeString ()
							                                             , tmp.GetName ()));
					}
				} else {
					yield return null;
				}
			}
		}
		#endregion
		#region ICollection implementation
		/// <Docs>The item to add to the current collection.</Docs>
		/// <para>Adds an item to the current collection.</para>
		/// <remarks>To be added.</remarks>
		/// <exception cref="System.NotSupportedException">The current collection is read-only.</exception>
		/// <summary>
		/// Add the specified item.
		/// </summary>
		/// <param name="item">Item.</param>
		public void Add (PluginInfo item)
		{
			this.m_lstPlugin.Add (item);
		}

		/// <summary>
		/// Clear this instance.
		/// </summary>
		public void Clear ()
		{
			this.m_lstPlugin.Clear ();
		}

		/// <Docs>The object to locate in the current collection.</Docs>
		/// <para>Determines whether the current collection contains a specific value.</para>
		/// <summary>
		/// Contains the specified item.
		/// </summary>
		/// <param name="item">Item.</param>
		public bool Contains (PluginInfo item)
		{
			return this.m_lstPlugin.Contains (item);
		}

		/// <summary>
		/// Copies to.
		/// </summary>
		/// <param name="array">Array.</param>
		/// <param name="arrayIndex">Array index.</param>
		public void CopyTo (PluginInfo[] array, int arrayIndex)
		{
			this.m_lstPlugin.CopyTo (array, arrayIndex);
		}

		/// <Docs>The item to remove from the current collection.</Docs>
		/// <para>Removes the first occurrence of an item from the current collection.</para>
		/// <summary>
		/// Remove the specified item.
		/// </summary>
		/// <param name="item">Item.</param>
		public bool Remove (PluginInfo item)
		{
			return this.m_lstPlugin.Remove (item);
		}

		/// <summary>
		/// Gets the count.
		/// </summary>
		/// <value>The count.</value>
		public int Count {
			get {
				return this.m_lstPlugin.Count;
			}
		}

		/// <summary>
		/// Gets a value indicating whether this instance is read only.
		/// </summary>
		/// <value><c>true</c> if this instance is read only; otherwise, <c>false</c>.</value>
		public bool IsReadOnly {
			get {
				return false;
			}
		}
		#endregion
		#region IEnumerable implementation
		/// <summary>
		/// Gets the enumerator.
		/// this is return all Plugin Information struct
		/// </summary>
		/// <returns>The enumerator.</returns>
		public IEnumerator<PluginInfo> GetEnumerator ()
		{
			return this.m_lstPlugin.GetEnumerator ();
		}
		#endregion
		/// <summary>
		/// Sort with Plugin Priority.
		/// </summary>
		public void Sort ()
		{
			this.m_lstPlugin.Sort ();
		}
	}
}

