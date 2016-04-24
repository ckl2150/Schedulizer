using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheduler
{
    public class Block
    {
        //Instance variables
        private int coursecounter;
        private string type;
        private Dictionary<string, List<Class>> courses;

        //Constructor takes a type as a parameter; this specifies whether the objects within are of type lecture, discussion, or lab
        public Block(string coursetype)
        {
            coursecounter = 1; //NEEDED???
            type = coursetype;
            courses = new Dictionary<string, List<Class>>();
        }

        //Method which adds new class to dictionary. Makes new key/value pairing if it does not already exist, and adds the class to the existing list.
        public void addNewClass(string name, string classtype, int start, int end, int ccode, string profname, string schedday, string classroom, string roomno)
        {
            if (courses.ContainsKey(name))
            {
                courses[name].Add(new Class(name, classtype, start, end, ccode, profname, schedday, classroom, roomno));
            }
            else
            {
                courses.Add(name, new List<Class>());
                courses[name].Add(new Class(name, classtype, start, end, ccode, profname, schedday, classroom, roomno));
            }
        }

        //Retrieves the keys which exist in the dictionary, and returns them as an array
        public string[] getCourseNames()
        {
            string[] keys = courses.Keys.ToArray();
            return keys;
        }

        //Returns either the start or end times of a class as an integer array, given the proper string modifier
        public int[] getTimes(string name, string modifier)
        {
            int[] classTimes = new int[courses[name].Count()];
            for (int i = 0; i < courses[name].Count(); i++)
            {
                if (modifier == "start")
                {
                    classTimes[i] = courses[name][i].getStart();
                }
                else
                {
                    classTimes[i] = courses[name][i].getEnd();
                }
            }
            return classTimes;
        }
    }
}
