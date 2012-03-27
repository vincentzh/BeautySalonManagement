using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommonLib.Exception;
using MindHarbor.GenClassLib.Configuration;
using MindHarbor.SingletonUtil;

namespace BeautySalonManagement.Domain
{
	public class DomainSetting
	{
		public static T GetInstanceFromConfig<T>(string key, Type defaultType)
		{
			Type t = defaultType;
			string tn = ConfigurationManager.GetSetting(key, string.Empty);
			if (!string.IsNullOrEmpty(tn))
				t = Type.GetType(tn);
			if (t == null)
				throw new DomainGeneralException("Cannot find type \"" + tn + "\" as " + key +
												 ", please check configuration file");
			return (T)SingletonInstanceLoader.Load(t);
		}
	}
}
