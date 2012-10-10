using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MaxArrayProblem
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
            int[] arr1 = { 22, -27, 38, -34, 49, 40, 13, -44, -13, 28, 46, 7, -26, 42, 29, 0, -6, 35, 23, -37, 10, 12, -2, 18, -12, -49, -10, 37, -5, 17, 6, -11, -22, -17, -50, -40, 44, 14, -41, 19, -15, 45, -23, 48, -1, -39, -46, 15, 3, -32, -29, -48, -19, 27, -33, -8, 11, 21, -43, 24, 5, 34, -36, -9, 16, -31, -7, -24, -47, -14, -16, -18, 39, -30, 33, -45, -38, 41, -3, 4, -25, 20, -35, 32, 26, 47, 2, -4, 8, 9, 31, -28, 36, 1, -21, 30, 43, 25, -20, -42 }; // 239
            int[] arr2 = { -18, -47, -40, -43, -2, 48, 31, -24, 36, -49, 4, -29, -4, -39, 12, 24, 8, 40, 45, -17, 6, -11, -5, -30, -8, 25, -44, -9, -20, -50, -12, -32, 41, 10, -42, -15, 11, -38, 37, 21, 33, -22, 16, -41, -46, -33, -26, 7, -3, -28, 29, 20, 27, 3, 15, 49, 23, -1, 14, 32, -31, -13, -48, -14, 13, 39, 46, -35, -36, 0, 17, -27, -21, 28, -7, 44, -10, 34, -19, 47, 42, -34, 5, 26, -45, 35, 9, -25, 38, -37, -23, 22, -6, -16, 18, 43, 30, 2, 19, 1 }; // 322
            int[] arr3 = { 3, 35, -45, 12, 44, 6, 46, -33, -15, 39, -19, 19, -31, -41, -35, 23, -25, 42, 2, 22, 40, -40, -24, 38, 14, 10, -44, 31, 16, 48, 29, 20, 32, -13, 43, -49, -10, 21, 28, 49, -28, -36, 36, -21, -26, 15, 25, -34, -20, -42, -43, 33, 1, -39, 45, 18, 27, -12, -22, -1, 47, -17, -4, 41, -32, -2, -5, -48, -7, 37, 8, -3, 26, -27, -6, 7, -47, -8, 11, -46, 9, -23, 4, -30, -9, -18, -29, 17, -11, 30, -50, -14, 24, 5, 34, 0, 13, -37, -16, -38 }; // 305

            
            CalculateArray(arr3);
            Console.ReadKey();

        }

        static void CalculateArray(int[] arr)
        {
            for (int i = 0; i < arr.Length; ++i)
            {
                Console.Write("{0}({2})\t{1}", arr[i], (i + 1) % 10 == 0 ? "\n" : "", i);
            }
            Console.WriteLine();



            Console.WriteLine("Algorithm 1 Result: {0}", MaxSubArray1(arr));
            Console.WriteLine("Algorithm 2 Result: {0}", MaxSubArray2(arr));
            Console.WriteLine("Algorithm 3 Result: {0}", MaxSubArray3(arr, 0, arr.Length - 1));
            Console.WriteLine("Algorithm 4 Result: {0}", MaxSubArray4(arr));
        }

        static int MaxSubArray1(int[] arr)
        {
            int max = 0;
            for (int i = 0; i < arr.Length; ++i)
            {
                int maxForCurrRange = 0;
                for (int j = i; j < arr.Length; ++j)
                {
                    int currSum = 0;
                    for (int k = i; k <= j; ++k)
                    {
                        currSum += arr[k];
                    }
                    if (currSum > maxForCurrRange)
                    {
                        maxForCurrRange = currSum;
                    }
                }
                if (max < maxForCurrRange)
                {
                    max = maxForCurrRange;
                } 
            }
            return max;
        }

        static int MaxSubArray2(int[] arr)
        {
            int max = 0;

            for (int i = 0; i < arr.Length; ++i)
            {
                int currentMax = 0;

                for (int j = i; j < arr.Length; ++j)
                {
                    currentMax += arr[j];

                    if (max < currentMax)
                    {
                        max = currentMax;
                    }
                }
            }

            return max;            
        }

        

        static int MaxSubArray3(int[] arr, int start, int finish)
        {
            
            if (start == finish) {
                return arr[start];
            }
            else {
                int leftSum = MaxSubArray3(arr, start, (start + finish) / 2);
                int rightSum = MaxSubArray3(arr, (start + finish) / 2 + 1, finish);

                int midSum = 0;
                int currLeftSum = 0;
                int currRightSum = 0;
                int bestLeftSum = 0;
                int bestRightSum = 0;

                for (int i = (start+finish) / 2; i >= start; --i)
                {
                    currLeftSum += arr[i];

                    if (currLeftSum > bestLeftSum)
                    {
                        bestLeftSum = currLeftSum;
                    }
                    
                }
                for (int i = (start+finish) / 2 + 1; i <= finish; ++i)
                {
                    currRightSum += arr[i];
                
                    if (currRightSum > bestRightSum)
                    {
                        bestRightSum = currRightSum;
                    }
                }

                midSum = bestRightSum + bestLeftSum;

                return Math.Max(midSum, Math.Max(leftSum, rightSum));

            }
        }

        static int MaxSubArray4(int[] arr)
        {
            int currentMax = 0;
            int endHere = 0;

            for (int i = 0; i < arr.Length; ++i)
            {
                if (endHere + arr[i] < 0)
                {
                    endHere = 0;
                }
                else
                {
                    endHere += arr[i];
                }

                if (currentMax < endHere)
                {
                    currentMax = endHere;
                }
            }

            return currentMax;
        }
    }
}
