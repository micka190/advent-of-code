namespace Tests;

public class RucksackTests
{
    [Fact]
    public void FirstCompartment_ReturnsFirstHalf_OfItems()
    {
        // Arrange
        var items = new List<string>{"A", "B", "C", "1", "2", "3"};
        var rucksack = new Rucksack(items);

        // Act
        var compartment = rucksack.FirstCompartment;

        // Assert
        compartment.Should().BeEquivalentTo(new List<string>{"A", "B", "C"});
    }

    [Fact]
    public void SecondCompartment_ReturnsSecondHalf_OfItems()
    {
        // Arrange
        var items = new List<string>{"A", "B", "C", "1", "2", "3"};
        var rucksack = new Rucksack(items);

        // Act
        var compartment = rucksack.SecondCompartment;

        // Assert
        compartment.Should().BeEquivalentTo(new List<string>{"1", "2", "3"});
    }
}