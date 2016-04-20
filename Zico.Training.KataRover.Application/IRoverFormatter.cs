using Zico.Training.KataRover.Domain;

namespace Zico.Training.KataRover.Application
{
    public interface IRoverFormatter
    {
        string Format(IRover rover);
    }
}