using BeautySalonManagement.Domain.Peoples;
using MindHarbor.GenClassLib.Data;

namespace BeautySalonManagement.Domain
{
	/// <summary>
	/// domainLayer is baiscally a state container to contain the helper objects that have states
	/// it has the same lifetime as a HttpSession
	/// </summary>
	public class DomainSession
	{
		static readonly SessionData<DomainSession> instance = new SessionData<DomainSession>();

		/// <summary>
		/// get the current domainLayer object, that is related to current session
		/// </summary>
		public static DomainSession Current
		{
			get
			{
				if (instance.Value == null)
					instance.Value = DomainSetting.GetInstanceFromConfig<DomainSession>("DomainSessionType",
					                                                                    typeof (
					                                                                    		DomainSession
					                                                                    		));
				return instance.Value;
			}
		}

		public People People { get; set; }
	}
}