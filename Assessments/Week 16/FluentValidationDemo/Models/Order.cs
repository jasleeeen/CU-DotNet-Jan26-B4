namespace FluentValidationDemo.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int TotalItems { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
