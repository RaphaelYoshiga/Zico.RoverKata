using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zico.Training.KataRover.Domain;

namespace Zico.Training.KataRover.Application
{
    public class RoverFormatter : IRoverFormatter
    {
        public string Format(IRover rover)
        {
            char direction = Enum.GetName(typeof(Direction), rover.CurrentDirection)[0];
            return $"{rover.X}{rover.Y}{direction}";
        }
    }
}
