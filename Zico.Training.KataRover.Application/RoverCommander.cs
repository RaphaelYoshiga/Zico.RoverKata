using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zico.Training.KataRover.Domain;

namespace Zico.Training.KataRover.Application
{
    public class RoverCommander : IRoverCommander
    {
        public void Execute(string commands, IRover rover)
        {
            foreach (var command in commands)
            {
                if (command == 'M')
                    rover.MoveForward();
                else if (command == 'L')
                    rover.RotateLeft();
                else
                    rover.RotateRight();
            }
        }
    }
}
