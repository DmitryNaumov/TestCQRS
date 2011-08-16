namespace TestCQRS.Infrastructure.ComponentModel
{
	using System.Diagnostics;

	public static class Singleton<T> where T : new()
	{
		// ReSharper disable StaticFieldInGenericType
		private static readonly T SingletonInstance = new T();
		// ReSharper restore StaticFieldInGenericType

		public static T Instance
		{
			[DebuggerStepThrough]
			get
			{
				return SingletonInstance;
			}
		}
	}
}
