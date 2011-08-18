namespace TestCQRS.Server
{
	using Autofac;
	using TestCQRS.Server.Impl;

	internal sealed class AutofacModule : Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			base.Load(builder);

			builder.RegisterType<Server>().AsImplementedInterfaces().SingleInstance();
		}
	}
}
