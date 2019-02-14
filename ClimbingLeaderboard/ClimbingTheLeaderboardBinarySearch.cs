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
            aliceRanks[i] = BinarySearch(scores, alice[i], ranks);
        }
        return aliceRanks;
    }

    static int BinarySearch(int[] scores, int aliceScore, int[] ranks)
    {
        if (aliceScore >= scores[0]) return 1;
        if (aliceScore < scores[scores.Length - 1]) return (ranks[ranks.Length - 1] + 1);
        if (aliceScore == scores[scores.Length - 1]) return (ranks[ranks.Length - 1]);
        int min = 0;
        int max = scores.Length - 1;
        while (min <= max)
        {            
            int mid = (min + max) / 2;
            if (aliceScore == scores[mid])
            {
                return ranks[mid];
            }
            else if (aliceScore < scores[mid])
            {
                if (aliceScore > scores[mid + 1])
                {
                    return ranks[mid + 1];
                }
                else
                {
                    min = mid + 1;                    
                }
            }
            else
            {
                if (aliceScore < scores[mid - 1])
                {
                    return ranks[mid];
                }
                else
                {
                    max = mid - 1;
                }                
            }
        }
        return 0;
    }
}

