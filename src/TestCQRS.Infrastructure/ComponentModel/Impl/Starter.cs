namespace TestCQRS.Infrastructure.ComponentModel.Impl
{
	using System.Collections.Generic;
	using System.Linq;
	using TestCQRS.Infrastructure.ComponentModel;

	internal sealed class Starter : IStarter
	{
		private readonly IStartable[] _components;

		public Starter(IEnumerable<IStartable> components)
		{
			_components = components.ToArray();
		}

		public void Start()
		{
			foreach (var component in _components)
			{
				component.Start();
			}
		}
	}
}
