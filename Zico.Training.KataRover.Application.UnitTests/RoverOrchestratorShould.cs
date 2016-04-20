using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using Zico.Training.KataRover.Domain;

namespace Zico.Training.KataRover.Application.UnitTests
{
    [TestFixture]
    public class RoverOrchestratorShould
    {
        private Mock<IRoverFactory> _roverFactory;
        private RoverOrchestrator _roverOrchestrator;
        private Mock<IRover> _roverMock;
        private Mock<IRoverCommander> _roverCommanderMock;

        [SetUp]
        public void BeforeEachTest()
        {
            _roverFactory = new Mock<IRoverFactory>();
            _roverMock = new Mock<IRover>();
            _roverFactory.Setup(p => p.Instanciate())
                .Returns(_roverMock.Object);
            _roverCommanderMock = new Mock<IRoverCommander>();

            _roverOrchestrator = new RoverOrchestrator(_roverFactory.Object, _roverCommanderMock.Object);
        }

        [Test]
        public void CallInstanciateOnRoverFactory()
        {
            _roverOrchestrator.Execute("");

            _roverFactory.Verify(p => p.Instanciate(), Times.Once);
        }

        [Test]
        public void CallRoverCommander()
        {
            string commands = Guid.NewGuid().ToString();

            _roverOrchestrator.Execute(commands);

            _roverCommanderMock.Verify(p => p.Execute(commands, _roverMock.Object), Times.Once);
        }
    }
}
