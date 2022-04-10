using MarsRover.Application.Implementation;
using MarsRover.Application.Interface;
using MarsRover.Common.Models;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace MarsRover.Testt
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

        [Fact]
        public void PlanetCoordinates_ShouldReturnDefaultValues_WhenCoordinateNotEntered()
        {
            List<int> points = new List<int>();

            //Actual
            var positionControlService = new PositionControlService(_movementServiceMock.Object);
            Action act = () => positionControlService.PlanetCoordinates(points);

            //Assert
            var expected = new Coordinate
            {
                X = 0,
                Y = 0
            };

            Assert.Equal(expected.ToString(), positionControlService.PlanetCoordinate.ToString());
        }
    }
}
