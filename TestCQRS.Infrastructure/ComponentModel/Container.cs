namespace TestCQRS.Infrastructure.ComponentModel
{
	using System;
	using System.Collections.Generic;
	using System.IO;
	using System.Reflection;
	using Autofac;
	using TestCQRS.Infrastructure.ComponentModel.Impl;

	public static class Container
	{
		public static ContainerBuilder Compose()
		{
			return new ContainerBuilder();
		}

		public sealed class ContainerBuilder
		{
			private readonly Autofac.ContainerBuilder _builder = new Autofac.ContainerBuilder();

			internal ContainerBuilder()
			{
			}

			public ContainerBuilder FromAssembly(params Assembly[] assemblies)
			{
				return FromAssembly((IEnumerable<Assembly>)assemblies);
			}

			public ContainerBuilder FromAssembly(IEnumerable<Assembly> assemblies)
			{
				foreach (var assembly in assemblies)
				{
					// TODO: use assembly attribute
					foreach (var type in assembly.GetTypes())
					{
						if (!type.IsAbstract && typeof(Autofac.Core.IModule).IsAssignableFrom(type))
						{
							var module = (Autofac.Core.IModule)Activator.CreateInstance(type);
							_builder.RegisterModule(module);
						}
					}
				}

				return this;
			}

			public ContainerBuilder FromDirectory(string directoryPath, string searchPattern, SearchOption searchOption)
			{
				FromAssembly(new DirectoryAssemblyEnumerator(directoryPath, searchPattern, searchOption));

				return this;
			}

			public ContainerBuilder FromExternalComponent<TComponent>(TComponent instance) where TComponent : class
			{
				_builder.RegisterInstance(instance);

				return this;
			}

			public IServiceLocator Build()
			{
				return new AutofacServiceLocator(_builder.Build());
			}
		}
	}
}
