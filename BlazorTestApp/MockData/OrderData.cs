using BlazorTestApp.Models;

namespace BlazorTestApp.MockData;

public static class OrderData
{
    public static List<Order> GetMockOrders()
    {
        return new List<Order>
        {
            new(1, "Laptop", 5, 1200.00m),
            new(2, "Smartphone", 10, 800.00m),
            new(3, "Tablet", 7, 500.00m),
        };
    }
}
