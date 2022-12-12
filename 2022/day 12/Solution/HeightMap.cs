namespace Solution;

public class HeightMap
{
    private const char StartValue = 'S';
    private const char EndValue = 'E';
    private const char SecondValue = 'a';
    private const char SecondToLastValue = 'z';

    public readonly int Columns;
    public readonly int Rows;

    public readonly Cell[,] Grid;
    public readonly Cell Start;
    public readonly Cell End;

    private readonly Dictionary<Cell, List<Cell>> _neighbors = new();

    public HeightMap(string mapRepresentation)
    {
        var lines = mapRepresentation.Trim().Split('\n');

        Columns = lines[0].Length;
        Rows = lines.Length;

        Grid = new Cell[Rows, Columns];

        for (var row = 0; row < Rows; ++row)
        {
            for (var col = 0; col < Columns; ++col)
            {
                var cell = new Cell(col, row, lines[row][col]);
                
                Grid[row, col] = cell;
                
                if (cell.Value == StartValue)
                {
                    Start = cell;
                }
                else if (cell.Value == EndValue)
                {
                    End = cell;
                }
            }
        }

        if (Start is null)
        {
            throw new FormatException("Could not find Start position in map representation");
        }

        if (End is null)
        {
            throw new FormatException("Could not find End position in map representation");
        }

        for (var row = 0; row < Rows; ++row)
        {
            for (var col = 0; col < Columns; ++col)
            {
                var cell = Grid[row, col];
                
                var leftNeighbor = GetCellIfInBounds(row, col - 1);
                var rightNeighbor = GetCellIfInBounds(row, col + 1);
                var upNeighbor = GetCellIfInBounds(row - 1, col);
                var downNeighbor = GetCellIfInBounds(row + 1, col);

                var neighbors = new List<Cell?>
                {
                    leftNeighbor, rightNeighbor, upNeighbor, downNeighbor,
                };

                _neighbors[cell] = neighbors
                    .Where(neighbor => neighbor is not null && IsValidNeighbor(cell, neighbor))
                    .Select(neighbor => neighbor!)
                    .ToList();
            }
        }
    }

    public List<Cell> GetNeighbors(Cell cell) => _neighbors[cell];

    public Cell this[int x, int y] => Grid[y, x]; // Note: Grid[row, col] = Grid[y, x].

    private Cell? GetCellIfInBounds(int row, int col) =>
        row >= 0 && row < Rows && col >= 0 && col < Columns
            ? Grid[row, col]
            : null;

    private static bool IsValidNeighbor(Cell current, Cell neighbor)
    {
        if (current.Value == StartValue)
        {
            return neighbor.Value == SecondValue;
        }

        if (neighbor.Value == EndValue)
        {
            return current.Value == SecondToLastValue ;
        }

        return neighbor.Value == StartValue || neighbor.Value - current.Value <= 1;
    }
}