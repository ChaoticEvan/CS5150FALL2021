using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW05
{
    class Program
    {
        private const int prob = 52;

        static void Main(string[] args)
        {
            Console.WriteLine("Running experiment A (20 runs)");
            Results expAResult = RunExperiment(20);
            Console.WriteLine("Done...");

            Console.WriteLine("Running experiment B (100 runs)");
            Results expBResult = RunExperiment(100);
            Console.WriteLine("Done...");

            Console.WriteLine("Running experiment C (400 runs)");
            Results expCResult = RunExperiment(400);
            Console.WriteLine("Done...");

            Console.ReadLine();
        }

        private static Results RunExperiment(int numRuns)
        {
            Random rand = new Random();
            int aCount = 0, bCount = 0;

            for (int i = 0; i < numRuns; ++i)
            {
                int voter = rand.Next(100);
                bool didVoteA = voter <= prob;

                if (didVoteA)
                {
                    aCount++;
                }
                else
                {
                    bCount++;
                }
            }

            Results res;
            if (aCount > bCount)
            {
                res = Results.AMajority;
            }
            else if (bCount > aCount)
            {
                res = Results.BMajority;
            }
            else
            {
                res = Results.Tie;
            }

            return res;
        }
    }

    enum Results
    {
        AMajority,
        BMajority,
        Tie
    }
}
