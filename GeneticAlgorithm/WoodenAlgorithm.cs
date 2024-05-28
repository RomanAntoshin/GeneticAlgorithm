using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgorithm
{
    class WoodenAlgorithm: Algorithm
    {
        private List<Edge> Skeleton;
        private List<int> Eu;
        public WoodenAlgorithm(double[,] M, int town=0): base(M, town)
        {
        }
        public override Person GiveSolution()
        {
            AlgorithmByPrim(M);
            GetMultigraph();
            CycleByEuler();
            CycleByHamilton();
            return new Person(Ham, GetCriteria());
        }
        private void AlgorithmByPrim(double[,] M)
        {
            Skeleton = new List<Edge>();
            int N = (int)Math.Sqrt(M.Length);
            double min = M[0, 0];
            int ind1 = 0;
            int ind2 = 0;
            List<int> usedV = new List<int>(); // Исп вершины
            List<int> notUsedV = new List<int>(); // Неисп вершины
            for (int i = 0; i < N; i++)
            {
                notUsedV.Add(i);
            }
            usedV.Add(town);
            notUsedV.Remove(town);
            for (int k = 0; k < N - 1; k++)
            {
                for (int i = 0; i < usedV.Count; i++)
                {
                    for (int j = 0; j < notUsedV.Count; j++)
                    {
                        if (M[usedV[i], notUsedV[j]] < min)
                        {
                            min = M[usedV[i], notUsedV[j]];
                            ind1 = usedV[i];
                            ind2 = notUsedV[j];
                        }
                    }
                }
                Edge E = new Edge(ind1, ind2, min);
                Skeleton.Add(E);
                usedV.Add(ind2);
                notUsedV.Remove(ind2);
                min = M[0, 0];
            }
        }
        private void GetMultigraph()
        {
            int N = Skeleton.Count;
            for (int i = 0; i < N; i++)
            {
                Edge B = new Edge(Skeleton[i].v2, Skeleton[i].v1, Skeleton[i].weight);
                Skeleton.Add(B);
            }
        }
        private void CycleByEuler()
        {
            Eu = new List<int>();
            Stack<int> St = new Stack<int>();
            St.Push(town);
            Eu.Add(town);
            while (St.Count > 0)
            {
                if (!GetDegree(St.Peek()))
                {
                    Eu.Add(St.Pop());
                }
                else
                {
                    for (int i = 0; i < Skeleton.Count; i++)
                        if (Skeleton[i].v1 == St.Peek() || Skeleton[i].v2 == St.Peek())
                        {
                            St.Push(Skeleton[i].v2);
                            Skeleton.RemoveAt(i);
                        }
                }
            }
        }
        private bool GetDegree(int V)
        {
            for (int i = 0; i < Skeleton.Count; i++)
                if (Skeleton[i].v1 == V || Skeleton[i].v2 == V)
                    return true;
            return false;
        }
        private void CycleByHamilton()
        {
            for (int i = 0; i < Eu.Count; i++)
            {
                if (!Ham.Contains(Eu[i]))
                    Ham.Add(Eu[i]);
            }
        }
    }
}
