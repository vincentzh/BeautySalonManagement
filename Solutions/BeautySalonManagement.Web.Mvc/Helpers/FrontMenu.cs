using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace BeautySalonManagement.Web.Mvc.Helpers
{
	public static class FrontMenu
	{
		public static IHtmlString NavigationMenu(this HtmlHelper html, string toString)
		{
			var output = new StringBuilder();
			AddSideBar(html,output);
			AddMenu(html, "Customer", "Index", "客户管理", toString, output);
			AddMenu(html,"Employee","Index","员工管理",toString,output);
			AddSideBar(html,output);
			return html.Raw(output.ToString());
		}

		static void AddMenu(HtmlHelper html, string controllerName, string actionName, string linkText,
							 string currentControllerName, StringBuilder output)
		{
			if (currentControllerName == controllerName)
				output.Append("<li class=\"active\">");
			else
			{
				output.Append("<li>");
			}
			output.Append(html.ActionLink(linkText, actionName, controllerName).ToHtmlString());
			output.Append("</li>");
		}
		static void AddSideBar(HtmlHelper html, StringBuilder output)
		{
			output.Append("<li class=\"nav-header\">Sidebar</li>");
		}
	}
}