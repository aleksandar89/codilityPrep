using System;
using System.Runtime.Serialization.Formatters;

namespace Lesson3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(FrogJump(10, 85, 30));

            var array = new int[200000];

            for (int i = 1; i <= 200000; i++)
            {
                array[i-1] = i;
            }

            array[199999] += 1;

            Console.WriteLine($"Missing element: {MissingElement(array)}");

            var difArray = new [] {-500, -500, 500, -500};
            
            Console.WriteLine($"Minimal difference is {MinimalDifference(difArray)}");
        }

        public static int FrogJump(int x, int y, int d)
        {
            return (int) Math.Ceiling((double)(y - x) / d);
        }

        public static int MissingElement(int[] A)
        {
            if (A.Length == 0)
            {
                return 1;
            }

            // make sure to check for overflow!
            long max = A.Length + 1;
            long sum = max * (max + 1) / 2;

            foreach (long item in A)
            {
                sum -= item;
            }
            
            return (int)sum;
        }

        public static int MinimalDifference(int[] A)
        {
            var neighboursArraySums = new int[A.Length];
            long sum = 0;

            for (int i = 0; i < A.Length; i++)
            {
                sum += A[i];
                if (i == 0)
                {
                    neighboursArraySums[i] = A[i] + neighboursArraySums[i];
                }
                else
                {
                    neighboursArraySums[i] = neighboursArraySums[i - 1] + A[i];
                }
            }

            long min = Int64.MaxValue;

            for (int i = 0; i < A.Length - 1; i++)
            {
                long asd = sum - neighboursArraySums[i];

                long result = Math.Abs(neighboursArraySums[i] - asd);

                if (min > result)
                {
                    min = result;
                }
            }

            return (int) min;
        }
    }
}
