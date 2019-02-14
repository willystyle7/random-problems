using System;
using System.Linq;

class ClimbingTheLeaderboard
{
    static void Main()
    {
        var a = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var b = Console.ReadLine().Split().Select(int.Parse).ToArray();
        Console.WriteLine(string.Join(" ", ClimbingLeaderboard(a, b)));
    }

    static int[] ClimbingLeaderboard(int[] scores, int[] alice)
    {
        scores = scores.OrderByDescending(s => s).ToArray();
        var ranks = new int[scores.Length];
        var aliceRanks = new int[alice.Length];
        int rank = 1;
        ranks[0] = rank;
        for (int i = 1; i < scores.Length; i++)
        {
            if (scores[i] < scores[i - 1]) rank++;
            ranks[i] = rank;
        }
        for (int i = 0; i < alice.Length; i++)
        {
            for (int j = 0; j < scores.Length; j++)
            {
                if (alice[i] >= scores[j])
                {
                    aliceRanks[i] = ranks[j];
                    break;
                }
                if (j == scores.Length - 1) aliceRanks[i] = rank + 1;
            }            
        }
        return aliceRanks;
    }    
}

