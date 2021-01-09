using MarsRoverApplication.Model;
using MarsRoverApplication.Service;
using System;
using Xunit;

namespace MarsRoverApplicationTest
{
    public class MarsRoverTest
    {
        [Fact]
        public void CheckFirstRover()
        {
            RoverService roverService = new RoverService();

            Plateau plateau = new Plateau()
            {
                XPosition = 5,
                YPosition = 5
            };

            Position position = new Position()
            {
                XCoordinate = 1,
                YCoordinate = 2,
            };

            string command = "LMLMLMLMM";

            Rover firstRover = new Rover(position, command, eDirection.N);
            roverService.Process(firstRover);
            Assert.Equal("1 3 N", firstRover.ToString());
        }

        [Fact]
        public void CheckSecondRover()
        {
            RoverService roverService = new RoverService();

            Plateau plateau = new Plateau()
            {
                XPosition = 5,
                YPosition = 5
            };

            Position position = new Position()
            {
                XCoordinate = 3,
                YCoordinate = 3,
            };

            string command = "MMRMMRMRRM";

            Rover secondRover = new Rover(position, command, eDirection.E);
            roverService.Process(secondRover);
            Assert.Equal("5 1 E", secondRover.ToString());
        }

        [Fact]
        public void CheckPlateauIsValidPosition()
        {
            Plateau plateau = new Plateau()
            {
                XPosition = 5,
                YPosition = 5
            };

            Position position = new Position()
            {
                XCoordinate = 3,
                YCoordinate = 3,
            };

            PlateauService plateauService = new PlateauService();
            bool isValidPosition = plateauService.IsValidPosition(plateau, position);
            Assert.True(isValidPosition);

        }

        [Fact]
        public void CheckPlateauCoordinate()
        {
            PlateauService plateauService = new PlateauService();
            Plateau plateau = plateauService.GetPlateauCoordinate("5 5");
            Assert.NotNull(plateau);

        }

        [Fact]
        public void CheckInvalidInput()
        {
            RoverService roverService = new RoverService();

            Plateau plateau = new Plateau()
            {
                XPosition = 5,
                YPosition = 5
            };

            Position position = new Position()
            {
                XCoordinate = 3,
                YCoordinate = 3,
            };

            string command = "MMAMMRMRAM";

            Rover rover = new Rover(position, command, eDirection.N);
            Assert.Throws<Exception>(() => roverService.Process(rover));

        }

        [Fact]
        public void CheckPositionCoordinate()
        {
            PositionService positionService = new PositionService();
            Position position = positionService.GetPositionCoordinate("1 2 N");
            Assert.NotNull(position);

        }

    }
}
