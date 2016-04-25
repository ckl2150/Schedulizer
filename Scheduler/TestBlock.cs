using System;

namespace Scheduler
{
    class TestBlock
    {
        static void Main (string[] args)
        {
            Calender calender = new Calender();
            //Simulate retrieval of a class instance
            Console.WriteLine("This tester creates a Block instance, and attempts to add different classes via the addNewClass() method");
            Block lectures = new Block("lecture");
            lectures.addNewClass("Discrete", "Lecture", 8, 10, 135, "Hoopla", "Tue,Thu", "MTH", "203");
            lectures.addNewClass("Matlab", "Lecture", 12, 14, 127, "Attaway", "Mon,Wed", "PHO","103");
            lectures.addNewClass("Matlab", "Lecture", 16, 18, 127, "Attaway", "Mon,Wed", "PHO", "103");
            lectures.addNewClass("Matlab", "Lecture", 14, 16, 127, "Attaway", "Mon,Wed", "PHO", "103");
            lectures.addNewClass("Logic", "Lecture", 8, 10, 311, "Attaway", "Mon,Wed", "PHO", "210");
            lectures.addNewClass("Logic", "Lecture", 14, 16, 311, "Attaway", "Mon,Wed", "PHO", "210");

            string[] arr = lectures.getCourseNames();
            foreach (string course in arr)
            {
                Console.WriteLine(course + ": Times are ");
                int[] times = lectures.getTime(course);
                calender.addTimeSlot(times[0], times[1], lectures.getDays(course));
            }
            calender.display();
            
            //Code to test ScheduleCompuete's findSchedule() method
            ScheduleCompute algorithm = new ScheduleCompute();
            algorithm.addBlock(lectures);
            algorithm.findSchedule();
        }
    }
}