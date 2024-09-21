using AngleSharp.Dom;

namespace BunitClarityTest;

public class TableRowCellTest : TestElement
{
    public TableRowCellTest(IElement element) : base(element)
    {
    }

    public string Text => Element.TextContent.Trim();
}
