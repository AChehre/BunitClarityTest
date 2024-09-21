namespace BlazorTestApp.Models;

public class Order
{
    public Order()
    {
    }

    public Order(int orderId, string orderName, int quantity, decimal price)
    {
        OrderId = orderId;
        OrderName = orderName;
        Quantity = quantity;
        Price = price;
    }
    public int OrderId { get; set; }
    public string OrderName { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
}
