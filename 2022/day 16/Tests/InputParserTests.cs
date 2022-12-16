namespace Tests;

public class InputParserTests
{
    private Valve FindValveByName(List<Valve> valves, string name)
    {
        var found = valves.Find(valve => valve.Name == name);
        if (found is null)
        {
            throw new ArgumentException("Invalid name given", nameof(name));
        }

        return found;
    }
    
    [Fact]
    public void Parse_ReturnsListOfValves_GivenAdventOfCodeExampleInput()
    {
        // Arrange
        const string input = "Valve AA has flow rate=0; tunnels lead to valves DD, II, BB\n" +
                             "Valve BB has flow rate=13; tunnels lead to valves CC, AA\n" +
                             "Valve CC has flow rate=2; tunnels lead to valves DD, BB\n" +
                             "Valve DD has flow rate=20; tunnels lead to valves CC, AA, EE\n" +
                             "Valve EE has flow rate=3; tunnels lead to valves FF, DD\n" +
                             "Valve FF has flow rate=0; tunnels lead to valves EE, GG\n" +
                             "Valve GG has flow rate=0; tunnels lead to valves FF, HH\n" +
                             "Valve HH has flow rate=22; tunnel leads to valve GG\n" +
                             "Valve II has flow rate=0; tunnels lead to valves AA, JJ\n" +
                             "Valve JJ has flow rate=21; tunnel leads to valve II\n";

        const int expectedValveCount = 10;
        
        var parser = new InputParser();

        // Act
        var results = parser.Parse(input);

        // Assert
        results.Should().HaveCount(expectedValveCount);

        var aa = FindValveByName(results, "AA");
        var bb = FindValveByName(results, "BB");
        var dd = FindValveByName(results, "DD");

        aa.Name.Should().Be("AA");
        aa.FlowRate.Should().Be(0);
        aa.TunnelsToVales.Should()
            .HaveCount(3)
            .And.Contain(bb)
            .And.Contain(dd)
            .And.Contain(valve => valve.Name == "II");
        
        bb.Name.Should().Be("BB");
        bb.FlowRate.Should().Be(13);
        bb.TunnelsToVales.Should()
            .HaveCount(2)
            .And.Contain(aa)
            .And.Contain(valve => valve.Name == "CC");
        
        dd.Name.Should().Be("DD");
        dd.FlowRate.Should().Be(20);
        dd.TunnelsToVales.Should()
            .HaveCount(3)
            .And.Contain(aa)
            .And.Contain(valve => valve.Name == "CC")
            .And.Contain(valve => valve.Name == "EE");
    }
}