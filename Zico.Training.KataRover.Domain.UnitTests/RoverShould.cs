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
    }
}
