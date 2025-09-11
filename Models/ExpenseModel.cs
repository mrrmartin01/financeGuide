using System.ComponentModel.DataAnnotations;

namespace financeGuide.Models
{
    public class Expense
    {
        public int Id { get; set; }
        [Required]
        public string Description { get; set; } = null!;
        [Required]
        [Range(0.1, double.MaxValue, ErrorMessage = "Amount has to be greater than zero")]
        public double Amount { get; set; }
        [Required]
        public string Category { get; set; } = null!;
        public DateTime Date { get; set; } = DateTime.Now;
    }
}