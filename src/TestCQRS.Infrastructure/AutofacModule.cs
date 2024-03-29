﻿namespace TestCQRS.Infrastructure
{
	using Autofac;
	using TestCQRS.Infrastructure.ComponentModel.Impl;
	using TestCQRS.Infrastructure.Messaging.Impl;

	internal sealed class AutofacModule : Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			base.Load(builder);

			builder.RegisterType<Starter>().AsImplementedInterfaces().SingleInstance();

			builder.RegisterType<MessageDispatcher>().AsImplementedInterfaces().SingleInstance();
			builder.RegisterType<MessageHandlerFactory>().AsImplementedInterfaces().SingleInstance();
		}
	}
}
