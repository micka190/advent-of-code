namespace Tests;

public class RucksackTests
{
    [Fact]
    public void FirstCompartment_ReturnsFirstHalf_OfItems()
    {
        // Arrange
        const string items = "ABC123";
        var rucksack = new Rucksack(items);

        // Act
        var compartment = rucksack.FirstCompartment;

        // Assert
        compartment.Should().BeEquivalentTo(new List<char>{'A', 'B', 'C'});
    }

    [Fact]
    public void SecondCompartment_ReturnsSecondHalf_OfItems()
    {
        // Arrange
        const string items = "ABC123";
        var rucksack = new Rucksack(items);

        // Act
        var compartment = rucksack.SecondCompartment;

        // Assert
        compartment.Should().BeEquivalentTo(new List<char>{'1', '2', '3'});
    }

    [Fact]
    public void OverlappingItemTypes_ReturnsItemTypesPresent_InBothCompartments()
    {
        // Arrange
        const char overlapping = 'A';
        var items = $"{overlapping}BC12{overlapping}";
        var rucksack = new Rucksack(items);

        // Act
        var overlappingItemTypes = rucksack.OverlappingItemTypes;

        // Assert
        overlappingItemTypes.Should().BeEquivalentTo(new List<char> { overlapping });
    }
}