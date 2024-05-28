using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgorithm
{
    class NearestNeighborAlgorithm: Algorithm
    {
        //private int town;
        //private Random rnd;
        public NearestNeighborAlgorithm(double[,] M, int town = 0): base(M, town)
        {
            //town = GenerateStartCity();
            //rnd = new Random();
        }
        public override Person GiveSolution()
        {
            int ind = 0;
            double min = M[0, 0];
            //int town = GenerateStartCity();
            Ham.Add(town);
            //for(int j=0; j<Math.Sqrt(M.Length)-1; j++)
            while (Ham.Count < Math.Sqrt(M.Length))
            {
                for (int i = 0; i < Math.Sqrt(M.Length); i++)
                    if (M[town, i] < min && !Ham.Contains(i))
                    {
                        min = M[town, i];
                        ind = i;
                    }
                Ham.Add(ind);
                town = ind;
                min = M[0, 0];
            }
            //Ham.Add(0);
            return new Person(Ham, GetCriteria());
        }
    }
}
