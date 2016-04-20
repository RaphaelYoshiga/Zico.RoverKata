using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zico.Training.KataRover.Domain
{
    public class Rover
    {
        public Direction CurrentDirection { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
    }
}
