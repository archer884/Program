using System;
using System.Collections.Generic;
using System.Linq;

namespace FirstAlgorithmPointless
{
    class Program
    {
        static void Main(string[] args)
        {
            var prng = new Random();
            var randomNumbers = CreateRandomList(() => prng.Next(98) + 2);
            var finalNumbers = randomNumbers.Select(Reduce).ToList();
            
            PrintValues(randomNumbers);
            PrintFactors(finalNumbers);
        }

        private static int Reduce(int n)
        {
            var max = Math.Sqrt(n) + 1;
            for (int i = 2; i < max; i++)
            {
                if (n % i == 0)
                {
                    return Reduce(n / i);
                }
            }
            return n;
        }

        static void PrintValues(IList<int> list)
        {
            foreach (int i in list)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine("Item count: {0}", list.Count);
        }

        static void PrintFactors(IList<int> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine("{0}\t<-- #{1}", list[i], i + 1);
            }
            Console.WriteLine("Number of items is " + list.Count);
        }

        static IList<int> CreateRandomList(Func<int> generator)
        {
            var list = new List<int>();
            for (int i = 0; i < 100; i++)
            {
                list.Add(generator());
            }
            return list;
        }
    }
}
