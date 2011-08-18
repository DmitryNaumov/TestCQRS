namespace TestCQRS.Infrastructure.ComponentModel
{
	using TestCQRS.Infrastructure.ComponentModel.Impl;

	public static class ServiceLocator
	{
		private static IServiceLocator _currentInstance;

		/// <summary>
		/// Gets or sets the currently used implementation of the <see cref="IServiceLocator"/>.
		/// </summary>
		public static IServiceLocator Current
		{
			get
			{
				return _currentInstance ?? Singleton<NullServiceLocator>.Instance;
			}
			set
			{
				_currentInstance = value;
			}
		}
	}
}
