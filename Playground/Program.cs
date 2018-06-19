using System;

namespace Playground
{
    class Program
    {
        static void Main(string[] args)
        {
            var array = new int[] { 1, 2, 3, 4, 5, 6 };

            var shiftedArray = RightCyclicRotation(array, 2);

            for (int i = 0; i < shiftedArray.Length; i++)
            {
                Console.WriteLine(shiftedArray[i]);
            }

            // var reverseArray = ReverseArray(array);

            // for (int i = 0; i < reverseArray.Length; i++)
            // {
            //     Console.WriteLine(reverseArray[i]);
            // }
        }

        public static int[] RightCyclicRotation(int[] array, int rotations)
        {
            var lastMember = array.Length - 1;

            for (int j = 0; j < rotations; j++)
            {
                var help = array[lastMember];
                
                for (int i = lastMember; i >= 0; i--)
                {
                    if(i == 0)
                    {
                        array[i] = help;
                    }
                    else
                    {
                        array[i] = array[i - 1];
                    }
                }
            }

            return array;
        }

        public static int[] ReverseArray(int[] array)
        {
            for(var i = 0; i < array.Length / 2; i++)
            {
                var help = array[i];
                array[i] = array[array.Length - 1 - i];
                array[array.Length - 1 - i] = help;
            }

            return array;
        }

        // public static IEnumerable<T> ReverseArray(this IEnumerable<T> array){
        //     Console.WriteLine("asdf");
        // }

        public static void ReverseAsteriskTriangle(string[] args){
            var n = int.Parse(args[0]);

            for(int i = 0; i < n; i++){
                for(int j = 0; j < i + 1; j++){
                    Console.Write(" * ");
                }
                Console.WriteLine("\n");
            }
        }
    }
}
