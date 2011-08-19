namespace TestCQRS.Infrastructure.ComponentModel
{
	using System;

	[Serializable]
	public sealed class Exception<TArgs> : Exception
	{
		public Exception(TArgs args, string message)
			: base(message)
		{
			Args = args;
		}

		public TArgs Args { get; private set; }
	}
}
