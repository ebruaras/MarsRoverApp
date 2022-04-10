using MarsRover.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover.Application.Interface
{
    public interface IPositionControlService
    {
        void PlanetCoordinates(List<int> coordinates);
        void RoverCoordinates(List<string> coordinates);
        Position ChangeRoverPosition(string movements);
    }
}
