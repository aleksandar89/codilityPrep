using System;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace lesson7
{
    internal static class MyStack<T>
    {
        public static T[] CreateStack(params T[] initStack)
        {
            var stack = new T[initStack.Length];
            
            for (var i = 0; i < initStack.Length; i++)
            {
                stack[i] = initStack[i];
            }

            return stack;
        }

        private static void Push(T item, T[] stack)
        {
            var size = stack.Length;
            Array.Resize(ref stack, size + 1);
            
            stack[size] = item;
        }
        
        public static T Pop(T[] stack)
        {
            var size = stack.Length;

            if (size > 0)
            {
                var result = stack[size - 1];
                Array.Resize(ref stack, size - 1);

                return result;    
            }
            else
            {
                throw new InvalidOperationException();
            }
        }
    }
    
    internal static class Program
    {
        private enum BracketType
        {
            None,
            Curly,
            Square,
            Normal
        }
        
        private static void Main(string[] args)
        {
            Console.WriteLine(NestedStringStackImplementation("()()(())"));
            Console.WriteLine(NestedStringStackImplementation("()()(()))"));

            var a = new int[] {4, 3, 2, 1, 5};
            var b = new int[] {0, 1, 0, 0, 0};

            var h = new int[] {8, 8, 5, 7, 9, 8, 7, 4, 8};
            
//            Console.WriteLine(FishInTheStream(a, b));
            Console.WriteLine(NumberOfRectangles(h));
        }

        private static int NumberOfRectangles(int[] H)
        {
            var minimums = new Stack<int>();
            var count = 1;
            minimums.Push(H[0]);
            
            for (var i = 1; i < H.Length; i++)
            {
                if (H[i] > H[i-1])
                {
                    count++;
                    minimums.Push(H[i-1]);
                }
                else if(H[i] == H[i-1])
                {
                    continue;
                }
                else if (H[i] < H[i-1])
                {
                    if (minimums.Count == 0)
                    {
                        count++;
                        minimums.Push(H[i]);
                    }
                    
                    while (minimums.Count > 0)
                    {
                        var minimum = minimums.Pop();
                        
                        if (minimum == H[i])
                        {
                            continue;
                        }
                        else if(H[i] < minimum)
                        {
                            continue;
                        }
                        else
                        {
                            count++;
                            minimums.Push(H[i]);
                            break;
                        }
                    }
                }
            }

            return count;
        }

        private static int FishInTheStream(int[] A, int[] B)
        {
            var size = 0;
            var stack = new int[A.Length];
            
            Push(0, stack, ref size);
            
            for (var Q = 1; Q < B.Length; Q++)
            {
                var P = Pop(stack, ref size);

                if (B[P] > B[Q])
                {
                    int victor;
                    
                    do
                    {
                        if (A[Q] > A[P])
                        {
                            victor = Q;
                            try
                            {
                                P = Pop(stack, ref size);
                            }
                            catch (Exception e)
                            {
                                break;
                            }
                        }
                        else
                        {
                            victor = P;
                            break;
                        }
                    } while (B[P] > B[Q]);
                    
                    if(B[P] <= B[Q])
                    {
                        Push(P, stack, ref size);
                    }

                    Push(victor, stack, ref size);
                }
                else
                {
                    Push(P, stack, ref size);
                    Push(Q, stack, ref size);
                }
            }

            return size;
        }
        
        private static void Push(int item, int[] stack, ref int size)
        {
            stack[size] = item;
            
            size += 1;
        }

        private static int Pop(int[] stack, ref int size)
        {
            if (size > 0)
            {
                var result = stack[size - 1];
                size -= 1;

                return result;    
            }
            else
            {
                throw new InvalidOperationException();
            }
        }
        
        private static void Push(char item, char[] stack, ref int size)
        {
            stack[size] = item;
            
            size += 1;
        }

        private static char Pop(char[] stack, ref int size)
        {
            if (size > 0)
            {
                var result = stack[size - 1];
                size -= 1;

                return result;    
            }
            else
            {
                throw new InvalidOperationException();
            }
        }
        
        private static int NestedStringStackImplementation(string s)
        {
            var size = 0;
            var stack = new char[s.Length];
            var charrArray = s.ToCharArray();

            foreach (var character in charrArray)
            {
                switch (character)
                {
                    case '{':
                    case '(':
                    case '[':
                        Push(character, stack, ref size);
                        break;
                    case '}':
                        try
                        {
                            var popped = Pop(stack, ref size);
                            if (popped != '{')
                                return 0;
                        }
                        catch (Exception e)
                        {
                            return 0;
                        }
                        break;
                    case ')':
                        try
                        {
                            var popped = Pop(stack,ref size);
                            if (popped != '(')
                                return 0;
                        }
                        catch (Exception e)
                        {
                            return 0;
                        }
                        break;
                    case ']':
                        try
                        {
                            var popped = Pop(stack,ref size);
                            if (popped != '[')
                                return 0;
                        }
                        catch (Exception e)
                        {
                            return 0;
                        }
                        break;
                }
            }

            return size == 0 ? 1 : 0;
        }

        private static int NestedStringAdvance(string s)
        {
            var charArray = s.ToCharArray();
            long correctBracketPairing = 0;
            long correctSquareBracketPairing = 0;
            long correctCurlyBrcketPairing = 0;
            var currentType = BracketType.None;
            
            foreach (var character in charArray)
            {
                switch (character)
                {
                    case '(':
                        correctBracketPairing++;
                        currentType = BracketType.Normal;
                        break;
                    case ')':
                        if (currentType != BracketType.Normal)
                        {
                            return 0;
                        }
                        correctBracketPairing--;
                        break;
                    case '{':
                        correctCurlyBrcketPairing++;
                        currentType = BracketType.Curly;
                        break;
                    case '}':
                        if (currentType != BracketType.Curly)
                        {
                            return 0;
                        }
                        correctCurlyBrcketPairing--;
                        break;
                    case '[':
                        correctSquareBracketPairing++;
                        currentType = BracketType.Square;
                        break;
                    case ']':
                        if (currentType != BracketType.Square)
                        {
                            return 0;
                        }
                        correctSquareBracketPairing--;
                        break;
                    default:
                        return 0;
                }

                if (correctBracketPairing < 0 || correctCurlyBrcketPairing < 0 || correctSquareBracketPairing < 0)
                    return 0;
            }

            if (correctBracketPairing == 0 && correctCurlyBrcketPairing == 0 && correctSquareBracketPairing == 0)
            {
                return 1;
            }
            
            return 0;
        }

        private static int NestedString(string s)
        {
            var charArray = s.ToCharArray();
            var correctPairing = 0;
            
            foreach (var character in charArray)
            {
                switch (character)
                {
                    case '(':
                        correctPairing++;
                        break;
                    case ')':
                        correctPairing--;
                        break;
                    default:
                        return 0;
                }

                if (correctPairing < 0)
                    return 0;
            }

            return correctPairing == 0 ? 1 : 0;
        }
    }
}
