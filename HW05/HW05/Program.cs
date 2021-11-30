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
            Console.WriteLine("Running experiment A (20 runs)\n");
            Results expAResult = RunExperiment(20);
            Console.WriteLine("Experiment A Results: " + expAResult.ToString());


            Console.WriteLine("Running experiment B (100 runs)\n");
            Results expBResult = RunExperiment(100);
            Console.WriteLine("Experiment B Results: " + expBResult.ToString());

            Console.WriteLine("Running experiment C (400 runs)\n");
            Results expCResult = RunExperiment(400);
            Console.WriteLine("Experiment C Results: " + expCResult.ToString());

            Console.WriteLine("Press enter to exit...");
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
