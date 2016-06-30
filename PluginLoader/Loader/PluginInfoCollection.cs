using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PluginLoader.Loader
{
	internal abstract class PluginInfoCollection : ICollection<PluginInfo>
	{
		protected List<PluginInfo> m_lstPlugin;

		protected PluginInfoCollection ()
		{
			this.m_lstPlugin = new List<PluginInfo> ();
		}

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

		IEnumerator IEnumerable.GetEnumerator ()
		{
			return this.m_lstPlugin.GetEnumerator ();
		}
	}
}
