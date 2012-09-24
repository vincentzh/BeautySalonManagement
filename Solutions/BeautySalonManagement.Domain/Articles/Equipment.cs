using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using SharpArch.Domain.DomainModel;
using SharpArch.NHibernate.NHibernateValidator;

namespace BeautySalonManagement.Domain.Articles
{
		[HasUniqueDomainSignature(ErrorMessage = "名称已经存在")]
	public class Equipment:Entity
	{
		[DomainSignature]
		public string Name { get; set; }
		public string Description { get; set; }
	}
}
