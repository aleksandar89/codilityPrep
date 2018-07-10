using System;

namespace Lesson6
{
    class Program
    {
        static void Main(string[] args)
        {
            var array = new[] { 1, 5, 2, 1, 4, 0 };

            //var selectionSorted = SelectionSort(array);
            //var countingSorted = CountingSort(array, 15);

            Discs(array);
        }

        public static int Discs(int[] A)
        {
            var minRange = new long[A.Length];
            var maxRange = new long[A.Length];
            long intersections = 0;

            for (long i = 0; i < A.Length; i++)
            {
                minRange[i] = i - (long)A[i];
                maxRange[i] = i + (long)A[i];
            }
            
            Array.Sort(minRange);
            Array.Sort(maxRange);
            
            long currentActive = 0;
            long activatedIndex = 0;
            long deactivatedIndex = 0;

            for (var i = 0; i < A.Length; i++)
            {
                while (activatedIndex < A.Length &&
                       minRange[activatedIndex] <= maxRange[deactivatedIndex])
                {
                    activatedIndex++;
                    currentActive++;
                }

                currentActive--;
                intersections += currentActive;
                if (intersections > 10000000)
                {
                    return -1;
                }
                deactivatedIndex++;
            }

            return intersections > 10000000 ? -1 : (int)intersections;
        }

        public static int Triangle(int[] A)
        {
            Array.Sort(A);

            if (A.Length == 3)
            {
                if (A[0] + A[1] > A[2])
                    if (A[0] + A[2] > A[1])
                        if (A[1] + A[2] > A[0])
                            return 1;
            }

            for (var i = 1; i < A.Length - 1; i++)
            {
                if (A[i] + A[i - 1] > A[i + 1])
                    if (A[i + 1] + A[i - 1] > A[i])
                        if (A[i] + A[i + 1] > A[i - 1])
                            return 1;

            }

            return 0;
        }

        public static int ArrayTriplets(int[] A)
        {
            Array.Sort(A);
            var length = A.Length;

            var result1 = A[length - 1] * A[length - 2] * A[length - 3];
            var result2 = A[0] * A[1] * A[length - 1];
            if (result1 > result2)
                return result1;
            else
                return result2;
        }

        public static int DistinctMembersOfArray(int[] A)
        {
            Array.Sort(A);
            var distinct = 1;

            if (A.Length == 1)
            {
                return distinct;
            }
            if (A.Length == 0)
            {
                return 0;
            }

            for (int i = 1; i < A.Length; i++)
            {
                if (A[i] != A[i - 1])
                {
                    distinct += 1;
                }
            }

            return distinct;
        }

        public static int[] CountingSort(int[] A, int range)
        {
            var n = A.Length;
            var count = new int[range + 1];

            for (var i = 0; i < n; i++)
            {
                count[A[i]] += 1;
            }

            var p = 0;

            for (var i = 0; i < range + 1; i++)
            {
                for (var j = 0; j < count[i]; j++)
                {
                    A[p] = i;
                    p += 1;
                }
            }

            return A;
        }

        public static int[] SelectionSort(int[] A)
        {
            for (var i = 0; i < A.Length - 1; i++)
            {
                for (var j = i + 1; j < A.Length; j++)
                {
                    if (A[i] > A[j])
                    {
                        var help = A[i];
                        A[i] = A[j];
                        A[j] = help;
                    }
                }
            }

            return A;
        }

    }
}
