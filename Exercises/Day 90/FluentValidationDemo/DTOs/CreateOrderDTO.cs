namespace FluentValidationDemo.DTOs
{
    public class CreateOrderDTO
    {
        public int UserId { get; set; }
        public List<int> ProductIds { get; set; }
        public decimal TotalAmount { get; set; }
    }
}
