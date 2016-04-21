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
            _rover.Y.ShouldBe(0);
            _rover.X.ShouldBe(0);
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
        public void IncreaseYAxisWhenMovingTowardsNorth(int times)
        {
            MoveForwardNTimes(times);

            _rover.Y.ShouldBe(times);
            _rover.X.ShouldBe(0);
        }

        [Test]
        public void ResetYAxisWhenMovingTowardsNorthAndOutOfBoundaries()
        {
            MoveForwardNTimes(10);

            _rover.Y.ShouldBe(0);
        }

        private void MoveForwardNTimes(int times)
        {
            for (int i = 0; i < times; i++)
                _rover.MoveForward();
        }

        [Test]
        public void ResetYAxisWhenMovingTowardsSouthAndOutOfBoundaries()
        {
            _rover.RotateRight();
            _rover.RotateRight();

            _rover.MoveForward();

            _rover.Y.ShouldBe(Rover.MaxIndex);
        }

        [TestCase(1, Rover.MaxIndex)]
        [TestCase(5, Rover.MaxIndex - 4)]
        [TestCase(9, Rover.MaxIndex - 8)]

        public void DecreaseYAxisWhenMovingTowardsSouth(int times, int expectedY)
        {
            _rover.RotateRight();
            _rover.RotateRight();

            MoveForwardNTimes(times);

            _rover.Y.ShouldBe(expectedY);
            _rover.X.ShouldBe(0);
        }

        [TestCase(1)]
        [TestCase(9)]
        public void IncreaseXAxisWhenMovingTowardsEast(int times)
        {
            _rover.RotateRight();

            MoveForwardNTimes(times);

            _rover.X.ShouldBe(times);
            _rover.Y.ShouldBe(0);
        }

        [Test]
        public void ResetXAxisWhenMovingEastAndOutOfBoundaries()
        {
            _rover.RotateRight();

            MoveForwardNTimes(10);

            _rover.X.ShouldBe(0);
        }


        [Test]
        public void ResetXAxisWhenMovingWestAndOutOfBoundaries()
        {
            _rover.RotateLeft();

            _rover.MoveForward();

            _rover.X.ShouldBe(Rover.MaxIndex);
        }

        [TestCase(5, Rover.MaxIndex - 4)]
        [TestCase(9, Rover.MaxIndex - 8)]
        public void DecreaseXAxisWhenMovingTowardsWest(int times, int expectedX)
        {
            _rover.RotateLeft();

            MoveForwardNTimes(times);

            _rover.X.ShouldBe(expectedX);
            _rover.Y.ShouldBe(0);
        }
    }
}
