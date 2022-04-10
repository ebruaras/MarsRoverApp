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
    public class MovementService : IMovementService
    {
        public Position Movement(Position roverPosition, string movement)
        {
            var move = (MovementStatus)Enum.Parse(typeof(MovementStatus), movement);
            switch (move)
            {
                case (MovementStatus.L):
                    MovementLeft(roverPosition);
                    break;
                case (MovementStatus.R):
                    MovementRight(roverPosition);
                    break;
                case (MovementStatus.M):
                    MovementMove(roverPosition);
                    break;
            }
            return roverPosition;
        }
        private void MovementLeft(Position roverPosition)
        {
            roverPosition.Direction = roverPosition.Direction - 1 < DirectionStatus.N ? DirectionStatus.W : roverPosition.Direction - 1;
        }
        private void MovementRight(Position roverPosition)
        {
            roverPosition.Direction = roverPosition.Direction + 1 > DirectionStatus.W ? DirectionStatus.N : roverPosition.Direction + 1;
        }
        private void MovementMove(Position roverPosition)
        {
            switch (roverPosition.Direction)
            {
                case DirectionStatus.N:
                    roverPosition.IncrementY();
                    break;
                case DirectionStatus.E:
                    roverPosition.IncrementX();
                    break;
                case DirectionStatus.S:
                    roverPosition.DecrementY();
                    break;
                case DirectionStatus.W:
                    roverPosition.DecrementX();
                    break;
            }
        }
    }
}
