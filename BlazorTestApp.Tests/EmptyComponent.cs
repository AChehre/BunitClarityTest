using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace BlazorTestApp.Tests;

public class EmptyComponent : ComponentBase
{
    protected override void BuildRenderTree(RenderTreeBuilder builder)
    {
    }
}
