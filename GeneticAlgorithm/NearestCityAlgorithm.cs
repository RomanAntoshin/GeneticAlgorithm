using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgorithm
{
    class NearestCityAlgorithm: Algorithm
    {
        public NearestCityAlgorithm(double[,] M, int town=0): base(M, town)
        {
        }
        public override Person GiveSolution()
        {
            Ham.Add(town);
            List<double> cand = new List<double>();
            for(; ; )
            {
                for (int i = 0; i < Ham.Count; i++)
                    cand.Add(M[Ham[i], Str_Min(Ham[i])]);
                Ham.Insert(cand.IndexOf(cand.Min()) + 1, Str_Min(Ham[cand.IndexOf(cand.Min())]));
                cand.Clear();
                if (Ham.Count == Math.Sqrt(M.Length))
                    break;
            }
            return new Person(Ham, GetCriteria());
        }
        private int Str_Min(int str_num)
        {
            double min = M[str_num, str_num];
            int ind = 0;
            for(int i=0; i<Math.Sqrt(M.Length); i++)
                if(M[str_num, i]<min && !Ham.Contains(i))
                {
                    min = M[str_num, i];
                    ind = i;
                }
            return ind;
        }
    }
}
