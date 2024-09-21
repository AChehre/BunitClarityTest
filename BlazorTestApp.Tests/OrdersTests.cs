using BlazorTestApp.Components.Orders;
using BlazorTestApp.MockData;
using BlazorTestApp.Models;
using Bunit;
using BunitClarityTest;

namespace BlazorTestApp.Tests;

public class OrdersTests : TestContext
{
    [Fact]
    public void Table_should_assert_table_exist()
    {
        IRenderedComponent<Orders> cut = RenderedComponent();

        cut.Table();
    }

    [Fact]
    public void Table_should_throw_exception_if_table_does_not_exist()
    {
        IRenderedComponent<EmptyComponent> cut = RenderComponent<EmptyComponent>();

        Assert.Throws<ElementNotFoundException>(() => cut.Table());
    }

    [Fact]
    public void Table_Should_Contain_Order_Headers()
    {
        var cut = RenderedComponent();

        var table = cut.Table();
        IEnumerable<string> headers = table.Headers();

        var expectedHeaders = new List<string> { "Order Id", "Order Name", "Quantity", "Price ($)", "Actions" };
        Assert.True(expectedHeaders.All(h => headers.Contains(h)));
    }

    [Fact]
    public void Table_Should_Contain_Correct_Row_Data()
    {
        var order = new Order(1, "Laptop", 5, 1200.00m);
        List<Order> orders = OrderData.GetMockOrders();

        var cut = RenderedComponent();

        var table = cut.Table();
        var rows = table.Rows();

        Assert.Equal("1", rows[0]["Order Id"].Text);
        Assert.Equal("Laptop", rows[0]["Order Name"].Text);
        Assert.Equal("5", rows[0]["Quantity"].Text);
        Assert.Equal("1200.00", rows[0]["Price ($)"].Text);
    }

    private IRenderedComponent<Orders> RenderedComponent()
    {
        IRenderedComponent<Orders> cut = RenderComponent<Orders>();
        return cut;
    }
}
