using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgorithm
{
    public abstract class ABriding: IBriding
    {
        //protected readonly double[,] data;
        /*private readonly Person first;
        private readonly Person second;*/
        /*protected ABriding(double[,] data)
        {
            this.data = data;
        }*/
        abstract public Person GetBriding(Person first, Person second/*, double[,] data*/);
    }
}
