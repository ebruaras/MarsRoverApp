using MarsRover.Application.Implementation;
using MarsRover.Application.Interface;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace MarsRover.ConsoleApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                .AddSingleton<IPositionControlService, PositionControlService>()
                .AddSingleton<IMovementService, MovementService>()
                .BuildServiceProvider();
            IMovementService movementService = serviceProvider.GetService<IMovementService>();
            IPositionControlService positionControlService = serviceProvider.GetService<IPositionControlService>();
            
            try
            {
                Console.WriteLine("Please enter coordinates of the planet");
                var planetCoordinates = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToList();
                positionControlService.PlanetCoordinates(planetCoordinates);

                Console.WriteLine("Please enter coordinates of the rover");
                var roverPositions = Console.ReadLine()?.ToUpper().Trim().Split(' ').ToList();
                positionControlService.RoverCoordinates(roverPositions);

                Console.WriteLine("Please enter the movements ");
                var movement = Console.ReadLine()?.ToUpper();
                var roverMovement = positionControlService.ChangeRoverPosition(movement);

                Console.WriteLine($"Output: {roverMovement.X} {roverMovement.Y} {roverMovement.Direction}");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
