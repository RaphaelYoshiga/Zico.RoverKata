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
    public class RoverOrchestratorShould
    {
        private Mock<IRoverFactory> _roverFactory;
        private RoverOrchestrator _roverOrchestrator;
        private Mock<IRover> _roverMock;
        private Mock<IRoverCommander> _roverCommanderMock;
        private Mock<IRoverFormatter> _roverFormatterMock;

        [SetUp]
        public void BeforeEachTest()
        {
            _roverFactory = new Mock<IRoverFactory>();
            _roverMock = new Mock<IRover>();
            _roverFactory.Setup(p => p.Instanciate())
                .Returns(_roverMock.Object);
            _roverCommanderMock = new Mock<IRoverCommander>();

            _roverFormatterMock = new Mock<IRoverFormatter>();
            _roverOrchestrator = new RoverOrchestrator(_roverFactory.Object, _roverCommanderMock.Object, _roverFormatterMock.Object);
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

        [Test]
        public void ReturnRoverFormatterResult()
        {
            string expectedOutput = Guid.NewGuid().ToString();
            _roverFormatterMock.Setup(p => p.Format(_roverMock.Object)).Returns(expectedOutput);

            string actualOutput = _roverOrchestrator.Execute(string.Empty);

            actualOutput.ShouldBe(expectedOutput);
        }

        [Test]
        public void CallFormatterAfterCommander()
        {
            int unexpectedCallOrder = 1;
            int expectedCallOrder = 2;
            int callOrder = 0;
            _roverCommanderMock.Setup(p => p.Execute(It.IsAny<string>(), It.IsAny<IRover>()))
                .Callback(() => callOrder = unexpectedCallOrder);
            _roverFormatterMock.Setup(p => p.Format(It.IsAny<IRover>()))
                .Callback(() => callOrder = expectedCallOrder);

            string actualOutput = _roverOrchestrator.Execute(string.Empty);

            callOrder.ShouldBe(expectedCallOrder);
        }
    }
}
