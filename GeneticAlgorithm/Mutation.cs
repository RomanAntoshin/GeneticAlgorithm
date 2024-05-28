using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgorithm
{
    public static class Mutation
    {
        private static Random rnd;
        public static void Run(List<Person> group)
        {
            if (rnd == null)
                rnd = new Random();
            for (int i = 0; i < group.Count; i++)
            {
                int r = rnd.Next(1, 101);
                if (r > 50 && r <= 80)
                {
                    PointMutation(group[i].Solution());
                    //group[i].Criteria = GetCriteria(group[i].Solution(), data);
                }
                if (r > 80 && r <= 90)
                {
                    InversionMutation(group[i].Solution());
                    //group[i].Criteria = GetCriteria(group[i].Solution(), data);
                }
                if (r > 90)
                {
                    SaltationMutation(group[i].Solution());
                    //group[i].Criteria = GetCriteria(group[i].Solution(), data);
                }
            }
        }

        /*private static void PointMytation(List<int> list)
        {
            throw new NotImplementedException();
        }*/

        private static void PointMutation(List<int> person)
        {
            Random rnd = new Random();
            int ind = rnd.Next(0, person.Count - 1);
            int buf = person[ind];
            person[ind] = person[ind + 1];
            person[ind + 1] = buf;
        }
        private static void InversionMutation(List<int> person)
        {
            Random rnd = new Random();
            int f = rnd.Next(0, person.Count / 2);
            //Console.WriteLine(f);
            int s = rnd.Next(person.Count / 2, person.Count);
            //Console.WriteLine(s);
            List<int> part = new List<int>();
            for (int i = s; i >= f; i--)
            {
                part.Add(person[i]);
            }
            for (int i = 0; i < part.Count; i++)
                person[i + f] = part[i];
        }
        private static void SaltationMutation(List<int> person)
        {
            Random rnd = new Random();
            int k = person.Count / 5;
            if (k == 0)
                k = 1;
            List<int> locus = new List<int>();
            for (int i = 0; i < 2 * k; i++)
            {
                rnd.Next(1, person.Count);
                locus.Add(rnd.Next(1, person.Count));
            }
            int buf;
            for (int i = 0; i < locus.Count - 1; i = i + 2)
            {
                buf = person[locus[i]];
                person[locus[i]] = person[locus[i + 1]];
                person[locus[i + 1]] = buf;
            }
        }
    }
}
