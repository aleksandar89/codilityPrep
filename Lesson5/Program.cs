// using System;

// namespace Lesson5
// {
//     class Program
//     {
//         static void Main(string[] args)
//         {
//             var result = PrefixSum(new int[] { 1, 1, 1, 1, 1, 1 });

//             for(int i = 0; i < result.Length; i++){
//                 Console.WriteLine($"Sum of {i} elements is {result[i]}");
//             }

//             var countTotalSlices = CountTotal(result, 1, 3);
//             Console.WriteLine($"Total of slices 1 to 3 is {countTotalSlices}");
//         }

//         public static int[] PrefixSum (int[] A)
//         {
//             int n = A.Length;
//             int[] p = new int[A.Length + 1];

//             for(int i = 1; i < n + 1; i++)
//             {
//                 p[i] = p[i - 1] + A[i - 1];
//             }

//             return p;
//         }

//         public static int CountTotal (int[] P, int x, int y)
//         {
//             return P[y + 1] - P[x];
//         }
//     }
// }

using System;

namespace Lesson5
{
    class Program
    {
        enum Genomes { A = 1, C = 2, G = 3, T = 4 }

        static void Main(string[] args)
        {
            // var array = new int[] { 0, 1, 0, 0, 0, 1};

            // var passingCars = PassingCars(array);
            // Console.WriteLine(passingCars);

            // var divide = Dividable(6, 11, 2);
            // Console.WriteLine(divide);

            var P = new int[] {2, 5, 0};
            var Q = new int[] {4, 5, 6};
            var asd = DnaThingy("CAGCCTA", P, Q);

            // for(int i = 0; i < asd.Length; i++){
            //     Console.WriteLine(asd[i]);
            // }
        }

        public static int[] DnaThingy(string S, int[] P, int[] Q)
        {
            char[] charsInGenome = S.ToCharArray(0, S.Length);
            int[,] occurances = new int[charsInGenome.Length + 1, 5];
            var result = new int[P.Length];

            occurances[0,0] = 0;
            occurances[0,1] = 0;
            occurances[0,2] = 0;
            occurances[0,3] = 0;
            occurances[0,4] = 0;

            for(int i = 0; i < charsInGenome.Length; i ++)
            {
                int currentCharValue = (int)Enum.Parse(typeof(Genomes), charsInGenome[i].ToString());

                for (int j = 1; j < 5; j++)
                {
                    occurances[i + 1, j] = occurances[i, j];
                }

                occurances[i + 1, currentCharValue] = occurances[i, currentCharValue] + 1;
            }

            for(int i = 0; i < P.Length; i++)
            {
                var smalletsArray = new int[] { 0, 0, 0, 0 };
                var x = P[i] + 1;
                var y = Q[i] + 1;
                var smallest = 5;

                for(int j = 1; j < 5; j++)
                {
                    if (x != 0)
                    {
                        smalletsArray[j - 1] = occurances[y, j] - occurances[x - 1, j];
                    }
                    else
                    {
                        smalletsArray[j - 1] = occurances[y, j];
                    }
                }

                for(int j = 1; j < 5; j++)
                {
                    if (smalletsArray[j - 1] != 0)
                    {
                        smallest = smallest > j - 1 ? j - 1 : smallest;
                    }
                }

                result[i] = smallest + 1;
            }

            return result;
        }

        public static long Dividable(int A, int B, int K)
        {
            var count = (B/K) - (A/K);
            if(A%K == 0)
                count++;
            return count;
        }

        public static long PassingCars(int[] A)
        {
            var sums = PrefixSum(A);
            long passingCars = 0;

            for(int i = 0; i < A.Length; i++)
            {
                if(A[i] == 0)
                {
                    passingCars += (sums[A.Length - 1] - sums[i]);
                }
            }

            if(passingCars > 1000000000)
            {
                return -1;
            }

            return passingCars;
        }

        public static int[] PrefixSum(int[] A)
        {
            var n = A.Length;
            var sums = new int[n];

            for(int i = 0; i < n; i++)
            {
                if (i == 0)
                {
                    sums[0] = A[0];
                }    
                else
                {
                    sums[i] = A[i] + sums[i - 1];
                }
            }   

            return sums;
        }
    }
}