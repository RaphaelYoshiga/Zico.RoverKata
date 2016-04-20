using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zico.Training.KataRover.Domain
{
    public class Rover
    {
        public const int MaxIndex = 9;
        public const int MinIndex = 0;

        public Direction CurrentDirection { get; private set; }
        public int Height { get; private set; }
        public int Width { get; private set; }

        public void RotateRight()
        {
            CurrentDirection = CurrentDirection == Direction.West ? Direction.North : ++CurrentDirection;
        }

        public void RotateLeft()
        {
            CurrentDirection = CurrentDirection == Direction.North ? Direction.West : --CurrentDirection;
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
            Height = Height == MinIndex ? MaxIndex : --Height;
        }

        private void MoveTowardsNorth()
        {
            Height = Height == MaxIndex ? MinIndex : ++Height;
        }
    }
}
