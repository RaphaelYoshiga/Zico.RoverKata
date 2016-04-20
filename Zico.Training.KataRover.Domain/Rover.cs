using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zico.Training.KataRover.Domain
{
    public class Rover
    {
        public const int MaxHeightIndex = 9;
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
            if (CurrentDirection == Direction.South)
                MoveTowardsSouth();
            else
                MoveTowardsNorth();
        }

        private void MoveTowardsSouth()
        {
            Height = Height == 0 ? MaxHeightIndex : Height - 1;
        }

        private void MoveTowardsNorth()
        {
            Height = Height == MaxHeightIndex ? 0 : Height + 1;
        }
    }
}
