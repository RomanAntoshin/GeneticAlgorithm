using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgorithm
{
    class NearestCityAlgorithm: Algorithm
    {
        /*private double[,] M;
        private List<int> Ham;*/
        public NearestCityAlgorithm(double[,] M, int town=0): base(M, town)
        {
            /*this.M = M;
            Ham = new List<int>();*/
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
            //Ham.Add(0);
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
        /*public double GetCriteri()
        {
            double Cr = 0;
            for (int i = 0; i < Ham.Count - 1; i++)
                Cr = Cr + this.M[Ham[i], Ham[i + 1]];
            return Cr;
        }*/
    }
}
