using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgorithm
{
    abstract class Algorithm
    {
        protected double[,] M;
        protected List<int> Ham;
        protected int town;
        //protected Random random;
        public Algorithm(double[,] M, int town = 0)
        {
            this.M = M;
            Ham = new List<int>();
            this.town = town;
            //random = new Random();
        }
        public Algorithm(double[,] M, List<int> Ham, int town = 0)
        {
            this.M = M;
            this.Ham = Ham;
            this.town = town;
        }

        abstract public Person GiveSolution();
        public double GetCriteria()
        {
            double Cr = 0;
            for (int i = 0; i < Ham.Count - 1; i++)
                Cr = Cr + this.M[Ham[i], Ham[i + 1]];
            Cr = Cr + this.M[Ham[Ham.Count-1], Ham[0]];
            return Cr;
        }
        /*public static double GetCriteria(List<int> solution)
        {
            double Cr = 0;
            for (int i = 0; i < solution.Count - 1; i++)
                Cr = Cr + M[Ham[i], Ham[i + 1]];
            Cr = Cr + this.M[Ham[Ham.Count - 1], Ham[0]];
            return Cr;
        }*/
        protected int GenerateStartCity()
        {
            Random rnd = new Random();
            return rnd.Next(0, (int)Math.Sqrt(M.Length));
        }
    }
}
