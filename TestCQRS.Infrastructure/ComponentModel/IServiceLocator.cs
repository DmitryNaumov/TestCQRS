namespace TestCQRS.Infrastructure.ComponentModel
{
	using System;
	using System.Collections.Generic;

	public interface IServiceLocator : IServiceProvider, IDisposable
	{
		object GetInstance(Type serviceType);
		object GetInstance(Type serviceType, string key);
		IEnumerable<object> GetAllInstances(Type serviceType);

		T GetInstance<T>();
		T GetInstance<T>(string key);
		IEnumerable<T> GetAllInstances<T>();
	}
}
