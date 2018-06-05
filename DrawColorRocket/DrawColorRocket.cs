using System;

class DrawRocket
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        for (int i = 1; i <= 2 * n - 1; i++)
        {
            Console.WriteLine(new string(' ', 2 * n - i) + new string('/', i) + "**" + new string('\\', i));
        }
        Console.WriteLine("+" + (new string('*', 2 * n)).Replace("*", "*=") + "+");
        for (int i = 1; i <= n; i++)
        {

            Console.WriteLine("|" + new string('.', n - i) + (new string('/', i)).Replace("/", "/\\") + new string('.', 2 * (n - i)) + (new string('/', i)).Replace("/", "/\\") + new string('.', n - i) + "|");
        }
        for (int i = n; i >= 1; i--)
        {

            Console.WriteLine("|" + new string('.', n - i) + (new string('\\', i)).Replace("\\", "\\/") + new string('.', 2 * (n - i)) + (new string('\\', i)).Replace("\\", "\\/") + new string('.', n - i) + "|");
        }
        Console.WriteLine("+" + (new string('*', 2 * n)).Replace("*", "*=") + "+");
        for (int i = n; i >= 1; i--)
        {

            Console.WriteLine("|" + new string('.', n - i) + (new string('\\', i)).Replace("\\", "\\/") + new string('.', 2 * (n - i)) + (new string('\\', i)).Replace("\\", "\\/") + new string('.', n - i) + "|");
        }
        for (int i = 1; i <= n; i++)
        {

            Console.WriteLine("|" + new string('.', n - i) + (new string('/', i)).Replace("/", "/\\") + new string('.', 2 * (n - i)) + (new string('/', i)).Replace("/", "/\\") + new string('.', n - i) + "|");
        }
        Console.WriteLine("+" + (new string('*', 2 * n)).Replace("*", "*=") + "+");
        for (int i = 1; i <= 2 * n - 1; i++)
        {
            Console.ForegroundColor = (ConsoleColor)(Math.Abs(5 - i) % 16);
            Console.WriteLine(new string(' ', 2 * n - i) + new string('/', i) + "**" + new string('\\', i));
        }
        Console.ForegroundColor = ConsoleColor.Gray;
    }
}
