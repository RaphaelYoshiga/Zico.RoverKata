using System;
using System.Text;
using Moq;
using NUnit.Framework;
using Shouldly;
using Zico.Training.KataRover.Domain;

namespace Zico.Training.KataRover.Application.UnitTests
{
    [TestFixture]
    public class RoverCommanderShould
    {
        private Mock<IRover> _roverMock;
        private RoverCommander _roverCommander;
        private Random _random;

        private const char RotateRightCommand = 'R';
        private const char RotateLeftCommand = 'L';
        private const char MoveForwardCommand = 'M';

        [SetUp]
        public void BeforeEachTest()
        {
            _roverMock = new Mock<IRover>();
            _random = new Random();

            _roverCommander = new RoverCommander();
        }


        [Test]
        public void CallRoverMoveForwardWhenMCommand()
        {
            int times = _random.Next(1, 1000);
            var commandBuilder = GetCommandByNTimes(times, MoveForwardCommand);

            _roverCommander.Execute(commandBuilder.ToString(), _roverMock.Object);

            _roverMock.Verify(p => p.MoveForward(), Times.Exactly(times));
        }

        private static StringBuilder GetCommandByNTimes(int times, char command)
        {
            var commandBuilder = new StringBuilder();
            for (int i = 0; i < times; i++)
                commandBuilder.Append(command);
            return commandBuilder;
        }

        [Test]
        public void CallRoverRotateLeftWhenLCommand()
        {
            int times = _random.Next(1, 1000);
            var commandBuilder = GetCommandByNTimes(times, RotateLeftCommand);

            _roverCommander.Execute(commandBuilder.ToString(), _roverMock.Object);

            _roverMock.Verify(p => p.RotateLeft(), Times.Exactly(times));
        }

        [Test]
        public void CallRoverRotateRightWhenRCommand()
        {
            int times = _random.Next(1, 100);
            var commandBuilder = GetCommandByNTimes(times, RotateRightCommand);

            _roverCommander.Execute(commandBuilder.ToString(), _roverMock.Object);

            _roverMock.Verify(p => p.RotateRight(), Times.Exactly(times));
        }

        [Test]
        public void ExecuteMultipleCommandsInRightOrder()
        {
            string expectedCommand = GetRandomCommmands();
            StringBuilder actualExecutedCommands = new StringBuilder();
            _roverMock.Setup(p => p.MoveForward())
                .Callback(() => actualExecutedCommands.Append(MoveForwardCommand));
            _roverMock.Setup(p => p.RotateRight())
                .Callback(() => actualExecutedCommands.Append(RotateRightCommand));
            _roverMock.Setup(p => p.RotateLeft())
                .Callback(() => actualExecutedCommands.Append(RotateLeftCommand));

            _roverCommander.Execute(expectedCommand, _roverMock.Object);

            actualExecutedCommands.ToString().ShouldBe(expectedCommand);
        }

        private string GetRandomCommmands()
        {
            var commandBuilder = new StringBuilder();
            int numberOfCommands = _random.Next(1, 100);
            for (int i = 0; i < numberOfCommands; i++)
            {
                int command = _random.Next(0, 2);
                if(command == 0)
                    commandBuilder.Append(RotateLeftCommand);
                else if (command == 1)
                    commandBuilder.Append(RotateRightCommand);
                else
                    commandBuilder.Append(MoveForwardCommand);
            }
            return commandBuilder.ToString();
        }
    }
}
