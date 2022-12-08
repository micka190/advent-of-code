namespace Solution;

public class TreeGrid
{
    private readonly int[,] _trees;
    
    private readonly int _rows;
    private readonly int _cols;
    private readonly int _rowsEdgeEnd;
    private readonly int _colsEdgeEnd;
    
    private const int RowsEdgeStart = 1;
    private const int ColsEdgeStart = 1;

    public TreeGrid(int[,] trees)
    {
        _trees = trees;
        
        _rows = _trees.GetLength(0);
        _cols = _trees.GetLength(1);
        
        _rowsEdgeEnd = _rows - 1;
        _colsEdgeEnd = _cols - 1;
    }

    public int GetVisibleTrees()
    {
        var mask = GetVisibilityMask();
        var count = GetEdgeCount();
        count += GetVisibleCount(mask);
        return count;
    }

    private bool[,] GetVisibilityMask()
    {
        var mask = new bool[_rows, _cols];
        ApplyHorizontalPasses(mask);
        ApplyVerticalPasses(mask);
        return mask;
    }

    private void ApplyHorizontalPasses(bool[,] mask)
    {
        for (var row = RowsEdgeStart; row < _rowsEdgeEnd; ++row)
        {
            var currentRow = GetRow(row);
            ApplyLeftToRightPasses(mask, currentRow, row);
            ApplyRightToLeftPasses(mask, currentRow, row);
        }
    }

    private void ApplyVerticalPasses(bool[,] mask)
    {
        // Vertical passes
        // Skip edges (col = 1, col < _cols - 1)
        for (var col = ColsEdgeStart; col < _colsEdgeEnd; ++col)
        {
            var currentCol = GetColumn(col);
            ApplyTopToBottomPasses(mask, currentCol, col);
            ApplyBottomToTopPasses(mask, currentCol, col);
        }
    }

    private void ApplyLeftToRightPasses(bool[,] mask, IReadOnlyList<int> currentRow, int row)
    {
        var tallest = currentRow[0];

        for (var col = ColsEdgeStart; col < _colsEdgeEnd; ++col)
        {
            var height = currentRow[col];
            if (height > tallest)
            {
                tallest = height;
                mask[row, col] = true;
            }
        }
    }
    
    private void ApplyRightToLeftPasses(bool[,] mask, IReadOnlyList<int> currentRow, int row)
    {
        var tallest = currentRow[^1];

        for (var col = _colsEdgeEnd - 1; col >= ColsEdgeStart; --col)
        {
            var height = currentRow[col];
            if (height > tallest)
            {
                tallest = height;
                mask[row, col] = true;
            }
        }
    }
    
    private void ApplyTopToBottomPasses(bool[,] mask, IReadOnlyList<int> currentCol, int col)
    {
        var tallest = currentCol[0];

        // Skip edges (row = 1, row < _rows - 1)
        for (var row = RowsEdgeStart; row < _rowsEdgeEnd; ++row)
        {
            var height = currentCol[row];
            if (height > tallest)
            {
                tallest = height;
                mask[row, col] = true;
            }
        }
    }
    
    private void ApplyBottomToTopPasses(bool[,] mask, IReadOnlyList<int> currentCol, int col)
    {
        var tallest = currentCol[^1];

        // Skip edges (row = _rows - 2, row > 0)
        for (var row = _rowsEdgeEnd - 1; row >= RowsEdgeStart; --row)
        {
            var height = currentCol[row];
            if (height > tallest)
            {
                tallest = height;
                mask[row, col] = true;
            }
        }
    }
    
    private int GetEdgeCount() => _rows * 2 + (_cols - 2) * 2;

    private int GetVisibleCount(bool[,] mask)
    {
        var count = 0;
        for (var row = RowsEdgeStart; row < _rowsEdgeEnd; ++row)
        {
            for (var col = ColsEdgeStart; col < _colsEdgeEnd; ++col)
            {
                if (mask[row, col])
                {
                    count++;
                }
            }
        }

        return count;
    }

    private int[] GetColumn(int colIndex) => Enumerable.Range(0, _rows).Select(row => _trees[row, colIndex]).ToArray();
    private int[] GetRow(int rowIndex) => Enumerable.Range(0, _cols).Select(col => _trees[rowIndex, col]).ToArray();
}