using System;

namespace lesson4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("FrogLeap: " + FrogLeap(5, new int[] {1, 3, 1, 4, 2, 3, 5, 4}));
            Console.WriteLine("SmallestPositiveInt: " + SmallestPositiveInt(new int[] {-1000000, 1000000}));
            Console.WriteLine("PermCheck: " + PermCheck(new int[] {1000}));
            Console.WriteLine("MaxCounters: " + MaxCounters(5, new int[] {1,6,2,2,2,1,1,6,1,6,1,6}));
        }

        public static int[] MaxCounters(int N, int[] A)
        {
            var counters = new int[N];
            var maxCounter = 0;
            var previousMaxCounter = 0;
            bool max = false;

            for(int i = 0; i < A.Length; i ++)
            {
                if(A[i] == N + 1)
                {
                    max = true;
                    previousMaxCounter = maxCounter;
                }
                else
                {
                    if(max && counters[A[i] - 1] <= previousMaxCounter)
                    {
                        counters[A[i] - 1] = previousMaxCounter + 1;
                    }
                    else
                    {
                        counters[A[i] - 1] += 1;
                    }
                    if(counters[A[i] - 1] > maxCounter)
                    {
                        maxCounter = counters[A[i] - 1];
                    }
                }
            }

            for(int i = 0; i < counters.Length; i++ )
            {
                if(counters[i] < previousMaxCounter)
                {
                    counters[i] = previousMaxCounter;
                }
                Console.Write($" {counters[i]} ");
            }

            return counters;
        }

        public static int PermCheck(int[] A)
        {
            var store = new int[100001];

            for(int i = 0 ; i < A.Length; i++)
            {
                if(A[i] < 1 || A[i] > 100000)
                    continue;
                store[A[i]] = 1;
            }

            for(int i = 1; i <= A.Length; i++){
                if(store[i] != 1){
                    return 0;
                }
            }
            
            return 1;
        }

        public static int SmallestPositiveInt (int[] A)
        {
            var store = new int[1000001];

            for(int i = 0 ; i < A.Length; i++){
                if(A[i] < 0)
                    continue;
                store[A[i]] = 1;
            }

            for(int i = 1; i < store.Length; i++){
                if(store[i] != 1){
                    return i;
                }
            }

            return A.Length + 1;
        }

        public static int FrogLeap(int X, int[] A) {
            long bigX = (long) X;
            long sum = (bigX+1) * bigX / 2;
            
            var store = new int[X + 1];
            
            for(int i = 0; i < A.Length; i++)
            {
                store[A[i]]++;
                if(store[A[i]] == 1){
                    sum -= A[i];
                }

                if(sum == 0){
                    return i;
                }
            }

            return -1;
        }

    }
}
