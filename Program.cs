using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstAlgorithmPointless
{
    class Program
    {
        static void Main(string[] args)
        {
            var randomNumbers = CreateRandomList();
            var finalNumbers = ProgramLogic(SimpleAlgorithm(randomNumbers));
            
            PrintValues(randomNumbers);
            PrintFactors(finalNumbers);
        }

        static IList<int> ProgramLogic(IList<int> values)
        {
            //bool is_entire_list_prime = false;
            int check = 0;
            while (check < 100)
            {
                //display_finalized_list();
                //System.Threading.Thread.Sleep(10000);
                check = 0;

                values = Reduce(values);
                foreach (int i in values)
                {
                    if (IsPrime(i))
                    {
                        check++;
                    }
                }
            }
            return values;
        }

        private static bool IsPrime(int number)
        {
            int i;
            for (i = 2; i < number; i++)
            {
                if (number % i == 0)
                {
                    return false;
                }
            }
            if (i == number)
            {
                return true;
            }
            return false;
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

        static IList<int> Reduce(IList<int> values)
        {
            var list = new List<int>();

            foreach (int i in values)
            {
                if (i % 2 == 0 && i >= 4)
                {
                    int x = i / 2;
                    list.Add(x);
                }
                else if (i % 2 != 0 && i >= 4)
                {
                    for (int z = 3; z <= i; z++)
                    {
                        if (i % z == 0 && i != z)
                        {
                            int y = i / z;
                            list.Add(y);
                            break;
                        }
                        if (i == z)
                        {
                            list.Add(z);
                            break;
                        }
                    }
                }
                else if (i < 4)
                {
                    list.Add(i);
                }
            }

            return list;
        }

        static IList<int> SimpleAlgorithm(IEnumerable<int> source)
        {
            var filteredList = new List<int>();

            foreach (int i in source)
            {
                if (i % 2 == 0 && i >= 4)
                {
                    int x = i / 2;
                    filteredList.Add(x);
                }
                if (i % 2 != 0 && i >= 4)
                {
                    for (int z = 3; z <= i; z++)
                    {
                        if (i % z == 0 && i != z)
                        {
                            int y = i / z;
                            filteredList.Add(y);
                            break;
                        }
                        if (i == z)
                        {
                            filteredList.Add(z);
                            break;
                        }
                    }
                }
                if (i < 4)
                {
                    filteredList.Add(i);
                }
            }

            return filteredList;
        }

        static IList<int> CreateRandomList()
        {
            var rand = new Random();
            var list = new List<int>();

            for (int i = 0; i < 100; i++)
            {
                list.Add(rand.Next(3, 100));
            }

            return list;
        }
    }
}
