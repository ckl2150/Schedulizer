using System;

namespace Scheduler
{
    public class Calender
    {
        private bool[,] planner;

        public Calender()
        {
            planner = new bool[28, 5];
        }

        public void erase()
        {
            for (int i = 0; i < 28; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (planner[i, j] == true)
                    {
                        planner[i, j] = false;
                    }
                }
            }
        }

        public void addTimeSlot(int start, int end, string days)
        {
            int timeDiff = end - start;
            int[] day = convertDay2Num(days);

            foreach (int j in day)
            {
                for (int i = start*2 - 16; i < start*2 - 16 + timeDiff*2; i++)
                {
                    planner[i, j] = true;
                }
            }
        }

        public bool hasConflict(int start, int end, string days)
        {
            bool conflict = false;
            int dayDiff = end - start;
            int[] day = convertDay2Num(days);

            foreach (int j in day)
            {
                for (int i = start; i < start + dayDiff; i++)
                {
                    if (planner[i, j])
                    {
                        conflict = true;
                        break;
                    }
                }
                if (conflict) { break; }
            }
            return conflict;
        }

        private int[] convertDay2Num(string days)
        {
            int[] dayValues;

            if ((days == "Mon,Wed") || (days == "Tue,Thu"))
            {
                dayValues = new int[2];
                if (days == "Mon,Wed")
                {
                    dayValues[0] = 0;
                    dayValues[1] = 2;
                }
                else
                {
                    dayValues[0] = 1;
                    dayValues[1] = 3;
                }
            }
            else
            {
                dayValues = new int[1];
                if (days == "Mon") { dayValues[1] = 0; }
                else if (days == "Tue") { dayValues[1] = 1; }
                else if (days == "Wed") { dayValues[1] = 2; }
                else if (days == "Thu") { dayValues[1] = 3; }
                else if (days == "Fri") { dayValues[1] = 4; }
            }
            return dayValues;
        }

        public void display()
        {
            for (int i = 0; i < 28; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    Console.Write(planner[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}