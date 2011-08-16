namespace TestCQRS.ServerHost
{
	using System;
	using System.IO;
	using TestCQRS.Infrastructure.ComponentModel;

	internal static class Program
	{
		private static void Main()
		{
			try
			{
				using (var container = Registrar.FromDirectory(AppDomain.CurrentDomain.BaseDirectory, "TestCQRS.*.dll", SearchOption.TopDirectoryOnly))
				{
					var starter = container.GetInstance<IStarter>();
					starter.Start();

					Console.WriteLine("Hit <Enter> to exit...");
					Console.ReadLine();
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.ToString());
				Console.ReadLine();
			}
		}
	}
}
