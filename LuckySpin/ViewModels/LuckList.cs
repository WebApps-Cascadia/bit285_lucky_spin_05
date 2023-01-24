using System;
namespace LuckySpin.ViewModels
{
	public class LuckList
	{
		public string FirstName { get; set; }
		public IEnumerable<SpinBalance> SpinBalances { get; set; }
	}
}

