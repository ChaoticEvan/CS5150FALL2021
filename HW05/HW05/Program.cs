using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW05
{
    class Program
    {
        private const int Prob = 52;
        private const int ExperimentASamples = 20;
        private const int ExperimentBSamples = 100;
        private const int ExperimentCSamples = 400;
        private const int ExperimentDSamples = 475;
        private const int NumRuns = 100;

        static void Main(string[] args)
        {
            // Experiment A
            Console.WriteLine("Running experiment A (" + ExperimentASamples + " samples)");
            bool experimentAResult = RunExperiment(ExperimentASamples);
            Console.WriteLine("Experiment A Results:\nIs A the majority? " + experimentAResult + "\n");

            // Experiment B
            Console.WriteLine("Running experiment B (" + ExperimentBSamples + " samples)");
            bool experimentBResult = RunExperiment(ExperimentBSamples);
            Console.WriteLine("Experiment B Results:\nIs A the majority? " + experimentBResult + "\n");

            // Experiment C
            Console.WriteLine("Running experiment C (" + ExperimentCSamples + " samples)");
            bool experimentCResult = RunExperiment(ExperimentCSamples);
            Console.WriteLine("Experiment C Results:\nIs A the majority? " + experimentCResult + "\n");

            // Experiment D
            Console.WriteLine("Running experiment D (" + ExperimentDSamples + " samples)");
            bool experimentDResult = RunExperiment(ExperimentDSamples);
            Console.WriteLine("Experiment D Results:\nIs A the majority? " + experimentDResult + "\n");

            Console.Write("Press enter to exit...");
            Console.ReadLine();
        }

        /// <summary>
        /// Helper method to collect the # of samples and record the majority 100 times (as per the instructions)
        /// </summary>
        /// <param name="numSamples">Number of samples to collect from the "voters"</param>
        /// <returns>Returns true if A voters were the majority more than B voters out of the 100 runs, else returns false</returns>
        private static bool RunExperiment(int numSamples)
        {
            Random rand = new Random();

            int aMajCount = 0, bMajCount = 0;
            for (int i = 0; i < NumRuns; ++i)
            {
                Results expResult = GetSamples(numSamples, rand);

                // Increment proper majority count, ignore ties
                if (expResult == Results.AMajority)
                {
                    aMajCount++;
                }
                else if (expResult == Results.BMajority)
                {
                    bMajCount++;
                }
            }


            Console.WriteLine("A Majority Count: " + aMajCount);
            Console.WriteLine("B Majority Count: " + bMajCount);

            // This ignores the case where they are equal majority counts, but
            // this edge case won't happen extremely often given the number of
            // samples and how many runs we are doing
            return aMajCount > bMajCount;
        }

        /// <summary>
        /// Helper method to collect samples from the "list of voters"
        /// </summary>
        /// <param name="numSamples">Number of samples to collect</param>
        /// <returns>Returns Enum to record if A voters or B voters had majority or a tie occured</returns>
        private static Results GetSamples(int numSamples, Random rand)
        {
            int aCount = 0, bCount = 0;

            // Collect samples
            for (int i = 0; i < numSamples; ++i)
            {
                int voter = rand.Next(100);
                bool didVoteA = voter <= Prob;

                if (didVoteA)
                {
                    aCount++;
                }
                else
                {
                    bCount++;
                }
            }

            // Record majority results
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
