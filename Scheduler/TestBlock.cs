using System;

namespace Scheduler
{
    class TestBlock
    {
        static void Main (string[] args)
        {
            //Simulate retrieval of a class instance
            Console.WriteLine("This tester creates a Block instance, and attempts to add different classes via the addNewClass() method");
            Block lectures = new Block("lecture");
            lectures.addNewClass("Matlab", "Lecture", 12, 14, 127, "Attaway", "MW", "PHO","103");
            lectures.addNewClass("Matlab", "Lecture", 2, 4, 127, "Attaway", "MW", "PHO", "103");
            lectures.addNewClass("Logic", "Lecture", 2, 4, 311, "Attaway", "MW", "PHO", "210");
            lectures.addNewClass("Discrete", "Lecture", 10, 12, 135, "Hoopla", "TR", "MTH", "203");
            string[] arr = lectures.getCourseNames();
            foreach (string course in arr)
            {
                Console.Write(course + ": Times are ");
                int[] start = lectures.getTimes(course, "start");
                foreach (int time in start)
                {
                    Console.Write(time + ", ");
                }
                Console.WriteLine();
            }
        }
    }
}