using System;
using System.Collections.Generic;
using System.Linq;

class Olympiad2012
{
    static void Main()
    {
        //1 input
        Console.Write("Enter number of students N = ");
        int n = int.Parse(Console.ReadLine());
        List<Student> students = new List<Student>();
        for (int i = 0; i < n; i++)
        {
            Console.Write("Enter name of student{0}: ", i + 1);
            string name = Console.ReadLine();
            Console.Write("Enter town of student{0}: ", i + 1);
            string town = Console.ReadLine();
            Console.Write("Enter school of student{0}: ", i + 1);
            string school = Console.ReadLine();
            Console.Write("Enter result of student{0}: ", i + 1);
            int result = int.Parse(Console.ReadLine());
            Student student = new Student();
            student.Name = name;
            student.Town = town;
            student.School = school;
            student.Result = result;
            students.Add(student);
        }
        //2 all print
        foreach (Student student in students.OrderByDescending(s => s.Result))
        {
            Console.WriteLine("{0}, {1}, {2}, {3} точки", student.Name, student.Town, student.School,student.Result);
        }
        //3 
        Console.Write("Enter town: ");
        string townInterested = Console.ReadLine();
        foreach (Student student in students.Where(s => s.Town == townInterested).OrderBy(sch => sch.School).ThenByDescending(r => r.Result))
        {
            Console.WriteLine("{0}, {1}, {2}, {3} точки", student.Name, student.Town, student.School, student.Result);
        }
        //4
        foreach (Student student in students.Where(s => s.School.Contains("СОУ") && s.Result > students.Average(x => x.Result)).OrderByDescending(s => s.Result))
        {
            Console.WriteLine("{0}, {1}, {2}, {3} точки", student.Name, student.Town, student.School, student.Result);
        }
    }
}

class Student
{    
    public string Name { get; set; }
    public string Town { get; set; }
    public string School { get; set; }
    public int Result { get; set; }
}

