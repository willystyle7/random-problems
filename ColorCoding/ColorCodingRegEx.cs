using System;
using System.Text.RegularExpressions;

namespace ColorCodingRegEx
{
    class ColorCodingRegEx
    {
        static void Main(string[] args)
        {
            int numberCouples = int.Parse(Console.ReadLine());            
            for (int n = 0; n < numberCouples; n++)
            {
                string firstRow = Console.ReadLine();
                string secondRow = Console.ReadLine();
                firstRow += " "; 
                secondRow += " ";                
                string pattern = "^" + firstRow.Replace(") ", " )?") +"$";                
                if (Regex.IsMatch(secondRow, pattern))
                {
                    Console.WriteLine("true");
                }
                else
                {
                    Console.WriteLine("false");
                }
                GC.Collect();
            }
        }
    }
}
