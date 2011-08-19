namespace TestCQRS.BusinessLogic.Commands
{
	public sealed class BookOrderCommandArgs : OrderCommandArgs
	{
		public BookOrderCommandArgs(long orderId)
			: base(orderId)
		{
		}
	}
}
