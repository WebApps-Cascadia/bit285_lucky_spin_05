using System;
using System.Linq;
namespace LuckySpin.Models
{
    public class Spin
    {
        Random random = new Random();
        private int[] numbers; //a spin array;

        //Constructor
        public Spin()
        {
            numbers = new int[] { random.Next(10), random.Next(10), random.Next(10) };
        }

        //Spin Properties
        public int[] Numbers //Read only - the spin numbers are set in the constructor
        { 
            get { return numbers; }
        } 
     
        public bool IsWinning //Read only - true if Player's Luck is one of the numbers
        {
            get { return numbers.Contains(Player.Luck); }
        }

        public Player Player { get; set; } //Read-Write set as needed in the controller
    }

}
