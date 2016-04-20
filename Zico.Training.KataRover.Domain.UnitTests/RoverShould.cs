using System;
using NUnit.Framework;
using Shouldly;

namespace Zico.Training.KataRover.Domain.UnitTests
{
    [TestFixture]
    public class RoverShould
    {
        [Test]
        public void DefaultPosition()
        {
            var rover = new Rover();

            rover.Height.ShouldBe(0);
            rover.Width.ShouldBe(0);
            rover.CurrentDirection.ShouldBe(Direction.North);
        }

        [TestCase(1, Direction.East)]
        [TestCase(2, Direction.South)]
        [TestCase(3, Direction.West)]
        [TestCase(4, Direction.North)]
        [TestCase(5, Direction.East)]
        public void RotateRight(int times, Direction expectedDirection)
        {
            var rover = new Rover();

            for (int i = 0; i < times; i++)
                rover.RotateRight();

            rover.CurrentDirection.ShouldBe(expectedDirection);
        }

        [TestCase(1, Direction.West)]
        [TestCase(2, Direction.South)]
        [TestCase(3, Direction.East)]
        [TestCase(4, Direction.North)]
        [TestCase(5, Direction.West)]
        public void RotateLeft(int times, Direction expectedDirection)
        {
            var rover = new Rover();

            for (int i = 0; i < times; i++)
                rover.RotateLeft();

            rover.CurrentDirection.ShouldBe(expectedDirection);
        }
    }
}
