using AngleSharp.Dom;

namespace BunitClarityTest;

public class TableTest : TestElement
{
    public TableTest(IElement element) : base(element)
    {
    }

    public IReadOnlyList<string> Headers()
    {
        List<string> headers = Element.QuerySelectorAll("th").Select(th => th.TextContent.Trim()).ToList();
        if (headers.Count == 0) throw new InvalidOperationException("No headers found in the table.");

        return headers;
    }

    public List<TableRowTest> Rows()
    {
        var headers = Headers().ToList();
        var rows = Element.QuerySelectorAll("tr").Skip(1);

        return rows.Select(row => new TableRowTest(row, headers)).ToList();
    }

    public int GetRowCount()
    {
        return Element.QuerySelectorAll("tr").Count();
    }

    public string GetCellText(int rowIndex, int cellIndex)
    {
        IHtmlCollection<IElement> rows = Element.QuerySelectorAll("tr");
        if (rowIndex >= rows.Length) throw new ArgumentOutOfRangeException(nameof(rowIndex));

        IHtmlCollection<IElement> cells = rows[rowIndex].QuerySelectorAll("td");
        if (cellIndex >= cells.Length) throw new ArgumentOutOfRangeException(nameof(cellIndex));

        return cells[cellIndex].TextContent;
    }

    public bool ColumnContainsText(int columnIndex, string text)
    {
        IHtmlCollection<IElement> rows = Element.QuerySelectorAll("tr");
        foreach (var row in rows)
        {
            var cells = row.QuerySelectorAll("td");
            if (columnIndex < cells.Length && cells[columnIndex].TextContent.Contains(text)) return true;
        }

        return false;
    }

    public int GetColumnCount()
    {
        IElement? headerRow = Element.QuerySelector("tr");
        return headerRow?.QuerySelectorAll("th").Length ?? 0;
    }
}
