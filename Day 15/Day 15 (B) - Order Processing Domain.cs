namespace Order_Processing_Domain
{
    class Order
    {
        private int _orderId;
        private string _customerName;
        private decimal _totalAmount;
        private DateTime _orderDate;
        private string _status;
        private bool _discountApplied;
        public Order()
        {
            _orderDate = DateTime.Now;
            _status = "NEW";
            _totalAmount = 0;
            _discountApplied = false;
        }
        public Order(int orderId, string customerName)
        {
            _orderDate = DateTime.Now;
            _status = "NEW";
            _totalAmount = 0;
            _discountApplied = false;
            _orderId = orderId;
            CustomerName = customerName;
        }
        public int OrderId
        {
            get { return _orderId; }
        }
        public string CustomerName
        {
            get { return _customerName; }
            set { 
                if (string.IsNullOrWhiteSpace(value)) Console.WriteLine("Inalid name.");
                _customerName = value; 
            }
        }
        public decimal TotalAmount
        {
            get { return _totalAmount; }
        }
        public void AddItem(decimal price)
        {
            if (price < 0)
                Console.WriteLine("Total amount cannot be negative");
            _totalAmount += price;
        }
        public void ApplyDiscount(decimal percentage)
        {
            if (_discountApplied)
                Console.WriteLine("Discount must be applied only once per order");
            if (percentage < 1 || percentage > 30)
                Console.WriteLine("Discount must be between 1 and 30");
            _totalAmount = _totalAmount - (_totalAmount * percentage / 100);
            _discountApplied = true;
        }
        public string GetOrderSummary()
        {
            return $"Order Id: {OrderId}\n" +
                   $"Customer: {CustomerName}\n" +
                   $"Total Amount: {TotalAmount:0}\n" +
                   $"Status: {_status}";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Order order1 = new Order(101, "Rahul");
            order1.AddItem(500);
            order1.AddItem(300);
            order1.ApplyDiscount(10);
            Console.WriteLine(order1.GetOrderSummary());
            Console.WriteLine();
        }
    }
}