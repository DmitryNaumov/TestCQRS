namespace TestCQRS.Infrastructure
{
	using Autofac;
	using TestCQRS.Infrastructure.ComponentModel.Impl;

	internal sealed class AutofacModule : Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			base.Load(builder);

			builder.RegisterType<Starter>().AsImplementedInterfaces().SingleInstance();
		}
	}
}
