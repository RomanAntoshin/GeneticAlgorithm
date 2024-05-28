using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgorithm
{
    public class Person
    {
        private List<int> solution;
        private double criteria=0;
        public Person(List<int> solution, double criteria)
        {
            this.solution = solution;
            this.criteria = criteria;
        }
        public Person(List<int> solution)
        {
            this.solution = solution;
        }
        public List<int> Solution()
        {
            return solution;
        }
        public void AddElement(int value)
        {
            solution.Add(value);
        }
        public double Criteria
        {
            get { return criteria; }
            set { criteria = value; }
        }
        public string Print()
        {
            StringBuilder answer = new StringBuilder();
            foreach (int el in solution)
                answer.Append(el + " ");
            return answer.ToString();
        }
    }
}
