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

        public void RotateRight()
        {
            if (CurrentDirection == Direction.West)
                CurrentDirection = Direction.North;
            else
                CurrentDirection++;
        }

        public void RotateLeft()
        {
            if (CurrentDirection == Direction.North)
                CurrentDirection = Direction.West;
            else
                CurrentDirection--;
        }
    }
}
