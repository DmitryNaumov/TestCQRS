namespace TestCQRS.Infrastructure.ComponentModel.Impl
{
	using System;
	using System.Collections;
	using System.Collections.Generic;
	using System.Linq;
	using Autofac;

	internal sealed class AutofacServiceLocator : ServiceLocatorBase
	{
		private readonly IContainer _container;

		public AutofacServiceLocator(IContainer container)
		{
			_container = container;
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				_container.Dispose();
			}

			base.Dispose(disposing);
		}

		protected override object DoGetInstance(Type serviceType, string key)
		{
			return key != null
				? _container.ResolveNamed(key, serviceType)
				: _container.Resolve(serviceType);
		}

		protected override IEnumerable<object> DoGetAllInstances(Type serviceType)
		{
			var enumerableType = typeof(IEnumerable<>).MakeGenericType(serviceType);
			object instance = _container.Resolve(enumerableType);
			return ((IEnumerable)instance).Cast<object>();
		}
	}
}
