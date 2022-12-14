using System.Drawing;

namespace Solution;

public class CaveSlice
{
    public const int SandOriginX = 500;
    public const int SandOriginY = 0;
    
    public readonly int Width;
    public readonly int Height;
    public readonly Cell[,] Grid;

    public CaveSlice(int width, int height, List<List<Point>> stonePaths)
    {
        Width = width;
        Height = height;
        Grid = new Cell[Height, Width];

        for (var y = 0; y < Height; ++y)
        {
            for (var x = 0; x < Width; ++x)
            {
                Grid[y, x] = Cell.Air;
            }
        }

        foreach (var path in stonePaths)
        {
            for (var i = 0; i < path.Count - 1; ++i)
            {
                var from = path[i];
                var to = path[i + 1];
                DrawLine(Grid, from, to, Cell.Stone);
            }
        }

        Grid[SandOriginY, SandOriginX] = Cell.SandOrigin;
    }
    
    public Cell this[int x, int y]
    {
        // 2D arrays are [row,col], so we need to use [y,x] given (x,y).
        get => Grid[y, x];
        set => Grid[y, x] = value;
    }

    public string Visualize(char air = '.', char stone = '#', char sand = 'O', char sandOrigin = '+') =>
        VisualizeChunk(new Point(0, 0), new Point(Width - 1, Height - 1));

    /// Inclusive bounds for start and end points.
    public string VisualizeChunk(Point start, Point end, char air = '.', char stone = '#', char sand = 'O', char sandOrigin = '+')
    {
        if (start.X < 0 || start.X + 1 > Width || start.Y < 0 || start.Y + 1 > Height)
        {
            throw new ArgumentException("Invalid start position", nameof(start));
        }
        
        if (end.X < 0 || end.X + 1 > Width || end.Y < 0 || end.Y + 1 > Height)
        {
            throw new ArgumentException("Invalid end position", nameof(end));
        }
        
        var visualization = string.Empty;
        
        for (var y = start.Y; y <= end.Y; ++y)
        {
            for (var x = start.X; x <= end.X; ++x)
            {
                var cell = Grid[y, x];
                var character = cell switch
                {
                    Cell.Air => air,
                    Cell.Stone => stone,
                    Cell.Sand => sand,
                    Cell.SandOrigin => sandOrigin,
                    _ => throw new ArgumentOutOfRangeException(nameof(cell), cell, "Unsupported Cell value")
                };
                visualization += character;
            }

            visualization += '\n';
        }

        return visualization.Trim();
    }
    
    private static void DrawLine(Cell[,] grid, Point from, Point to, Cell stroke)
    {
        if (from == to)
        {
            grid[from.Y, from.X] = stroke;
        }
        else if (from.X != to.X)
        {
            DrawHorizontalLine(grid, from, to, stroke);
        }
        else if (from.Y != to.Y)
        {
            DrawVerticalLine(grid, from, to, stroke);
        }
    }

    private static void DrawHorizontalLine(Cell[,] grid, Point from, Point to, Cell strokeCharacter)
    {
        var start = Math.Min(from.X, to.X);
        var end = Math.Max(from.X, to.X);
        
        // NOTE: "<=" because coordinates have inclusive bounds.
        for (var x = start; x <= end; ++x)
        {
            grid[from.Y, x] = strokeCharacter;
        }
    }
    
    private static void DrawVerticalLine(Cell[,] grid, Point from, Point to, Cell strokeCharacter)
    {
        var start = Math.Min(from.Y, to.Y);
        var end = Math.Max(from.Y, to.Y);
        
        // NOTE: "<=" because coordinates have inclusive bounds.
        for (var y = start; y <= end; ++y)
        {
            grid[y, from.X] = strokeCharacter;
        }
    }
}