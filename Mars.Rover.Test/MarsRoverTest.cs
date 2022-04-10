using MarsRover.Application.Implementation;
using MarsRover.Application.Interface;
using MarsRover.Common.Enums;
using MarsRover.Common.Models;
using Moq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Xunit;

namespace Mars.Rover.Test
{
    public class MarsRoverTest
    {
        private readonly Mock<IPositionControlService> _positionControlServiceMock;
        private readonly Mock<IMovementService> _movementServiceMock;

        public MarsRoverTest()
        {
            _positionControlServiceMock = new Mock<IPositionControlService>();
            _movementServiceMock = new Mock<IMovementService>();
        }
        public static IEnumerable<object[]> TestRoverPositionData =>
       new List<object[]>
       {
            new object[] { new List<string> { "1", "2", "3", "4" } }
       };

        public static IEnumerable<object[]> TestMovementData =>
        new List<object[]>
        {
            new object[] { new Position() { X = 1, Y = 2, Direction = DirectionStatus.N}, "M"}
        };

        [Fact]
        public void PlanetCoordinates_ShouldReturnDefaultValues_WhenCoordinateNotEntered()
        {
            List<int> points = new();

            //Act
            var positionControlService = new PositionControlService(_movementServiceMock.Object);
            void act() => positionControlService.PlanetCoordinates(points);

            //Assert
            var expected = new Coordinate
            {
                X = 0,
                Y = 0
            };

            Assert.Equal(expected.ToString(), positionControlService.PlanetCoordinate.ToString());
        }
        [Theory]
        [MemberData(nameof(TestRoverPositionData))]
        public void RoverCoordinates_ShouldThrowException_WhenEnteredIncorrectValues(List<string> coordinates)
        {
            //Act
            var positionControlService = new PositionControlService(_movementServiceMock.Object);
            void act() => positionControlService.RoverCoordinates(coordinates);

            //Assert
            Exception exception = Assert.Throws<Exception>(act);
            Assert.Equal("Please enter correct values for rover's position", exception.Message);
        }
        [Fact]
        public void PlanetBoundariesControl_ShouldThrowException_WhenPositionNotWithinBounds()
        {
            //Act
            var positionControlService = new PositionControlService(_movementServiceMock.Object);
            positionControlService.PlanetCoordinate.X = 8;
            positionControlService.PlanetCoordinate.Y = 8;
            positionControlService.RoverPosition.X = 9;
            positionControlService.RoverPosition.Y = 9;

            void act() => positionControlService.PlanetBoundariesControl();
            
            //Assert
            Exception exception = Assert.Throws<Exception>(act);
            Assert.Equal("The coordinates are not within planet boundaries", exception.Message);
        }

        [Theory]
        [MemberData(nameof(TestMovementData))]
        public void Movement_ShouldReturnPosition_WhenGivenCorrectMovement(Position roverPosition, string movement)
        {
            List<int> points = new List<int> { 5, 5 };

            //Act
            var movementService = new MovementService();
            var positionControlService = new PositionControlService(movementService);
            void act() => movementService.Movement(roverPosition, movement);

            //Assert
            var expected = new Position
            {
                X = 1,
                Y = 3,
                Direction = DirectionStatus.N
            };
            var actual = JsonConvert.SerializeObject(movementService.Movement(roverPosition, movement));
            var exp = JsonConvert.SerializeObject(expected);
            Assert.Equal(exp, actual);
        }
    }
}
