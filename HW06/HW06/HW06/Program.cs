using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace HW06
{
    class Program
    {
        static Task Main(string[] args)
        {
            List<int> bins;
            bins = new List<int>(new int[10_000_000]);            

            Random rand = new Random();
            for(int i = 0; i < 10_000_000; ++i)
            {
                int idx = rand.Next(10_000_000);
                bins[idx]++;
            }

            File.WriteAllText("C:\\Users\\evanv\\Desktop\\HW6Q2Output.txt", "Bin #    Balls");

            string[] output = new string[10_000_000];
            for (int i = 0; i < 10_000_000; ++i)
            {
                output[i] = i + "    " + bins[i];
            }

            File.WriteAllLines("C:\\Users\\evanv\\Desktop\\HW6Q2Output.txt", output);
        }
    }
}
