using System.Drawing;

namespace Solution;

public class Rope
{
    private Point Head { get; set; }
    private Point Tail { get; set; }

    public readonly HashSet<Point> UniqueTailPositions;

    public Rope()
    {
        Head = new Point();
        Tail = new Point();
        UniqueTailPositions = new HashSet<Point> { Tail };
    }

    public void PerformMotion(Motion motion)
    {
        for (var i = 0; i < motion.Steps; ++i)
        {
            Head = Move(Head, motion.Direction);

            if (!KnotsTouching())
            {
                FollowHeadWithTail(motion.Direction);
            }
        }
    }

    private static Point Move(Point original, Direction direction) =>
        direction switch
        {
            Direction.Up => original with { Y = original.Y + 1 },
            Direction.Down => original with { Y = original.Y - 1 },
            Direction.Left => original with { X = original.X - 1 },
            Direction.Right => original with { X = original.X + 1 },
            _ => throw new ArgumentOutOfRangeException(nameof(direction), direction, "Unsupported direction")
        };

    private bool KnotsTouching()
    {
        // Overlapping counts as touching.
        var overlapping = Head == Tail;

        var deltaX = Math.Abs(Head.X - Tail.X);
        var deltaY = Math.Abs(Head.Y - Tail.Y);

        var touchingX = deltaX == 1 && deltaY == 0;
        var touchingY = deltaY == 1 && deltaX == 0;
        var touchingDiagonally = deltaX == 1 && deltaY == 1;

        return overlapping || touchingX || touchingY || touchingDiagonally;
    }

    private void FollowHeadWithTail(Direction lastHeadDirection)
    {
        // This method is only called when Head and Tail are NOT touching.
        // If BOTH axis are not equal, then Head and Tail were touching diagonally, and Head has just moved away from Tail.
        // When this happens, Tail must move diagonally towards Head (they end up sharing the same X or Y value afterwards).
        
        var requiresDiagonalMovement = Head.X != Tail.X && Head.Y != Tail.Y;

        var headMovedHorizontally = lastHeadDirection is Direction.Right or Direction.Left;
        var headMovedVertically = lastHeadDirection is Direction.Up or Direction.Down;

        Tail = Move(Tail, lastHeadDirection);

        if (requiresDiagonalMovement)
        {
            if (headMovedHorizontally)
            {
                Tail = Tail with { Y = Head.Y };
            }
            else if (headMovedVertically)
            {
                Tail = Tail with { X = Head.X };
            }
        }

        UniqueTailPositions.Add(Tail);
    }
}