namespace TestCQRS.Server
{
	public abstract class OrderCommandArgs
	{
		protected OrderCommandArgs(long orderId)
		{
			OrderId = orderId;
		}

		public long OrderId { get; private set; }
	}
}
