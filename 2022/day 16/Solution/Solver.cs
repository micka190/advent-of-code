namespace Solution;

public class Solver
{
    private readonly InputParser _parser;
    private readonly GraphDistanceMapper _distanceMapper;

    public Solver(InputParser parser, GraphDistanceMapper distanceMapper)
    {
        _parser = parser;
        _distanceMapper = distanceMapper;
    }

    public int SolveForPartOne(string input)
    {
        const int totalMinutes = 30;
        const int maxMovementMinutes = 28;
        
        var nodes = _parser.Parse(input);
        var graph = new Graph(nodes, nodes[0]);

        _distanceMapper.MapDistanceBetweenValueNodes(graph);

        var nodesWithoutStartingNode = _distanceMapper.NodesUsed.Where(node => node != graph.StartingNode).ToList();

        var permutations = Permute(nodesWithoutStartingNode)
            .Select(permutation => permutation.Prepend(graph.StartingNode).ToList()).ToList();
        
        var scores = new List<int>();

        foreach (var permutation in permutations)
        {
            if (DistanceInPermutation(permutation) <= maxMovementMinutes)
            {
                scores.Add(GetScore(permutation, totalMinutes));
            }
        }

        return scores.Max();
    }

    private int DistanceInPermutation(List<Node> nodes)
    {
        var distance = 0;
        for (var i = 0; i < nodes.Count - 1; ++i)
        {
            var start = nodes[i];
            var end = nodes[i + 1];
            distance += _distanceMapper.GetDistance(start, end);
        }

        return distance;
    }

    private int GetScore(List<Node> nodes, int minutesRemaining)
    {
        const int minutesNeededToOpenValve = 1;
        
        var score = 0;

        for (var i = 0; i < nodes.Count - 1 && minutesRemaining > 0; ++i)
        {
            var start = nodes[i];
            var end = nodes[i + 1];

            var distance = _distanceMapper.GetDistance(start, end);
            minutesRemaining -= distance;
            minutesRemaining -= minutesNeededToOpenValve;
            score += minutesRemaining * end.Value;
        }

        return score;
    }

    private static IEnumerable<IEnumerable<Node>> Permute(IEnumerable<Node> sequence)
    {
        var list = sequence.ToList();

        if (list.Count == 0)
        {
            yield return Enumerable.Empty<Node>();
        }
        else
        {
            var start = 0;

            foreach (var startingElement in list)
            {
                var index = start;
                var remainingItems = list.Where((_, i) => i != index);

                foreach (var permutationOfRemainder in Permute(remainingItems))
                {
                    yield return permutationOfRemainder.Prepend(startingElement);
                }

                start++;
            }
        }
    }
}