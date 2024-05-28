using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgorithm
{
    public interface IBriding
    {
        public Person GetBriding(Person first, Person second/*, double[,] data*/);
    }
}
