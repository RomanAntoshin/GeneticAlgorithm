using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgorithm
{
    public class Briding_PMX: ABriding
    {
        public override Person GetBriding(Person first, Person second)
        {
            int Size = first.Solution().Count;
            int[] question = new int[Size];
            for (int i = 0; i < question.Length; i++)
                question[i] = -1;
            Random rnd = new Random();
            int A1 = rnd.Next(0, Size / 2);
            int A2 = rnd.Next(Size / 2, Size);
            for (int i = A1 + 1; i < A2; i++)
                question[i] = first.Solution()[i];
            List<int> swamp = new List<int>();
            for (int i = A1 + 1; i <= A2 - 1; i++)
                if (!question.Contains(second.Solution()[i]))
                    swamp.Add(second.Solution()[i]);
            int[] P = new int[Size];
            for (int i = 0; i < P.Length; i++)
            {
                P[second.Solution()[i]] = i;
            }
            for (int k = 0; k < swamp.Count; k++)
            {
                int i = second.Solution().IndexOf(swamp[k]);
                int j = i;
                Replace(question, first.Solution(), second.Solution(), P, j, i);
            }
            for (int i = 0; i < question.Length; i++)
                if (question[i] < 0)
                    question[i] = second.Solution()[i];
            return new Person(new List<int>(question));
        }
        private void Replace(int[] question, List<int> first, List<int> second, int[] P, int j, int i)
        {
            int _j = P[first[j]];
            if (question[j] < 0)
                question[j] = second[i];
            else
            {
                j = _j;
                Replace(question, first, second, P, j, i);
            }
        }
    }
}
