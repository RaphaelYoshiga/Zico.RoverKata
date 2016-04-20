namespace Zico.Training.KataRover.Domain
{
    public interface IRover
    {
        Direction CurrentDirection { get; }
        int Y { get; }
        int X { get; }
        void RotateRight();
        void RotateLeft();
        void MoveForward();
    }
}