using MarsRoverApplication.Model;
using MarsRoverApplication.Service;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;

namespace MarsRoverApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = CreateServiceProvider();
            var positionService = (IPositionService)serviceProvider.GetService(typeof(IPositionService));
            var plateauService = (IPlateauService)serviceProvider.GetService(typeof(IPlateauService));
            var roverService = (IRoverService)serviceProvider.GetService(typeof(IRoverService));

            Console.WriteLine("MARS ROVER CASE");
            Console.WriteLine($"{Environment.NewLine}");
            Console.WriteLine("Test Input:");
            Console.WriteLine();
            Console.WriteLine("5 5");
            Console.WriteLine("1 2 N");
            Console.WriteLine("LMLMLMLMM");
            Console.WriteLine();
            Console.WriteLine("3 3 E");
            Console.WriteLine("MMRMMRMRRM");
            Console.WriteLine($"{Environment.NewLine}");

            Console.WriteLine("Enter Plateau Points :");
            var plateauInput = Console.ReadLine();
            var plateau = plateauService.GetPlateauCoordinate(plateauInput);
            List<Rover> rovers = new List<Rover>();

            for (int i = 0; i < 2; i++)
            {
                Console.WriteLine("Enter Rover Position. Sample Rover Position 1 3 S");
                var roverPositionInput = Console.ReadLine();
                var roverPosition = positionService.GetPositionCoordinate(roverPositionInput);
                var direction = Enum.Parse(typeof(eDirection), roverPosition.Direction);

                Console.WriteLine("Enter Rover Command Set :");
                var roverCommands = Console.ReadLine();
                rovers.Add(new Rover(roverPosition, roverCommands, (eDirection)direction));

            }

            foreach (var rover in rovers)
            {
                roverService.Process(rover);
                if (!plateauService.IsValidPosition(plateau, rover.RoverPosition))
                    throw new Exception($"{rovers.IndexOf(rover) + 1}. rover can not move this command set,because current position is not valid.");
                
                Console.WriteLine(rover.ToString());
            }
            Console.ReadLine();

        }


        static ServiceProvider CreateServiceProvider()
        {
            return new ServiceCollection()
                .AddSingleton<IRoverService, RoverService>()
                .AddSingleton<IPlateauService, PlateauService>()
                .AddSingleton<IPositionService, PositionService>()
                .BuildServiceProvider();
        }
    }
}
