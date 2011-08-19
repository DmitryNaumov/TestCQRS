namespace TestCQRS.BusinessLogic
{
	using Autofac;
	using TestCQRS.BusinessLogic.Commands.Impl;

	internal sealed class AutofacModule : Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			base.Load(builder);

			builder.RegisterType<BookOrderCommandHandler>().AsImplementedInterfaces();
		}
	}
}
