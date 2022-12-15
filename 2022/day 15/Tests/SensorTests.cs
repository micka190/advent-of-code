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
            Position = new Coordinate(2, 10)
        };

        var sensor = new Sensor
        {
            Position = new Coordinate(8, 7),
            ClosestBeacon = beacon,
        };

        const int expectedDistance = 9;

        // Act
        var distance = sensor.DistanceToBeacon;

        // Assert
        distance.Should().Be(expectedDistance);
    }

    [Fact]
    public void DistanceTo_ReturnsExpectedDistance_GivenPosition()
    {
        // Arrange
        var sensor = new Sensor
        {
            Position = new Coordinate(0, 0),
            ClosestBeacon = new Beacon
            {
                Position = new Coordinate(0, 0) // We don't care about where the beacon is.
            }
        };

        var position = new Coordinate(10, 10);

        const int expectedDistance = 20;

        // Act
        var distance = sensor.DistanceTo(position);

        // Assert
        distance.Should().Be(expectedDistance);
    }
}