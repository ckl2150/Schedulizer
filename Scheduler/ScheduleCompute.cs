using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace Scheduler
{
    class ScheduleCompute
    {
        private Block[] blocklist;
        private Calender calender;
        private int blockcount;
        private int howmanyclasses;
        
        public ScheduleCompute()
        {
            blocklist = new Block[3];
            calender = new Calender();
            blockcount = 0;
            howmanyclasses = 0;
        }
        
        //Schedules one block per method call
        public void findSchedule()
        {
            ClassList[] classlistarr = blocklist[blockcount].getClassObjects(); //array of values of ClassLists
            int numofclasses = blocklist[blockcount].getNumOfClasses(); //Come back--see if you really need this

            //The below block of code uses the first classlist in classlistarr as an anchor; all calculations first begin with this classlist
            ClassList anchorclasslist = classlistarr[0]; //anchor
            int anchorind = anchorclasslist.getCount();
            int[] anchortimes = anchorclasslist[anchorind].getTime();

            while (!anchorclasslist.endOfList() || !blocklist[blockcount].isValid()) //NEED ANOTHER CONDITION...this could have infinite loop if its the only condition
            {
                anchorclasslist.setFilledSlot(true); //class from anchor classlist is the first class to be added, so is always valid
                calender.addTimeSlot(anchortimes[0], anchortimes[1], anchorclasslist[anchorind].getDays());
                for (int i = 1; i < numofclasses; i++) //Loops through the remaining non-anchor class lists
                {
                    ClassList newclasslist = classlistarr[i];
                    int classlistind = newclasslist.getCount();
                    int[] times = newclasslist[classlistind].getTime();
                    while (!newclasslist.endOfList() || newclasslist.filledSlot()) //SAME AS IN FIRST WHILE LOOP
                    {
                        if (calender.hasConflict(times[0], times[1], newclasslist[classlistind].getDays()))
                        {
                            calender.addTimeSlot(times[0], times[1], newclasslist[classlistind].getDays());
                            newclasslist.incCount();
                            newclasslist.setFilledSlot(true);
                        }
                        else
                        {
                            newclasslist.incCount();
                            newclasslist.setFilledSlot(false);
                        }
                    }
                }

                foreach (ClassList c in classlistarr) //Checking if all Classlists in this block have a filled time slot
                {
                    if (!c.filledSlot())
                    {
                        blocklist[blockcount].setValid(false);
                        break;
                    }
                }

                if (blocklist[blockcount].isValid())
                {
                    blockcount++;
                    break;
                }
                else
                {
                    anchorclasslist.incCount();
                    foreach (ClassList c in classlistarr)
                    {
                        c.setFilledSlot(false); //Need to decide whether to also set blockcount back to 0...
                    }
                }
            }
        }

        public void addBlock(Block blockobj)
        {
            if (blockobj.getBlockType() == "lecture")
            {
                blocklist[0] = blockobj;
            }
            else if (blockobj.getBlockType() == "lab")
            {
                blocklist[1] = blockobj;
            }
            else if (blockobj.getBlockType() == "disc")
            {
                blocklist[2] = blockobj;
            }
        }


        //WHENEVER we add a class
        //function to make a get request to API
        public ??? request()
        {

        }

        //Function which takes JSON file and parses into a usable format
        public ??? parseFile()
        {

        }

    }
}