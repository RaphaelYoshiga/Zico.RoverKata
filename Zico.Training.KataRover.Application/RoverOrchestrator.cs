using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zico.Training.KataRover.Domain;

namespace Zico.Training.KataRover.Application
{
    public class RoverOrchestrator
    {
        private IRoverFactory _roverFactory;
        private IRoverCommander _roverCommander;

        public RoverOrchestrator(IRoverFactory roverFactory, IRoverCommander roverCommander)
        {
            _roverFactory = roverFactory;
            _roverCommander = roverCommander;
        }

        public string Execute(string commands)
        {
            var rover = _roverFactory.Instanciate();
            _roverCommander.Execute(commands, rover);
            return string.Empty;
        }
    }
}
