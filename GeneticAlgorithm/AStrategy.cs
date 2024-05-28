using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgorithm
{
    abstract class AStrategy
    {
        protected List<Person> children;
        protected readonly IBriding briding;
        private readonly double[,] data;
        protected Person[] Group;
        public AStrategy(IBriding briding, double[,] data, Person[] Group)
        {
            this.briding = briding;
            this.data = data;
            this.Group = Group;
            children = new List<Person>();
        }
        private double GetCriteria(List<int> solution)
        {
            double Cr = 0;
            for (int i = 0; i < solution.Count - 1; i++)
                Cr = Cr + data[solution[i], solution[i + 1]];
            Cr = Cr + data[solution[solution.Count - 1], solution[0]];
            return Cr;
        }
        protected void AddChildren(Person first, Person second)
        {
            Person person = briding.GetBriding(first, second);
            person.Criteria = GetCriteria(person.Solution());
            children.Add(person);
            Person person1 = briding.GetBriding(second, first);
            person1.Criteria = GetCriteria(person1.Solution());
            children.Add(person1);
        }
        protected int B_joust(int[] cand)
        {
            double min = children[cand[0]].Criteria;
            int ind = cand[0];
            for (int i = 1; i < cand.Length; i++)
            {
                if (children[cand[i]].Criteria < min)
                {
                    min = children[cand[i]].Criteria;
                    ind = i;
                }
            }
            return ind;
        }
        protected void GetWorstPersonAt(List<int> defect)
        {
            double max = Group[0].Criteria;
            int ind = 0;
            for (int i = 0; i < Group.Length; i++)
                if (Group[i].Criteria >= max && defect.Contains(i) == false)
                {
                    max = Group[i].Criteria;
                    ind = i;
                }
            defect.Add(ind);
        }
        protected void GetMutation()
        {
            Mutation.Run(children);
            foreach (var el in children)
                el.Criteria = GetCriteria(el.Solution());
        }
        abstract public void Iteration();
    }
}
