using BeautySalonManagement.Domain.Permissions;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using CommonLib.Util.Authentications;
using SharpArch.Domain.Commands;
using SharpArch.Domain.Events;
using SharpArch.Domain.PersistenceSupport;
using SharpArch.NHibernate;
using SharpArch.NHibernate.Contracts.Repositories;
using SharpArch.Web.Mvc.Castle;

namespace BeautySalonManagement.Web.Mvc.CastleWindsor
{
	public class ComponentRegistrar
	{
		public static void AddComponentsTo(IWindsorContainer container)
		{
			AddGenericRepositoriesTo(container);
			AddCustomRepositoriesTo(container);
			AddQueryObjectsTo(container);

			AddHandlersTo(container);
			AddTasksTo(container);
			AddCustom(container);
		}

		static void AddTasksTo(IWindsorContainer container)
		{
			container.Register(
					AllTypes
							.FromAssemblyNamed("BeautySalonManagement.Tasks")
							.Pick().If(t => t.Name.EndsWith("Tasks"))
							.WithService.FirstNonGenericCoreInterface("BeautySalonManagement.Domain"));
		}

		static void AddCustomRepositoriesTo(IWindsorContainer container)
		{
			container.Register(
					AllTypes
							.FromAssemblyNamed("BeautySalonManagement.Infrastructure")
							.BasedOn(typeof (IRepositoryWithTypedId<,>))
							.WithService.FirstNonGenericCoreInterface("BeautySalonManagement.Domain"));
		}

		static void AddGenericRepositoriesTo(IWindsorContainer container)
		{
			container.Register(
					Component.For(typeof (IEntityDuplicateChecker))
							.ImplementedBy(typeof (EntityDuplicateChecker))
							.Named("entityDuplicateChecker"));

			container.Register(
					Component.For(typeof (INHibernateRepository<>))
							.ImplementedBy(typeof (NHibernateRepository<>))
							.Named("nhibernateRepositoryType")
							.Forward(typeof (IRepository<>)));

			container.Register(
					Component.For(typeof (INHibernateRepositoryWithTypedId<,>))
							.ImplementedBy(typeof (NHibernateRepositoryWithTypedId<,>))
							.Named("nhibernateRepositoryWithTypedId")
							.Forward(typeof (IRepositoryWithTypedId<,>)));

			container.Register(
					Component.For(typeof (ISessionFactoryKeyProvider))
							.ImplementedBy(typeof (DefaultSessionFactoryKeyProvider))
							.Named("sessionFactoryKeyProvider"));

			container.Register(
					Component.For(typeof (ICommandProcessor))
							.ImplementedBy(typeof (CommandProcessor))
							.Named("commandProcessor"));
		}

		static void AddQueryObjectsTo(IWindsorContainer container)
		{
			container.Register(
					AllTypes.FromAssemblyNamed("BeautySalonManagement.Web.Mvc")
							.BasedOn<NHibernateQuery>()
							.WithService.DefaultInterfaces());

			container.Register(
					AllTypes.FromAssemblyNamed("BeautySalonManagement.Infrastructure")
							.BasedOn(typeof (NHibernateQuery))
							.WithService.DefaultInterfaces());
		}

		static void AddHandlersTo(IWindsorContainer container)
		{
			container.Register(
					AllTypes.FromAssemblyNamed("BeautySalonManagement.Tasks")
							.BasedOn(typeof (ICommandHandler<>)).WithService.FirstInterface()
					);
			container.Register(
					AllTypes.FromAssemblyNamed("BeautySalonManagement.Tasks")
							.BasedOn(typeof(ICommandHandler<,>))
							.WithService.FirstInterface());
			container.Register(
					AllTypes.FromAssemblyNamed("BeautySalonManagement.Tasks")
							.BasedOn(typeof (IHandles<>))
							.WithService.FirstInterface());
		}

		static void AddCustom(IWindsorContainer container)
		{
			container.Register(Component.For<IPermissionRepository>().ImplementedBy<PermissionRepository>());
			
			container.Register(Component.For<ICustomFormsAuthentication>().ImplementedBy<CustomFormsAuthentication>());
	
		}
	}
}