using AngleSharp.Dom;
using Bunit;
using Microsoft.AspNetCore.Components;

namespace BunitClarityTest;

public static class Helper
{
    public static IElement Button<TComponent>(this IRenderedComponent<TComponent> component)
        where TComponent : IComponent
    {
        return component.Find("button");
    }

    public static IElement Buttons<TComponent>(this IRenderedComponent<TComponent> component)
        where TComponent : IComponent
    {
        return component.FindAll("button").First();
    }

    public static TableTest Table<TComponent>(this IRenderedComponent<TComponent> component)
        where TComponent : IComponent
    {
        return new TableTest(component.Find(".mud-table"));
    }
}