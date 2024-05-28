﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgorithm
{
    class Panmixia:AStrategy
    {
        public Panmixia(IBriding briding, double[,] data, Person[] Group):base(briding, data, Group) { }
        public override void Iteration()
        {
            Random rnd = new Random();
            for (int i = 0; i < Group.Length; i++)
            {
                int a = rnd.Next(0, Group.Length);
                int b;
                do
                {
                    b = rnd.Next(0, Group.Length);
                }
                while (b == a);
                AddChildren(Group[a], Group[b]);
            }
            GetMutation();
            //Mutation.Run(children);
            List<int> defect = new List<int>();
            for (int i = 0; i < Group.Length / 4; i++)
                GetWorstPersonAt(defect);
            List<int> best = new List<int>();
            int[] cand = new int[Group.Length / 10 + 1];
            for (int i = 0; i < Group.Length / 4; i++)
            {
                cand[0] = rnd.Next(0, children.Count);
                for (int j = 1; j < cand.Length; j++)
                {
                    int b;
                    do
                    {
                        b = rnd.Next(0, children.Count);
                    }
                    while (cand.Contains(b));
                    cand[j] = b;
                }
                int winAt = B_joust(cand);
                best.Add(winAt);
            }
            for (int i = 0; i < best.Count; i++)
                Group[defect[i]] = children[best[i]];
        }
    }
}