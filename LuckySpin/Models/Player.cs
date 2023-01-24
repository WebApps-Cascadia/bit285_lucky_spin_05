using System.ComponentModel.DataAnnotations;
namespace LuckySpin.Models
{
    public class Player //TODO: Add and Annotate a decimal property called Balance
    {

        [Required(ErrorMessage ="Name is required")]
        public string FirstName { get; set; }

        [Required(ErrorMessage ="Number must be chosen")]
        [Range(1,10, ErrorMessage = "Choose a number, 1-10")]
        public int Luck { get; set; }

        [Required(ErrorMessage ="Bet must be chosen")]
        [Range(3.0,10.0, ErrorMessage ="Choose a starting bet, 3-10")]
        public decimal Balance { get; set; }
    }
}