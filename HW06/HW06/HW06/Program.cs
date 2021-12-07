using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace HW06
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> bins;
            bins = new List<int>(new int[10_000]);            

            Random rand = new Random();
            for(int i = 0; i < 10_000; ++i)
            {
                int idx1 = rand.Next(10_000);
                int idx2 = rand.Next(10_000);
                if(bins[idx1] < bins[idx2])
                {
                    bins[idx1]++;
                }
                else
                {
                    bins[idx2]++;
                }
            }

            string[] output = new string[10_001];
            output[0] = "Bin #    Balls";
            for (int i = 0; i < 10_000; ++i)
            {
                output[i+1] = i + "~~~~" + bins[i];
            }

            File.WriteAllLines("C:\\Users\\evanv\\Desktop\\HW6Q2Output.txt", output);
        }
    }
}
