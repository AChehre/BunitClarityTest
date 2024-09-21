using AngleSharp.Common;
using AngleSharp.Dom;

namespace BunitClarityTest;

public class TableRowTest : TestElement

{
    private Dictionary<string, TableRowCellTest> _cellsByHeader;
    private readonly IReadOnlyList<string> _headers;

    public TableRowTest(IElement element, IReadOnlyList<string> headers) : base(element)
    {
        _headers = headers;
        var cells = Element.QuerySelectorAll("td").Select(td => new TableRowCellTest(td)).ToList();
        if (cells.Count != _headers.Count)
            throw new InvalidOperationException("Mismatch between the number of headers and the number of cells in the row.");

        _cellsByHeader = _headers.Zip(cells, (headerText, cell) => new { header = headerText, cell })
                             .ToDictionary(x => x.header, x => x.cell);
    }

    public TableRowCellTest this[string header] => _cellsByHeader[header];
    public TableRowCellTest this[int index] => _cellsByHeader.GetItemByIndex(index).Value;
}