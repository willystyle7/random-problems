using System;
using System.Collections.Generic;
using System.Linq;

class StudentsFriends
{
    static void Main()
    {
        List<Student> students = new List<Student>();
        List<Tuple<Student, Student>> friendships = new List<Tuple<Student, Student>>();
        Dictionary<int, List<int>> friendsDict = new Dictionary<int, List<int>>();
        string input;
        Console.WriteLine("Enter students (format:Number Name Gender)");
        while ((input = Console.ReadLine()) != "END")
        {
            string[] token = input.Split();
            Student student = new Student();
            student.Number = int.Parse(token[0]);
            student.Name = token[1];
            student.Gender = token[2];
            students.Add(student);
        }
        Console.WriteLine("Enter friendships (format:Number1 Number2)");
        while ((input = Console.ReadLine()) != "END")
        {
            int[] token = input.Split().Select(int.Parse).ToArray();
            int number1 = token[0];
            int number2 = token[1];
            Student student1 = Student.FindStudent(number1, students);
            Student student2 = Student.FindStudent(number2, students);
            Tuple<Student, Student> friendship = Tuple.Create(student1, student2);
            friendships.Add(friendship);
        }
        foreach (var frienship in friendships)
        {
            int number1 = frienship.Item1.Number;
            int number2 = frienship.Item2.Number;
            if (friendsDict.ContainsKey(number1))
            {
                friendsDict[number1].Add(number2);
            }
            else
            {
                friendsDict[number1] = new List<int>();
                friendsDict[number1].Add(number2);
            }
            if (friendsDict.ContainsKey(number2))
            {
                friendsDict[number2].Add(number1);
            }
            else
            {
                friendsDict[number2] = new List<int>();
                friendsDict[number2].Add(number1);
            }
        }
        Console.WriteLine("Enter student(format:Number)");
        int number = int.Parse(Console.ReadLine());
        Console.WriteLine("Student:");
        Student.PrintStudent(number, students);        
        List<int> studentFriends = new List<int>();
        List<int> studentFriendsFriends = new List<int>();
        List<int> studentFriendsFriendsNotHisFriends = new List<int>();
        //1
        studentFriends = friendsDict[number].Distinct().ToList();
        //2
        foreach (int friend in studentFriends)
        {            
            studentFriendsFriends.AddRange(friendsDict[friend]);
        }
        studentFriendsFriends = studentFriendsFriends.Distinct().ToList();
        //3
        foreach (int friend in studentFriendsFriends)
        {
            if (!studentFriends.Contains(friend))
            {
                studentFriendsFriendsNotHisFriends.Add(friend);
            }
        }
        Console.WriteLine("Student's friends are:");
        foreach (int friend in studentFriends)
        {
            Student.PrintStudent(friend, students);
        }
        Console.WriteLine("Student's friends friend's are:");
        foreach (int friend in studentFriendsFriends)
        {
            Student.PrintStudent(friend, students);
        }
        Console.WriteLine("Student's friends friend's who are not his friens are:");
        foreach (int friend in studentFriendsFriendsNotHisFriends)
        {
            Student.PrintStudent(friend, students);
        }
    }
}

class Student
{
    public int Number { get; set; }
    public string Name { get; set; }
    public string Gender { get; set; }

    static public Student FindStudent(int number, List<Student> students)
    {
        Student student = new Student();
        student = students.Where(x => x.Number == number).First();
        return student;
    }

    static public void PrintStudent(int number, List<Student> students)
    {
        Student student = Student.FindStudent(number, students);
        Console.WriteLine("{0} {1} {2}", student.Number, student.Name, student.Gender);
    }

}

/*
Input example:
1234 Milen male
4454 Todor male
3323 Maria female
6546 Georgi male
4454 Elena female
3323 Veronika female
6546 Vasil male
END
1234 3323
3323 4454
6546 3323
4454 6546
1234 6546
END
1234
*/
