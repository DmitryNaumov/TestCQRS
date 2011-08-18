namespace TestCQRS.Infrastructure.ComponentModel.Impl
{
	using System;
	using System.Collections.Generic;
	using System.Linq;

	internal sealed class NullServiceLocator : ServiceLocatorBase
	{
		protected override object DoGetInstance(Type serviceType, string key)
		{
			return null;
		}

		protected override IEnumerable<object> DoGetAllInstances(Type serviceType)
		{
			return Enumerable.Empty<object>();
		}
	}
}
