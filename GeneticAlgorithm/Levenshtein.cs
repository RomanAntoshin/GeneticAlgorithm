using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgorithm
{
    static class Levenshtein
    {
        public static void GetDistance(Dictionary<int[], int> Distance, Person[] Group)
        {
            for (int i = 0; i < Group.Length - 1; i++)
                for (int j = i + 1; j < Group.Length; j++)
                {
                    int[] buf = { i, j };
                    Distance.Add(buf, LevenshteinDistance(Group[i].Solution(), Group[j].Solution()));
                }
        }
        private static int LevenshteinDistance(in List<int> s, in List<int> t)
        {
            int n = s.Count;
            int m = t.Count;
            int[,] d = new int[n + 1, m + 1];

            if (n == 0)
                return m;
            if (m == 0)
                return n;

            for (int i = 0; i <= n; i++)
                d[i, 0] = i;
            for (int j = 0; j <= m; j++)
                d[0, j] = j;

            for (int j = 1; j <= m; j++)
            {
                for (int i = 1; i <= n; i++)
                {
                    if (s[i - 1] == t[j - 1])
                        d[i, j] = Math.Min(Math.Min(d[i - 1, j] + 1, d[i, j - 1] + 1), d[i - 1, j - 1]);
                    else
                        d[i, j] = Math.Min(Math.Min(d[i - 1, j] + 1, d[i, j - 1] + 1), d[i - 1, j - 1] + 1);
                }
            }
            return d[n, m];
        }
        public static int[] DistanceMinInd(Dictionary<int[], int> Distance)
        {
            int[] key = Distance.First(x => x.Value == Distance.Values.Min()).Key;
            return key;
        }
        public static int[] DistanceMaxInd(Dictionary<int[], int> Distance)
        {
            return Distance.First(x => x.Value == Distance.Values.Max()).Key;
        }
    }
}
