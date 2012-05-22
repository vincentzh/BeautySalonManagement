using System.Text;
using System.Web;
using log4net;

namespace CommonLib.Util
{
	public static class Logger
	{
		static ILog Log
		{
			get { return LogManager.GetLogger("Custom.Logger"); }
		}

		static string FormatString
		{
			get
			{
				var sb = new StringBuilder();
				sb.Append("{0} - Client: ");

				HttpContext ctx = HttpContext.Current;
				if (ctx != null && ctx.Request != null)
				{
					sb.Append(ctx.Request.UserHostAddress).Append("/").Append(ctx.User).Append("/").Append
							(ctx.Request.UserAgent);
				}
				else
				{
					sb.Append("UNKNOWN");
				}
				return sb.ToString();
			}
		}

		public static void Debug(object message)
		{
			Log.DebugFormat(FormatString, message);
		}

		public static void Error(object message)
		{
			Log.ErrorFormat(FormatString, message);
		}

		public static void Info(object message)
		{
			Log.InfoFormat(FormatString, message);
		}
	}
}