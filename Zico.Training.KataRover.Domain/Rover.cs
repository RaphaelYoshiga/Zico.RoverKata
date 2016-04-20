using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zico.Training.KataRover.Domain
{
    public class Rover
    {
        private const int MaxHeightIndex = 9;
        public Direction CurrentDirection { get; private set; }
        public int Height { get; private set; }
        public int Width { get; private set; }

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

        public void MoveForward()
        {
            if (Height == MaxHeightIndex)
                Height = 0;
            else
                Height++;
        }
    }
}
