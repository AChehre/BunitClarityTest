using BlazorTestApp.Components.Orders;
using BlazorTestApp.Models;
using Bunit;

namespace BlazorTestApp.Tests;

public class OrderRowTests : TestContext
{
    [Fact]
    public void DisplaysOrderDataCorrectly()
    {
        Order order = new(1, "Laptop", 5, 1200.00m);

        IRenderedComponent<OrderRow> cut = RenderedComponent(order);

        cut.Markup.Contains("Laptop");
        cut.Markup.Contains("5");
        cut.Markup.Contains("1200.00");
    }

    private IRenderedComponent<OrderRow> RenderedComponent(Order order)
    {
        var cut = RenderComponent<OrderRow>(parameters => parameters
            .Add(p => p.Order, order));
        return cut;
    }
}
