using System;
using System.Globalization;

namespace PrimeNumberGenerator
{
    class Program
    {
        public static int[] NumbersList;
        public static int[] Deviders;
        public const int CROSSED_POOL = 0;
        public int[] PrimeNumbersGenerator(int range)
        {
            NumbersList = new int[range];
            Deviders = new int[Convert.ToInt64(Math.Sqrt(Convert.ToDouble(range)))];
            // filling arrays w numbers from 1 to n given by range
            int i;
            for (i = 0; i < Deviders.Length; i++)
            {
                NumbersList[i] = i + 1;
                Deviders[i] = i + 1;
            }
            for (; i < NumbersList.Length; i++)
            {
                NumbersList[i] = i + 1;
            }
            // takeing off even numbers
            NumbersList = CanselEven(NumbersList);
            Deviders = CanselEven(Deviders);

            for(i = 0; i < NumbersList.Length; i++)
            {
                for( int j = 0; j < Deviders.Length; j++)
                {
                    if (NumbersList[i] % Deviders[j] == 0)
                    {
                        NumbersList[i] = CROSSED_POOL;
                    }
                }
            }

            return RefreshArray(NumbersList);   
        }
        
        public int[] RefreshArray(int[] ArrayToRefresh)
        {
            int NewSize = 0;
            for (int i = 0; i < ArrayToRefresh.Length; i++)
            {
                if (ArrayToRefresh[i] != CROSSED_POOL)
                {
                    NewSize++;
                }
            }
            int[] BuffArray = new int[NewSize];
            for (int i = 0, j = 0; i < ArrayToRefresh.Length; i++)
            {
                if (ArrayToRefresh[i] != CROSSED_POOL)
                {
                    BuffArray[j] = ArrayToRefresh[i];
                    j++;
                }
            }
            ArrayToRefresh = (int[])BuffArray.Clone();
            return ArrayToRefresh;
        }
        public int[] CanselEven(int[] ArrayGiven)
        {
            for(int i = 0; i<ArrayGiven.Length; i++)
            {
                if (ArrayGiven[i] % 2 == 0)
                {
                    if (ArrayGiven[i] == 2)
                    {
                        continue;
                    }
                    else
                    {
                        ArrayGiven[i] = CROSSED_POOL;
                    }
                }
            }
            return RefreshArray(ArrayGiven);
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Ile liczb chcesz przesiać ?");
            int Range = int.Parse(Console.ReadLine());
            int[] PrimeNumbers = PrimeNumbersGenerator(Range);
             
        }
    }
}

