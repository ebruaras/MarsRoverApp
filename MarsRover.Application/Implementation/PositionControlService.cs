using MarsRover.Application.Interface;
using MarsRover.Common.Enums;
using MarsRover.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover.Application.Implementation
{
    public class PositionControlService : IPositionControlService
    {
        private readonly IMovementService _movementService;
        public Coordinate PlanetCoordinate { get; set; } = new();
        public Position RoverPosition { get; set; } = new();

        public PositionControlService(IMovementService movementService) =>
            (_movementService) = (movementService);

        public void PlanetCoordinates(List<int> coordinates)
        {
            PlanetCoordinate.X = coordinates[0];
            PlanetCoordinate.Y = coordinates[1];
        }

        public void RoverCoordinates(List<string> coordinates)
        {
            if(coordinates.Count != 3)
            {
                throw new Exception("Please enter correct values for rover's position");
            }
            RoverPosition.X = Convert.ToInt32(coordinates[0]);
            RoverPosition.Y = Convert.ToInt32(coordinates[1]);
            RoverPosition.Direction = (DirectionStatus)Enum.Parse(typeof(DirectionStatus), coordinates[2]);
            PlanetBoundariesControl();
        }
        public void PlanetBoundariesControl()
        {
            if (RoverPosition.X < 0 || RoverPosition.X > PlanetCoordinate.X || RoverPosition.Y < 0 || RoverPosition.Y > PlanetCoordinate.Y)
            {
                throw new Exception("The coordinates are not within planet boundaries");
            }
        }
        public Position ChangeRoverPosition(string movements)
        {
            foreach (var movement in movements)
            {
                RoverPosition = _movementService.Movement(RoverPosition, movement.ToString());
                PlanetBoundariesControl(); //Checks every movement to control it is within borders
            }
            return RoverPosition;
        }

    }
}
