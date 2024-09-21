using AngleSharp.Dom;

namespace BunitClarityTest;

public abstract class TestElement
{
    public IElement Element;

    protected TestElement(IElement element)
    {
        Element = element ?? throw new ArgumentNullException(nameof(element));
    }
}
