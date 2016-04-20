using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zico.Training.KataRover.Domain
{
    public interface IRoverFactory
    {
        IRover Instanciate();
    }
}
