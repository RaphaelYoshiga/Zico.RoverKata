using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using Shouldly;
using Zico.Training.KataRover.Domain;

namespace Zico.Training.KataRover.Application.UnitTests
{
    [TestFixture]
    public class RoverFormatterShould
    {
        private Mock<IRover> _roverMock;
        private RoverFormatter _roverFormatter;

        [SetUp]
        public void BeforeEachTest()
        {
            _roverFormatter = new RoverFormatter();
            _roverMock = new Mock<IRover>();
        }

        [TestCase(Direction.North, 'N')]
        [TestCase(Direction.East, 'E')]
        [TestCase(Direction.South, 'S')]
        [TestCase(Direction.West, 'W')]
        public void FormatAll(Direction direction, char expectedDirection)
        {
            var random = new Random();
            int y = random.Next(0, 9);
            int x = random.Next(0, 9);
            _roverMock.SetupGet(p => p.Y).Returns(y);
            _roverMock.SetupGet(p => p.X).Returns(x);
            _roverMock.SetupGet(p => p.CurrentDirection).Returns(direction);

            string actualFormat = _roverFormatter.Format(_roverMock.Object);

            actualFormat.ShouldBe($"{x}{y}{expectedDirection}");
        }
    }
}
