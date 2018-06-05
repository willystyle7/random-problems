using System;
using System.Collections.Generic;
using System.Linq;

namespace SumNumbersToControlSum
{
    class SumNumbersToControlSum
    {
        static void Main()
        {           
            int[] numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int controlSum = int.Parse(Console.ReadLine());
            int n = numbers.Length;
            Queue<int> queueSums = new Queue<int>();
            queueSums.Enqueue(numbers[0]);
            queueSums.Enqueue(-numbers[0]);
            for (int i = 1; i < n; i++)
            {
                int currentCount = queueSums.Count;
                for (int j = 0; j < currentCount; j++)
                {
                    int outQueue = queueSums.Dequeue();
                    queueSums.Enqueue(outQueue + numbers[i]);
                    queueSums.Enqueue(outQueue - numbers[i]);
                }
            }
            Console.WriteLine(queueSums.Contains(controlSum) ? "Yes" : "No");
        }
    }
}
