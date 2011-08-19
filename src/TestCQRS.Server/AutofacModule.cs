namespace TestCQRS.Server
{
	using Autofac;
	using TestCQRS.Server.Facade.Impl;

	internal sealed class AutofacModule : Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			base.Load(builder);

			builder.RegisterType<Server>().AsImplementedInterfaces().SingleInstance();
		}
	}
}
