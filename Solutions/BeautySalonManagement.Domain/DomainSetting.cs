using System;
using CommonLib.Exceptions;
using MindHarbor.GenClassLib.Configuration;
using MindHarbor.SingletonUtil;

namespace BeautySalonManagement.Domain
{
	public class DomainSetting
	{
		public static T GetInstanceFromConfig<T>(string key, Type defaultType)
		{
			var t = defaultType;
			var tn = ConfigurationManager.GetSetting(key, string.Empty);
			if (!string.IsNullOrEmpty(tn))
				t = Type.GetType(tn);
			if (t == null)
				throw new DomainGeneralException("Cannot find type \"" + tn + "\" as " + key +
				                                 ", please check configuration file");
			return (T) SingletonInstanceLoader.Load(t);
		}
	}
}