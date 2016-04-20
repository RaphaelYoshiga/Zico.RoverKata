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
        public int Y { get; private set; }
        public int X { get; private set; }

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
            else if (CurrentDirection == Direction.North)
                MoveTowardsNorth();
            else if (CurrentDirection == Direction.East)
                MoveTowardsEast();
            else
                MoveTowardsWest();
        }

        private void MoveTowardsWest()
        {
            if (X == MinIndex)
                X = MaxIndex;
            else
                X--;
        }

        private void MoveTowardsEast()
        {
            X = X == MaxIndex ? MinIndex : ++X;
        }

        private void MoveTowardsSouth()
        {
            Y = Y == MinIndex ? MaxIndex : --Y;
        }

        private void MoveTowardsNorth()
        {
            Y = Y == MaxIndex ? MinIndex : ++Y;
        }
    }
}
