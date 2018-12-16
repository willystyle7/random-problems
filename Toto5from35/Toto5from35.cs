using System;
using System.Collections.Generic;
using System.Linq;

class Toto5from35
{
    static void Main()
    {
        string input = Console.ReadLine();
        Dictionary<int, int> numbersCounter = new Dictionary<int, int>();
        while (input != "end")
        {
            int[] numbers = input.Split().Select(int.Parse).ToArray();
            foreach (var number in numbers)
            {
                if (!numbersCounter.ContainsKey(number))
                {
                    numbersCounter[number] = 0;
                }
                numbersCounter[number]++;
            }
            input = Console.ReadLine();
        }
        Console.WriteLine("Most frequent number is " + numbersCounter.OrderByDescending(x => x.Value).First().Key);
        foreach (var number in numbersCounter.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
        {
            Console.WriteLine("Number {0} has met {1} times.", number.Key, number.Value);
        }
    }
}

