namespace TestCQRS.Infrastructure.ComponentModel
{
	using System;
	using System.Collections.Generic;
	using System.Linq;

	public abstract class ServiceLocatorBase : IServiceLocator
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="ServiceLocatorBase"/> class.
		/// </summary>
		protected ServiceLocatorBase()
		{
		}

		/// <summary>
		/// Cleans up any resources being used.
		/// </summary>
		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		/// <summary>
		/// Cleans up any resources being used.
		/// </summary>
		protected virtual void Dispose(bool disposing)
		{
		}

		/// <summary>
		/// Gets a particular instance from Container.
		/// </summary>
		object IServiceProvider.GetService(Type serviceType)
		{
			return DoGetInstance(serviceType, null);
		}

		/// <summary>
		/// Gets a particular instance from Container.
		/// </summary>
		public object GetInstance(Type serviceType)
		{
			return DoGetInstance(serviceType, null);
		}

		/// <summary>
		/// Gets a particular instance from Container.
		/// </summary>
		public object GetInstance(Type serviceType, string key)
		{
			return DoGetInstance(serviceType, key);
		}

		/// <summary>
		/// Gets a particular instance from Container.
		/// </summary>
		public T GetInstance<T>()
		{
			return (T)DoGetInstance(typeof(T), null);
		}

		/// <summary>
		/// Gets a particular instance from Container.
		/// </summary>
		public T GetInstance<T>(string key)
		{
			return (T)DoGetInstance(typeof(T), null);
		}

		/// <summary>
		/// Gets all instances of a particular type from Container.
		/// </summary>
		public virtual IEnumerable<object> GetAllInstances(Type serviceType)
		{
			return DoGetAllInstances(serviceType);
		}

		/// <summary>
		/// Gets all instances of a particular type from Container.
		/// </summary>
		public IEnumerable<T> GetAllInstances<T>()
		{
			return DoGetAllInstances(typeof(T)).Cast<T>();
		}

		/// <summary>
		/// When implemented in the derived class gets a particular instance from Container.
		/// </summary>
		protected abstract object DoGetInstance(Type serviceType, string key);

		/// <summary>
		/// When implemented in the derived class gets all instances of a particular type from Container.
		/// </summary>
		protected abstract IEnumerable<object> DoGetAllInstances(Type serviceType);
	}
}
