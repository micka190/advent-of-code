using System.Drawing;

namespace Tests;

public class SensorTests
{
    [Fact]
    public void DistanceToBeacon_ReturnsExpectedDistance_GivenAdventOfCodeExampleInput()
    {
        // Arrange
        var beacon = new Beacon
        {
            Position = new Point(2, 10)
        };

        var sensor = new Sensor
        {
            Position = new Point(8, 7),
            ClosestBeacon = beacon,
        };

        const int expectedDistance = 9;

        // Act
        var distance = sensor.DistanceToBeacon;

        // Assert
        distance.Should().Be(expectedDistance);
    }
}