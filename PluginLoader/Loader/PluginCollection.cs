using System;
using System.IO;
using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using PluginLoader.Plugins;

namespace PluginLoader.Loader
{
    [DebuggerDisplay("PluginCount={PluginCount}")]
    internal sealed class PluginCollection<T> : PluginInfoCollection, IPluginArray<T>
        where T : class, IPlugin
    {
        //list to save the plugin information


        public PluginCollection() : base()
        {

        }

        /// <summary>
        /// Gets or sets the logfile stream.
        /// </summary>
        /// <value>The logfile stream.</value>
        public StreamWriter LogfileStream { get; set; }
        #region IPluginArray implementation
        /// <summary>
        /// Gets the name of the plugins.
        /// </summary>
        /// <returns>The plugins name.</returns>
        public string[] GetPluginsName()
        {
            List<string> lst = new List<string>();
            foreach (var i in this.m_lstPlugin)
            {
                lst.Add(i.PluginFullName);
            }
            return lst.ToArray();
        }

        /// <summary>
        /// Gets the <see cref="PluginLoader.Loader.PluginCollection`1"/> with the specified Index.
        /// </summary>
        /// <param name="Index">Index.</param>
        public T this[int Index]
        {
            get
            {
                PluginInfo plg = this.m_lstPlugin[Index];
                T tmp = plg.PluginAssembly.CreateInstance(plg.PluginFullName) as T;
                if (tmp != null)
                {
                    if (tmp.Loading())
                        return tmp;
                    else
                    {
                        if (this.LogfileStream != null)
                            this.LogfileStream.WriteLine(string.Format("{0}:{1} is loading fail"
                                                                       , DateTime.UtcNow.ToShortTimeString()
                                                                       , tmp.GetName()));
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
        public T this[string GUID]
        {
            get
            {
                var obj = from t in this.m_lstPlugin where t.PluginGUID == GUID select t;
                if (obj.Count() == 0)
                    return null;
                else
                {
                    PluginInfo plg = obj.First();
                    T tmp = plg.PluginAssembly.CreateInstance(plg.PluginFullName) as T;
                    if (tmp != null)
                    {
                        if (tmp.Loading())
                            return tmp;
                        else
                        {
                            if (this.LogfileStream != null)
                                this.LogfileStream.WriteLine(string.Format("{0}:{1} is loading fail"
                                                                             , DateTime.UtcNow.ToShortTimeString()
                                                                             , tmp.GetName()));
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
        public int PluginCount
        {
            get
            {
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
        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            foreach (var i in m_lstPlugin)
            {
                T tmp = i.PluginAssembly.CreateInstance(i.PluginFullName) as T;
                if (tmp != null)
                {
                    if (tmp.Loading())
                        yield return tmp;
                    else
                    {
                        if (this.LogfileStream != null)
                            this.LogfileStream.WriteLine(string.Format("{0}:{1} is loading fail"
                                                                         , DateTime.UtcNow.ToShortTimeString()
                                                                         , tmp.GetName()));
                    }
                }
                else
                {
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
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            foreach (var i in m_lstPlugin)
            {
                T tmp = i.PluginAssembly.CreateInstance(i.PluginFullName) as T;
                if (tmp != null)
                {
                    if (tmp.Loading())
                        yield return tmp;
                    else
                    {
                        if (this.LogfileStream != null)
                            this.LogfileStream.WriteLine(string.Format("{0}:{1} is loading fail"
                                                                         , DateTime.UtcNow.ToShortTimeString()
                                                                         , tmp.GetName()));
                    }
                }
                else
                {
                    yield return null;
                }
            }
        }
        #endregion

    }
}

