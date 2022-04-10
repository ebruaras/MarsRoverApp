using MarsRover.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover.Common.Models
{
    public class Position : Coordinate
    {
        public DirectionStatus Direction { get; set; }

        public Position IncrementX()
        {
            X++;
            return this;
        }
        public Position DecrementX()
        {
            X--;
            return this;
        }
        public Position IncrementY()
        {
            Y++;
            return this;
        }
        public Position DecrementY()
        {
            Y--;
            return this;
        }
        public Position ChangeDirection(DirectionStatus direction)
        {
            Direction = direction;
            return this;
        }
    }
}
