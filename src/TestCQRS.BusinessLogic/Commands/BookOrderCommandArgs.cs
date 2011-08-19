namespace TestCQRS.Server
{
	public sealed class BookOrderCommandArgs : OrderCommandArgs
	{
		public BookOrderCommandArgs(long orderId)
			: base(orderId)
		{
		}
	}
}
