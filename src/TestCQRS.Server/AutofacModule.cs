namespace TestCQRS.Server
{
	using Autofac;
	using TestCQRS.Server.Events.Impl;

	internal sealed class AutofacModule : Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			base.Load(builder);

			builder.RegisterType<EventHandlerFactory>().AsImplementedInterfaces().SingleInstance();
		}
	}
}
