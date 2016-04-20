using System;
using NUnit.Framework;
using NUnit.Framework.Api;
using Shouldly;

namespace Zico.Training.KataRover.Domain.UnitTests
{
    [TestFixture]
    public class RoverShould
    {
        private Rover _rover;

        [SetUp]
        public void BeforeEachTest()
        {
            _rover = new Rover();
        }

        [Test]
        public void DefaultPosition()
        {
            _rover.Height.ShouldBe(0);
            _rover.Width.ShouldBe(0);
            _rover.CurrentDirection.ShouldBe(Direction.North);
        }

        [TestCase(1, Direction.East)]
        [TestCase(2, Direction.South)]
        [TestCase(3, Direction.West)]
        [TestCase(4, Direction.North)]
        [TestCase(5, Direction.East)]
        public void RotateRight(int times, Direction expectedDirection)
        {
            for (int i = 0; i < times; i++)
                _rover.RotateRight();

            _rover.CurrentDirection.ShouldBe(expectedDirection);
        }

        [TestCase(1, Direction.West)]
        [TestCase(2, Direction.South)]
        [TestCase(3, Direction.East)]
        [TestCase(4, Direction.North)]
        [TestCase(5, Direction.West)]
        public void RotateLeft(int times, Direction expectedDirection)
        {
            for (int i = 0; i < times; i++)
                _rover.RotateLeft();

            _rover.CurrentDirection.ShouldBe(expectedDirection);
        }

        [TestCase(1)]
        [TestCase(9)]
        public void IncreaseHeightWhenMovingTowardsNorth(int times)
        {
            for (int i = 0; i < times; i++)
                _rover.MoveForward();

            _rover.Height.ShouldBe(times);
        }

        [Test]
        public void ResetHeightWhenMovingTowardsNorthAndOutOfBoundaries()
        {
            for (int i = 0; i < 10; i++)
                _rover.MoveForward();

            _rover.Height.ShouldBe(0);
        }
    }
}
