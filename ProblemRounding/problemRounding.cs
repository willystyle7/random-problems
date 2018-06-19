using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;

class problemRounding
{
    static void Main()
    {
        //Decision for N > 0 and N < 15        
        //double a = double.Parse(Console.ReadLine());
        //double b = double.Parse(Console.ReadLine());
        //int n = int.Parse(Console.ReadLine());
        //double result = Math.Round((a / b), n);
        //double result = Math.Truncate((a / b) * Math.Pow(10, n)) / Math.Pow(10, n);
        //Console.WriteLine(result);

        //Decision for N > 0 and N < 1000
        BigInteger a = BigInteger.Parse(Console.ReadLine());
        BigInteger b = BigInteger.Parse(Console.ReadLine());
        int n = int.Parse(Console.ReadLine());
        BigInteger result = new BigInteger();
        result = BigInteger.Divide(BigInteger.Multiply(a, BigInteger.Pow(10, n)), b);
        string finalResult = result.ToString();
        finalResult = finalResult.Insert((finalResult.Length - n), ".");
        Console.WriteLine(finalResult);
    }
}