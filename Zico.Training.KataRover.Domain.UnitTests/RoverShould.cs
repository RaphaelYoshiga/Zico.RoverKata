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
            MoveForwardNTimes(times);

            _rover.Height.ShouldBe(times);
        }

        private void MoveForwardNTimes(int times)
        {
            for (int i = 0; i < times; i++)
                _rover.MoveForward();
        }

        [Test]
        public void ResetHeightWhenMovingTowardsNorthAndOutOfBoundaries()
        {
            MoveForwardNTimes(10);

            _rover.Height.ShouldBe(0);
        }

        [Test]
        public void ResetHeightWhenMovingTowardsSouthAndOutOfBoundaries()
        {
            _rover.RotateRight();
            _rover.RotateRight();

            _rover.MoveForward();

            _rover.Height.ShouldBe(Rover.MaxHeightIndex);
        }

        [TestCase(1, Rover.MaxHeightIndex)]
        [TestCase(5, Rover.MaxHeightIndex - 4)]

        public void DecreaseHeightWhenMovingTowardsSouth(int times, int expectedHeight)
        {
            _rover.RotateRight();
            _rover.RotateRight();

            MoveForwardNTimes(times);

            _rover.Height.ShouldBe(expectedHeight);
        }
    }
}
