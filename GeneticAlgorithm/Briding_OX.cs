using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgorithm
{
    public class Briding_OX: ABriding
    {
        //public Briding_OX(double[,] data): base(data) { }
        public override Person GetBriding(Person first, Person second/*, double[,] data*/)
        {
            Random rnd = new Random();
            int N = first.Solution().Count;
            int a1 = rnd.Next(0, N / 2);
            int a2 = rnd.Next(N / 2, N);
            int[] solution = new int[N];
            for (int i = a1; i <= a2; i++)
                solution[i] = first.Solution()[i];
            List<int> swap = new List<int>();
            for (int i = a2; i < N; i++)
                if (!solution.Contains(second.Solution()[i]))
                {
                    swap.Add(second.Solution()[i]);
                }
            for (int i = 0; i < a2; i++)
                if (!solution.Contains(second.Solution()[i]))
                    swap.Add(second.Solution()[i]);
            int k = 0;
            for (int i = a2 + 1; i < N && k < swap.Count; i++)
            {
                solution[i] = swap[k];
                k++;
            }
            for (int i = 0; i < a1 && k < swap.Count; i++)
            {
                solution[i] = swap[k];
                k++;
            }
            return new Person(new List<int>(solution)/*, GetCriteria(new List<int>(solution), data)*/);
        }

        /*public override Person GetBriding(Person first, Person second, double[,] data)
        {
            throw new NotImplementedException();
        }*/
    }
}
