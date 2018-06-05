using System;
using System.Collections.Generic;
using System.Linq;

namespace SumNumbersToControlSumExtended
{
    class SumNumbersToControlSumExtended
    {
        static void Main()
        {
            int[] numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int controlSum = int.Parse(Console.ReadLine());
            int n = numbers.Length;
            Queue<int> queueSums = new Queue<int>();
            Queue<string> queueSequences = new Queue<string>();
            queueSums.Enqueue(numbers[0]);
            queueSums.Enqueue(-numbers[0]);
            string number = string.Empty;
            number = (numbers[0] >= 0) ? numbers[0].ToString() : "(" + numbers[0].ToString() + ")";
            queueSequences.Enqueue(number);
            queueSequences.Enqueue(("- " + number));
            for (int i = 1; i < n; i++)
            {
                int currentCount = queueSums.Count;
                for (int j = 0; j < currentCount; j++)
                {
                    int outQueue = queueSums.Dequeue();
                    queueSums.Enqueue(outQueue + numbers[i]);
                    queueSums.Enqueue(outQueue - numbers[i]);
                    string outQueueSequence = queueSequences.Dequeue();                    
                    number = (numbers[i] >= 0) ? numbers[i].ToString() : "(" + numbers[i].ToString() + ")";
                    queueSequences.Enqueue(outQueueSequence + " + " + number);
                    queueSequences.Enqueue(outQueueSequence + " - " + number);
                }
            }
            Console.WriteLine(queueSums.Contains(controlSum) ? "Yes" : "No");
            if (queueSums.Contains(controlSum))
            {
                while (queueSums.Count > 0)
                {
                    int sum = queueSums.Dequeue();
                    string sequence = queueSequences.Dequeue();
                    if (sum == controlSum)
                    {
                        Console.WriteLine(sequence);
                    }
                }                
            }            
        }
    }
}
