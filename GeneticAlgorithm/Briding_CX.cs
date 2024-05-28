using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgorithm
{
    public class Briding_CX: ABriding
    {
        //public Briding_CX(double[,] data) : base(data) { }

        public override Person GetBriding(Person first, Person second/*, double[,] data*/)
        {
            int Size = first.Solution().Count;
            int[] question = new int[Size];
            int[] c = new int[Size];
            for (int i = 0; i < c.Length; i++)
                c[i] = 0;
            int count = 0;
            Random rnd = new Random();
            while (c.Contains(0))
            {
                int j;
                count++;
                do
                {
                    j = rnd.Next(0, c.Length);
                }
                while (c[j] != 0);
                do
                {
                    c[j] = count;
                    int _j;
                    for (int i = 0; i < Size; i++)
                    {
                        if (first.Solution()[i] == second.Solution()[j])
                        {
                            _j = i;
                            j = _j;
                            break;
                        }
                    }
                }
                while (c[j] != count);
                int N = rnd.Next(0, 2);
                if (N == 0)
                {
                    for (int i = 0; i < c.Length; i++)
                        if (c[i] == count)
                            question[i] = first.Solution()[i];
                }
                else
                {
                    for (int i = 0; i < c.Length; i++)
                        if (c[i] == count)
                            question[i] = second.Solution()[i];
                }
            }
            return new Person(new List<int>(question)/*, GetCriteria(new List<int>(question), data)*/);
        }
    }
}
