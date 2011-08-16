namespace TestCQRS.Infrastructure.ComponentModel
{
	using System.Collections.Generic;
	using System.IO;
	using System.Reflection;

	public static class Registrar
	{
		public static IServiceLocator FromDirectory(string directoryPath, string searchPattern, SearchOption searchOption)
		{
			return Container.Compose().FromDirectory(directoryPath, searchPattern, searchOption).Build();
		}

		public static IServiceLocator FromAssemblies(IEnumerable<Assembly> assemblies)
		{
			return Container.Compose().FromAssembly(assemblies).Build();
		}
	}
}
