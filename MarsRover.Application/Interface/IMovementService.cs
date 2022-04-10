using MarsRover.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover.Application.Interface
{
    public interface IMovementService
    {
        Position Movement(Position roverPosition, string movement);
    }
}
