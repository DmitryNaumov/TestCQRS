namespace TestCQRS.Infrastructure.ComponentModel.Impl
{
	using System;
	using System.Collections;
	using System.Collections.Generic;
	using System.IO;
	using System.Reflection;

	internal sealed class DirectoryAssemblyEnumerator : IEnumerable<Assembly>
	{
		private readonly string _directoryPath;
		private readonly string _searchPattern;
		private readonly SearchOption _searchOption;

		public DirectoryAssemblyEnumerator(string directoryPath, string searchPattern, SearchOption searchOption)
		{
			_directoryPath = directoryPath;
			_searchPattern = searchPattern;
			_searchOption = searchOption;
		}

		public IEnumerator<Assembly> GetEnumerator()
		{
			foreach (var path in Directory.GetFiles(_directoryPath, _searchPattern, _searchOption))
			{
				var assembly = TryLoadAssembly(path);
				if (assembly == null)
					continue;

				yield return assembly;
			}
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		private static Assembly TryLoadAssembly(string path)
		{
			try
			{
				var assemblyName = AssemblyName.GetAssemblyName(path);
				return Assembly.Load(assemblyName);
			}
			catch (Exception)
			{
				return null;
			}
		}
	}
}
