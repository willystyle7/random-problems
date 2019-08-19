using System;
using System.Collections.Generic;
using System.Linq;

namespace ProblemsCSharp
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            // problem 1
            Console.Write("Enter array: ");
            int[] arr = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            Console.WriteLine("Sum of two max elements: " + SumOf2MaxElements(arr));

            // problem 2
            Console.Write("Enter check sum: ");
            int checkSum = int.Parse(Console.ReadLine());
            Console.WriteLine("There are exactly two elements with that sum: " + CheckSum(arr, checkSum));

            // problem 3
            Console.Write("Enter sorted array1: ");
            int[] arr1 = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            Console.Write("Enter sorted array2: ");
            int[] arr2 = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            Console.WriteLine("Sorted union is: " + String.Join(" ", SortedUnion(arr1, arr2)));

            // problem 4
            Console.WriteLine("Sorted union with unique elements is: " + String.Join(" ", SortedUnion(arr1, arr2).Distinct().ToArray()));

            // problem 5
            double sum = 0, interest = 0;
            int monthsCount = 0, month = 0;
            Console.Write("Enter sum: "); sum = double.Parse(Console.ReadLine());
            Console.Write("Enter interest in %: "); interest = double.Parse(Console.ReadLine());
            Console.Write("Enter monthsCount: "); monthsCount = int.Parse(Console.ReadLine());
            Console.Write("Enter month: "); month = int.Parse(Console.ReadLine());
            Console.WriteLine("Expected fee after {0} month{1} is: {2:F2}", month, month > 0 ? "s" : "", MonthlyFee(sum, interest, monthsCount, month));

            // problem 6
            Console.Write("Enter EGNs: ");
            string[] egns = Console.ReadLine().Split(' ');
            Console.WriteLine("Count of males Sagittarius: " + CountOfMaleSagittarius(egns));
        }

        public static int SumOf2MaxElements(int[] arr)
        {
            var list = arr.ToList();
            int sum = 0;
            for (int i = 1; i <= 2; i++)
            {
                if (list.Any())
                {
                    int max = list.Max();
                    list.Remove(max);
                    sum += max;
                }
            }
            return sum;
        }

        public static bool CheckSum(int[] arr, int checkSum)
        {
            int counter = 0;
            for (int i = 0; i < arr.Length - 1; i++)
            {
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[i] + arr[j] == checkSum)
                    {
                        counter++;
                    }
                }
            }
            return counter == 1;
        }

        public static int[] SortedUnion(int[] arr1, int[] arr2)
        {
            var sortedUnion = new Stack<int>();
            var queue1 = new Queue<int>(arr1);
            var queue2 = new Queue<int>(arr2);
            while (queue1.Any() || queue2.Any())
            {
                int el1 = int.MaxValue;
                int el2 = int.MaxValue;
                if (queue1.Any())
                {
                    el1 = queue1.Peek();
                }
                if (queue2.Any())
                {
                    el2 = queue2.Peek();
                }
                if (el1 <= el2)
                {
                    sortedUnion.Push(queue1.Dequeue());
                }
                else
                {
                    sortedUnion.Push(queue2.Dequeue());
                }
            }
            return sortedUnion.ToArray();
        }

        public static double MonthlyFee(double sum, double interest, int monthsCount, int month)
        {
            double monthlyFee = sum / monthsCount;
            double currentSum = sum - (month - 1) * monthlyFee;
            double fee = monthlyFee + currentSum * (interest / 12 / 100);
            if (month > 0 && month <= monthsCount)
            {
                return fee;
            }
            else
            {
                return 0.0;
            }
        }

        public static int CountOfMaleSagittarius(string[] arr)
        {
            return arr.ToList().Where(egn => IsMale(egn) && IsSagittarius(egn)).Count();

            bool IsMale(string egn)
            {
                return int.Parse(egn[8].ToString()) % 2 == 0;
            }

            bool IsSagittarius(string egn)
            {
                int month = int.Parse(egn.Substring(2, 2));
                int date = int.Parse(egn.Substring(4, 2));
                return (month == 11 && date >= 23) || (month == 12 && date <= 21);
            }
        }
    }
}
