using System.Drawing;

namespace Tests;

public class InputParserTests
{
    private Sensor FindSensorAtPosition(List<Sensor> sensors, int x, int y)
    {
        var sensor = sensors.Find(s => s.Position.X == x && s.Position.Y == y);
        if (sensor is null)
        {
            throw new ArgumentException("Invalid coordinates were provided.");
        }

        return sensor;
    }
    
    [Fact]
    public void Parse_ReturnsListOfSensorsAndBeacons_GivenAdventOfCodeExampleInput()
    {
        // Arrange
        const string input = "Sensor at x=2, y=18: closest beacon is at x=-2, y=15\n" +
                             "Sensor at x=9, y=16: closest beacon is at x=10, y=16\n" +
                             "Sensor at x=13, y=2: closest beacon is at x=15, y=3\n" +
                             "Sensor at x=12, y=14: closest beacon is at x=10, y=16\n" +
                             "Sensor at x=10, y=20: closest beacon is at x=10, y=16\n" +
                             "Sensor at x=14, y=17: closest beacon is at x=10, y=16\n" +
                             "Sensor at x=8, y=7: closest beacon is at x=2, y=10\n" +
                             "Sensor at x=2, y=0: closest beacon is at x=2, y=10\n" +
                             "Sensor at x=0, y=11: closest beacon is at x=2, y=10\n" +
                             "Sensor at x=20, y=14: closest beacon is at x=25, y=17\n" +
                             "Sensor at x=17, y=20: closest beacon is at x=21, y=22\n" +
                             "Sensor at x=16, y=7: closest beacon is at x=15, y=3\n" +
                             "Sensor at x=14, y=3: closest beacon is at x=15, y=3\n" +
                             "Sensor at x=20, y=1: closest beacon is at x=15, y=3\n";

        const int expectedNumberOfSensors = 14;
        const int expectedNumberOfBeacons = 6;

        var parser = new InputParser();

        // Act
        var (sensors, beacons) = parser.Parse(input);

        // Assert
        sensors.Should().HaveCount(expectedNumberOfSensors);
        beacons.Should().HaveCount(expectedNumberOfBeacons);

        var firstSensor = FindSensorAtPosition(sensors, 2, 18);
        firstSensor.Position.Should().BeEquivalentTo(new Coordinate(2, 18));
        firstSensor.ClosestBeacon.Position.Should().BeEquivalentTo(new Coordinate(-2, 15));

        var firstSharingSensor = FindSensorAtPosition(sensors, 12, 14);
        var secondSharingSensor = FindSensorAtPosition(sensors, 10, 20);
        var thirdSharingSensor = FindSensorAtPosition(sensors, 14, 17);
        new List<Beacon>
            {
                firstSharingSensor.ClosestBeacon,
                secondSharingSensor.ClosestBeacon,
                thirdSharingSensor.ClosestBeacon
            }
            .Should().OnlyContain(beacon => beacon == firstSharingSensor.ClosestBeacon);
    }
}
