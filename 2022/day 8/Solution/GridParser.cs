namespace Solution;

public class GridParser
{
    public int[,] Parse(string input)
    {
        if (string.IsNullOrEmpty(input))
        {
            throw new ArgumentNullException(nameof(input), "Input must not be null or empty.");
        }

        var lines = input.Trim().Split('\n');
        
        var height = lines.Length;
        var width = lines[0].Length;

        var grid = new int[height, width];
        
        for (var col = 0; col < width; ++col)
        {
            for (var row = 0; row < height; ++row)
            {
                grid[row, col] = int.Parse(lines[row][col].ToString());
            }
        }

        return grid;
    }
}