using static LinqProjection.SampleData;

namespace LinqProjection
{
    public class Program
    {
        static void Main(string[] args)
        {
            #region Select

            #region numbers
            var numbers = new[] { 1, 3, 5, 7, 9 };

            var items = numbers.Select(c => c * c);

            foreach (var item in items)
            {
                //Console.WriteLine(item);
            }
            #endregion

            #region names
            var names = new[] { "khaled", "hamza", "eslam" };

            var namesResult = names.Select(c => c.ToUpper());

            foreach (var item in namesResult)
            {
                //Console.WriteLine(item);
            }
            #endregion

            #region Orders 
            //select CustomerId, customerName from orders where customerId=90;

            var ordersResult = SampleData.Orders.Where(c => c.CustomerId == 101).Select(c => new OrderDTO
            {
                CustomerId = c.CustomerId,
                CustomerName = c.CustomerName,
            });

            foreach (var item in ordersResult)
            {
                //item.CustomerId = 90;
                //Console.WriteLine($"Customer id = {item.CustomerId} Customer name= {item.CustomerName}");
            }
            #endregion

            #endregion

            #region Select Many

            #region ex 1
            var groups = new List<List<int>>
            {
                new List<int> { 1, 2, 3 },
                new List<int> { 4, 5, 6 },
                new List<int> { 7, 8, 9 }
            };

            var allNumbers = groups.SelectMany(g => g);

            foreach (var num in allNumbers)
            {
                //Console.WriteLine(num); // Output: 1, 2, 3, 4, 5, 6
            }
            #endregion

            #region ex 2
            var orders = new List<Order>
             {
                  new Order { CustomerId = 1, Products = new List<string> { "Laptop", "Mouse" } },
                  new Order { CustomerId = 2, Products = new List<string> { "Keyboard" } }
             };

            var allProducts = orders.SelectMany(o => o.Products);

            foreach (var product in allProducts)
            {
                Console.WriteLine(product); // Output: Laptop, Mouse, Keyboard
            }

            #endregion

            #endregion

        }
    }


    public class SampleData
    {
        public static List<Order> Orders
        {
            get
            {
                return new List<Order>
             {
                 new Order { OrderId = 1, CustomerId = 101, CustomerName = "Hamza", OrderDate = new DateTime(2023, 3, 1), TotalAmount = 1400, Status = "Completed", PaymentMethod = "Credit Card" },
                 new Order { OrderId = 2, CustomerId = 102, CustomerName = "Eslam", OrderDate = new DateTime(2023, 3, 2), TotalAmount = 1500, Status = "Pending", PaymentMethod = "PayPal" },
                 new Order { OrderId = 3, CustomerId = 101, CustomerName = "Hamza", OrderDate = new DateTime(2023, 3, 5), TotalAmount = 800, Status = "Shipped", PaymentMethod = "Credit Card" },
                 new Order { OrderId = 4, CustomerId = 103, CustomerName = "Zidan", OrderDate = new DateTime(2023, 3, 7), TotalAmount = 500, Status = "Completed", PaymentMethod = "Bank Transfer" },
                 new Order { OrderId = 5, CustomerId = 104, CustomerName = "Omr", OrderDate = new DateTime(2023, 3, 10), TotalAmount = 200, Status = "Pending", PaymentMethod = "Credit Card" }
             };
            }
        }

        public class Order
        {
            public int OrderId { get; set; }
            public int CustomerId { get; set; }
            public string CustomerName { get; set; }
            public DateTime OrderDate { get; set; }
            public decimal TotalAmount { get; set; }
            public string Status { get; set; } //"Pending", "Completed", "Shipped"
            public string PaymentMethod { get; set; } //"Credit Card", "PayPal"
            public List<string> Products { get; set; }
        }

        public class OrderDTO
        {
            public int CustomerId { get; set; }
            public string CustomerName { get; set; }
        }
    }
}
