using System;

namespace Lesson_1
{
    class Program
    {
        static void Main(string[] args)
        {
            var result = solution(3515);

            Console.WriteLine(result);           
        }

        public static int solution(int N) 
        {
            string binary = Convert.ToString(N, 2);

            var zeroCount = 0;
            var firstOne = 0;
            var longestGap = 0;

            for(int i = 0; i < binary.Length; i++){
                if(binary[i] != 0){
                    firstOne = i;
                    break;
                }
            }

            for(int i = firstOne + 1; i < binary.Length - firstOne; i++){
                if(binary[i] == '0') {
                    zeroCount += 1;
                }
                else {
                    longestGap = longestGap < zeroCount ? zeroCount : longestGap;
                    zeroCount = 0;
                }
            }

            return longestGap;
        }
    }
}
