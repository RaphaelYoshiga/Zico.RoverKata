using Zico.Training.KataRover.Domain;

namespace Zico.Training.KataRover.Application
{
    public interface IRoverCommander
    {
        void Execute(string commands, IRover rover);
    }
}