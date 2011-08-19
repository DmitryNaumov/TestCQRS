namespace TestCQRS.BusinessLogic.DomainModel.Builders.Impl
{
	internal sealed class SecurityBuilder : ISecurityBuilder
	{
		private Security _security;
		private string _name;
		private string _cusip;

		public SecurityBuilder()
		{
		}

		public SecurityBuilder(Security security)
		{
			_security = security;
		}

		public ISecurityBuilder Equity()
		{
			return this;
		}

		public ISecurityBuilder Name(string name)
		{
			_name = name;
			return this;
		}

		public ISecurityBuilder CUSIP(string cusip)
		{
			_cusip = cusip;
			return this;
		}
	}
}
