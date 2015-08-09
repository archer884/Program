using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace First_Algorithm_Pointless
{
    class Program
    {
        static List<int> Random_List_Of_Numbers = new List<int>();
        static List<int> Final_List_Of_Numbers = new List<int>();
        static List<int> Temp_List_Of_Numbers = new List<int>();

        static void Main(string[] args)
        {
            create_random_list();
            simple_algorithm();
            program_logic();
           display_random_list();
           display_finalized_list();
            //check_if_number_is_prime();
            System.Threading.Thread.Sleep(60000); //pauses the console to read for 1 minute
        }

        static void program_logic()
        {
            //bool is_entire_list_prime = false;
            int check = 0;
            while (check < 100)
            {
                //display_finalized_list();
                //System.Threading.Thread.Sleep(10000);
                check = 0;
                Temp_List_Of_Numbers.Clear();
                in_case_list_isnt_prime();
                foreach (int i in Temp_List_Of_Numbers)
                {
                    if (check_if_number_is_prime(i) == 0) { break; } // if isn't prime
                    if (check_if_number_is_prime(i) != 0) { check += 1; } // if is prime
                }
            }
        }

        private static int check_if_number_is_prime(int number)
       {
            int i;
            for (i = 2; i < number; i++)
            {
                if (number % i == 0)
                {
                    return 0;
                }
            }
            if (i == number)
            {
                return 1;
            }
           return 0;
        }

        static void display_random_list()
        {
            int amount_in_array = 0;
            foreach (int i in Random_List_Of_Numbers)
            {
                amount_in_array += 1;
                Console.WriteLine(i);
            }
            Console.WriteLine("Number of items is " + amount_in_array);
        }

        static void display_finalized_list()
        {
            int amount_in_array = 0;
            foreach (int i in Final_List_Of_Numbers)
            {
                amount_in_array += 1;
                Console.WriteLine(i.ToString() + "<--- No. " + amount_in_array.ToString());
            }
            Console.WriteLine("Number of items is " + amount_in_array);
        }

        static void in_case_list_isnt_prime()
        {
            foreach (int i in Final_List_Of_Numbers)
            {
                if (i % 2 == 0 && i >= 4)
                {
                    int x = i / 2;
                    Temp_List_Of_Numbers.Add(x);
                }
                if (i % 2 != 0 && i >= 4)
                {
                    for (int z = 3; z <= i; z++)
                    {
                        if (i % z == 0 && i != z)
                        {
                            int y = i / z;
                            Temp_List_Of_Numbers.Add(y);
                            break;
                        }
                        if (i == z)
                        {
                            Temp_List_Of_Numbers.Add(z);
                            break;
                        }
                    }
                }
                if (i < 4)
                {
                    Temp_List_Of_Numbers.Add(i);
                }
            }
        }

        static void simple_algorithm()
        {
            foreach (int i in Random_List_Of_Numbers)
            {
                if (i % 2 == 0 && i >= 4) 
                { 
                    int x = i / 2;
                    Final_List_Of_Numbers.Add(x);
                }
                if (i % 2 != 0 && i >= 4) 
                {
                    for (int z = 3; z <= i; z++)
                    {
                        if (i % z == 0 && i != z) 
                        {
                            int y = i / z;
                            Final_List_Of_Numbers.Add(y);
                            break;
                        }
                        if (i == z)
                        {
                            Final_List_Of_Numbers.Add(z);
                            break;
                        }
                    }
                }
                if (i < 4) 
                { 
                    Final_List_Of_Numbers.Add(i); 
                }
            }
        }

        static void create_random_list()
        {
            Random rand = new Random();

            for (int i = 1; i < 101; i++)
            {
                int x = rand.Next(3, 100);
                Random_List_Of_Numbers.Add(x);
            }
        }
    }
}
