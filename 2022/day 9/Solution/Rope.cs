using System.Drawing;

namespace Solution;

public class Rope
{
    private readonly List<Point> _knots;

    public readonly HashSet<Point> UniqueTailPositions;

    public Rope(int numberOfKnots = 2)
    {
        if (numberOfKnots < 2)
        {
            throw new ArgumentException("Must have at least 2 knots in Rope.", nameof(numberOfKnots));
        }

        _knots = Enumerable.Range(0, numberOfKnots).Select(_ => new Point()).ToList();
        UniqueTailPositions = new HashSet<Point> { _knots.Last() };
    }

    public void PerformMotion(Motion motion)
    {
        for (var i = 0; i < motion.Steps; ++i)
        {
            var headIndex = 0;
            _knots[headIndex] = Move(_knots[headIndex], motion.Direction);

            for (var tailIndex = 1; tailIndex < _knots.Count; ++tailIndex)
            {
                headIndex = tailIndex - 1;
                
                if (!KnotsTouching(_knots[headIndex], _knots[tailIndex]))
                {
                    _knots[tailIndex] = Follow(_knots[headIndex], _knots[tailIndex], motion.Direction);
                    UniqueTailPositions.Add(_knots[tailIndex]);
                }
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

    private bool KnotsTouching(Point head, Point tail)
    {
        // Overlapping counts as touching.
        var overlapping = head == tail;

        var deltaX = Math.Abs(head.X - tail.X);
        var deltaY = Math.Abs(head.Y - tail.Y);

        var touchingX = deltaX == 1 && deltaY == 0;
        var touchingY = deltaY == 1 && deltaX == 0;
        var touchingDiagonally = deltaX == 1 && deltaY == 1;

        return overlapping || touchingX || touchingY || touchingDiagonally;
    }

    private Point Follow(Point head, Point tail, Direction lastHeadDirection)
    {
        // This method is only called when Head and Tail are NOT touching.
        // If BOTH axis are not equal, then Head and Tail were touching diagonally, and Head has just moved away from Tail.
        // When this happens, Tail must move diagonally towards Head (they end up sharing the same X or Y value afterwards).

        var requiresDiagonalMovement = head.X != tail.X && head.Y != tail.Y;

        var headMovedHorizontally = lastHeadDirection is Direction.Right or Direction.Left;
        var headMovedVertically = lastHeadDirection is Direction.Up or Direction.Down;

        var nextTail = Move(tail, lastHeadDirection);

        if (requiresDiagonalMovement)
        {
            if (headMovedHorizontally)
            {
                nextTail = nextTail with { Y = head.Y };
            }
            else if (headMovedVertically)
            {
                nextTail = nextTail with { X = head.X };
            }
        }

        return nextTail;
    }
}