using System;
using System.Collections.Generic;
using LuckySpin.Models;
using LuckySpin.ViewModels;

namespace LuckySpin.Services
{
    public class Repository
    {
        private List<SpinBalance> spinBalances = new List<SpinBalance>();
     
        //Properties: a Player and a list of SpinBalance objects (one for each spin)
        public Player Player { get; set; }
        public IEnumerable<SpinBalance> SpinBalances {
            get { return spinBalances; }
        }


        //Access method
        public void AddSpinBalance(Spin spin, decimal balance)
        {
            spinBalances.Add(new SpinBalance
            {
                Numbers = spin.Numbers,
                IsWinning = spin.IsWinning,
                Balance = balance
            });
        }
        //Game Reset - Use this to refresh the list of spin-balance
        public void ResetGame()
        {
            spinBalances.Clear();
        }

    }

}
