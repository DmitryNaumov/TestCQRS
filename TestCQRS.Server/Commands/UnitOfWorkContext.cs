namespace TestCQRS.Server.Commands
{
	using System;
	using System.Runtime.Remoting.Messaging;

	public static class UnitOfWorkContext
	{
		public static IUnitOfWork Current
		{
			get
			{
				var unitOfWork = (IUnitOfWork)CallContext.GetData(typeof(IUnitOfWork).FullName);
				if (unitOfWork == null)
				{
					throw new InvalidOperationException("UnitOfWork is not available at the current context.");
				}

				return unitOfWork;
			}
		}
	}
}
