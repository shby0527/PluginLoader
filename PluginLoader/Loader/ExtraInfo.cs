using System;
using System.Reflection;
using PluginLoader.PluginAttribute;
using PluginLoader.PluginAttribute.PluginException;
using PluginLoader.Plugins;

namespace PluginLoader.Loader
{
	/// <summary>
	/// this class is extension to IPlugin
	/// for get plugin's Information
	/// </summary>
	public  static class ExtraInfo
	{
		/// <summary>
		/// Gets the GUID.
		/// </summary>
		/// <returns>The GUID.</returns>
		/// <param name="obj">Object.</param>
		/// <exception cref="PluginLoader.PluginAttribute.PluginException.AttributeNotFoundException">Not Found Attribute</exception>
		public static string GetGUID (this IPlugin obj)
		{
			Type type = obj.GetType ();
			object[] attrObj = type.GetCustomAttributes (false);
			foreach (object i in attrObj) {
				PluginInfoAttribute attrTmp = i as PluginInfoAttribute;
				if (attrTmp == null) 
					continue;
				return attrTmp.GUID;
			}
			throw new AttributeNotFoundException ();
		}
		/// <summary>
		/// Gets the author.
		/// </summary>
		/// <returns>The author.</returns>
		/// <param name="obj">Object.</param>
		public static string GetAuthor (this IPlugin obj)
		{
			Type type = obj.GetType ();
			object[] attrObj = type.GetCustomAttributes (false);
			foreach (object i in attrObj) {
				PluginInfoAttribute attr = i as PluginInfoAttribute;
				if (attr == null)
					continue;
				return attr.Author;
			}
			throw new AttributeNotFoundException ();
		}
		/// <summary>
		/// Gets the name.
		/// </summary>
		/// <returns>The name.</returns>
		/// <param name="obj">Object.</param>
		public static string GetName(this IPlugin obj)
		{
			Type type = obj.GetType ();
			object[] attrObj = type.GetCustomAttributes (false);
			foreach (object i in attrObj) {
				PluginInfoAttribute attr = i as PluginInfoAttribute;
				if (attr == null)
					continue;
				return attr.Name;
			}
			throw new AttributeNotFoundException ();
		}
		/// <summary>
		/// Gets the version.
		/// </summary>
		/// <returns>The version.</returns>
		/// <param name="obj">Object.</param>
		public static string GetVersion (this IPlugin obj)
		{
			Type type = obj.GetType ();
			object[] attrObj = type.GetCustomAttributes (false);
			foreach (object i in attrObj) {
				PluginInfoAttribute attr = i as PluginInfoAttribute;
				if (attr == null)
					continue;
				return attr.Version;
			}
			throw new AttributeNotFoundException ();
		}
		/// <summary>
		/// Gets the priority.
		/// </summary>
		/// <returns>The priority.</returns>
		/// <param name="obj">Object.</param>
		public static int GetPriority(this IPlugin obj)
		{
			Type type = obj.GetType ();
			object[] attrObj = type.GetCustomAttributes (false);
			foreach (object i in attrObj) {
				PluginInfoAttribute attr = i as PluginInfoAttribute;
				if (attr == null)
					continue;
				return attr.Priority;
			}
			throw new AttributeNotFoundException ();
		}
		/*<--------------------------------------------------------------------------------->
		 *this get mothd well not throw exception 
		 */
		/// <summary>
		/// Gets the ex commit.
		/// if not found, return null
		/// </summary>
		/// <returns>The ex commit.</returns>
		/// <param name="obj">Object.</param>
		public static string GetExCommit(this IPlugin obj)
		{
			Type type = obj.GetType ();
			object[] attrObj = type.GetCustomAttributes (false);
			foreach (object i in attrObj) {
				PluginExtraInfoAttribute attr = i as PluginExtraInfoAttribute;
				if (attr == null)
					continue;
				return attr.Commit;
			}
			return null;
		}
		/// <summary>
		/// Gets the ex company.
		/// if not found ,return null
		/// </summary>
		/// <returns>The ex company.</returns>
		/// <param name="obj">Object.</param>
		public static string GetExCompany(this IPlugin obj)
		{
			Type type = obj.GetType ();
			object[] attrObj = type.GetCustomAttributes (false);
			foreach (object i in attrObj) {
				PluginExtraInfoAttribute attr = i as PluginExtraInfoAttribute;
				if (attr == null)
					continue;
				return attr.Company;
			}
			return null;
		}
		/// <summary>
		/// Gets the ex release time.
		/// if not found ,return null
		/// </summary>
		/// <returns>The ex release time.</returns>
		/// <param name="obj">Object.</param>
		public static string GetExReleaseTime(this IPlugin obj)
		{
			Type type = obj.GetType ();
			object[] attrObj = type.GetCustomAttributes (false);
			foreach (object i in attrObj) {
				PluginExtraInfoAttribute attr = i as PluginExtraInfoAttribute;
				if (attr == null)
					continue;
				return attr.ReleaseTime;
			}
			return null;
		}
		/// <summary>
		/// Gets the ex update time.
		/// if not found ,return null
		/// </summary>
		/// <returns>The ex update time.</returns>
		/// <param name="obj">Object.</param>
		public static string GetExUpdateTime(this IPlugin obj)
		{
			Type type = obj.GetType ();
			object[] attrObj = type.GetCustomAttributes (false);
			foreach (object i in attrObj) {
				PluginExtraInfoAttribute attr = i as PluginExtraInfoAttribute;
				if (attr == null)
					continue;
				return attr.UpdateTime;
			}
			return null;
		}

		/*
		 *<-------------------------------------------------------------------------------------------> 
		 */
		/// <summary>
		/// Gets the name of the dg info.
		/// if not found ,return null
		/// </summary>
		/// <returns>The dg info name.</returns>
		/// <param name="obj">Object.</param>
		public static string GetDgInfoName(this IPlugin obj)
		{
			Type type = obj.GetType ();
			object[] attrObj = type.GetCustomAttributes (false);
			foreach (object i in attrObj) {
				DingerInfoAttribute attr = i as DingerInfoAttribute;
				if (attr == null)
					continue;
				return attr.Name;
			}
			return null;
		}
		/// <summary>
		/// Gets the dg info address.
		/// if not found ,return null
		/// </summary>
		/// <returns>The dg info address.</returns>
		/// <param name="obj">Object.</param>
		public static string GetDgInfoAddress(this IPlugin obj)
		{
			Type type = obj.GetType ();
			object[] attrObj = type.GetCustomAttributes (false);
			foreach (object i in attrObj) {
				DingerInfoAttribute attr = i as DingerInfoAttribute;
				if (attr == null)
					continue;
				return attr.Address;
			}
			return null;
		}

		/// <summary>
		/// Gets the dg info email.
		/// if not found,return null
		/// </summary>
		/// <returns>The dg info email.</returns>
		/// <param name="obj">Object.</param>
		public static string GetDgInfoEmail(this IPlugin obj)
		{
			Type type = obj.GetType ();
			object[] attrObj = type.GetCustomAttributes (false);
			foreach (object i in attrObj) {
				DingerInfoAttribute attr = i as DingerInfoAttribute;
				if (attr == null)
					continue;
				return attr.EMail;
			}
			return null;
		}
		/// <summary>
		/// Gets the dg info phone.
		/// if not found,return null
		/// </summary>
		/// <returns>The dg info phone.</returns>
		/// <param name="obj">Object.</param>
		public static string GetDgInfoPhone(this IPlugin obj)
		{
			Type type = obj.GetType ();
			object[] attrObj = type.GetCustomAttributes (false);
			foreach (object i in attrObj) {
				DingerInfoAttribute attr = i as DingerInfoAttribute;
				if (attr == null)
					continue;
				return attr.Phone;
			}
			return null;
		}
	}
}
