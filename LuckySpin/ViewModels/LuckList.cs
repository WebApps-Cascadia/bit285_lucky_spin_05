using LuckySpin.Models;

namespace LuckySpin.ViewModels
{
    public class LuckList
    {
       public IEnumerable<SpinBalance> Balances { get; set; }
       public Player Player { get; set; }
    }

}
