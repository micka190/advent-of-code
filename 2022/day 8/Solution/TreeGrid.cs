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

    public int GetHighestScenicScore()
    {
        var scores = GetScenicScores();
        
        var highestScore = 0;
        for (var row = 0; row < _rows; ++row)
        {
            for (var col = 0; col < _cols; ++col)
            {
                var score = scores[row, col];
                if (score > highestScore)
                {
                    highestScore = score;
                }
            }
        }

        return highestScore;
    }

    private int[,] GetScenicScores()
    {
        var scores = new int[_rows, _cols];

        for (var row = RowsEdgeStart; row < _rowsEdgeEnd; ++row)
        {
            for (var col = ColsEdgeStart; col < _colsEdgeEnd; ++col)
            {
                scores[row, col] = GetScenicScore(row, col);
            }
        }
        
        return scores;
    }

    private int GetScenicScore(int row, int col)
    {
        var left = 0;
        var right = 0;
        var top = 0;
        var bottom = 0;
        
        var currentTree = _trees[row, col];
        
        for (var c = col - 1; c >= 0; --c)
        {
            if (c == 0 || _trees[row, c] == currentTree)
            {
                left++;
                break;
            }
            
            if (_trees[row, c] < currentTree)
            {
                left++;
            }
        }
        
        for (var c = col + 1; c < _cols; ++c)
        {
            if (c == _cols - 1 || _trees[row, c] == currentTree)
            {
                right++;
                break;
            }
            
            if (_trees[row, c] < currentTree)
            {
                
                right++;
            }
        }
        
        for (var r = row - 1; r >= 0; --r)
        {
            if (r == 0 || _trees[r, col] == currentTree)
            {
                top++;
                break;
            }
            
            if (_trees[r, col] < currentTree)
            {
                top++;
            }
        }
        
        
        for (var r = row + 1; r < _rows; ++r)
        {
            if (r == _rows - 1 || _trees[r, col] == currentTree)
            {
                bottom++;
                break;
            }
            
            if (_trees[r, col] < currentTree)
            {
                bottom++;
            }
        }
        

        return left * right * top * bottom;
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