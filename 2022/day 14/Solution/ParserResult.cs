using System.Drawing;

namespace Solution;

public record ParserResult(List<List<Point>> Paths, Point Max, Point Min);
