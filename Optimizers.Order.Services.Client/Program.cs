using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace HttpClientSample
{
    public class User
    {
        public long Id { get; set; }

        public string UserName { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;

        public string FullName { get; set; } = string.Empty;
    }

    public class Order
    {
        public long Id { get; set; }
        public int? OrderNumber { get; set; }

        public DateTime OrderDate { get; set; } = DateTime.Now;

        public string? Reference { get; set; }

        public string CustomerName { get; set; } = string.Empty;

        public ICollection<OrderLine> OrderLines { get; set; } = new List<OrderLine>();
    }

    public class OrderLine
    {
        public long Id { get; set; }

        public Order Order { get; set; }

        public int? LineNumber { get; set; }

        public string ItemCode { get; set; } = string.Empty;

        public decimal Quantity { get; set; } = decimal.Zero;

        public decimal Price { get; set; } = decimal.Zero;
    }

    class Program
    {
        static HttpClient client = new HttpClient();

        static async Task<Uri> CreateUserAsync(User user)
        {
            HttpResponseMessage response = await client.PostAsJsonAsync(
                "user", user);
            response.EnsureSuccessStatusCode();

            return response.Headers.Location;
        }

        static void Main()
        {
            RunAsync().GetAwaiter().GetResult();
        }

        static async Task RunAsync()
        {
            client.BaseAddress = new Uri("https://localhost:7232/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            try
            {
                List<User> users = new()
                {
                    new User
                    {
                        UserName = "bob",
                        Password = Guid.NewGuid().ToString(),
                        FullName = "bob dylan"
                    },
                    new User
                    {
                        UserName = "paul",
                        Password = Guid.NewGuid().ToString(),
                        FullName = "paul mccartney"
                    }
                };

                foreach (var u in users)
                {
                    var url = await CreateUserAsync(u);
                    Console.WriteLine($"Created at {url}");
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadLine();
        }
    }
}