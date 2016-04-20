using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zico.Training.KataRover.Domain
{
    public class Rover : IRover
    {
        public const int MaxIndex = 9;
        public const int MinIndex = 0;
        private int _x;
        private int _y;

        public Direction CurrentDirection { get; private set; }

        public int Y
        {
            get { return _y; }
            private set { _y = EnsureIndexIsInBoundaries(value); }
        }

        public int X
        {
            get { return _x; }
            private set
            {
                _x = EnsureIndexIsInBoundaries(value);
            }
        }

        private int EnsureIndexIsInBoundaries(int newIndex)
        {
            if (newIndex < MinIndex)
                return MaxIndex;

            if (newIndex > MaxIndex)
                return MinIndex;

            return newIndex;
        }

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
            switch (CurrentDirection)
            {
                case Direction.South:
                    Y--;
                    break;
                case Direction.North:
                    Y++;
                    break;
                case Direction.East:
                    X++;
                    break;
                default:
                    X--;
                    break;
            }
        }
    }
}
