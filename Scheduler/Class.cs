using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheduler
{
    public class Class
    {
        private string className;
        private string type;
        private int startTime;
        private int endTime;
        private int code;
        private string prof;
        private string days;
        private string room;
        private bool conflict;

        public Class()
        {
            //Default constructor...need anything? Won't ever be calling default constructor...maybe throw error?
        }

        public Class(string name, string classtype, int start, int end, int ccode, string profname, string schedday, string classroom,
            string roomno)
        {
            className = name;
            type = classtype;
            startTime = start;
            endTime = end;
            code = ccode;
            prof = profname;
            days = schedday;
            room = classroom;
            conflict = false;
        }

        public int getStart()
        {
            return startTime;
        }

        public int getEnd()
        {
            return endTime;
        }

        public bool getConflict()
        {
            return conflict;
        }

        public void setConflict(bool condition)
        {
            conflict = condition;
        }

        //do we really need get functions? Or do we want to set these values to public?

    }
}