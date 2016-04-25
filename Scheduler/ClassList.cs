using System;
using System.Collections.Generic;

namespace Scheduler
{
	public class ClassList : List<Class> {
        
        private int counter;
        private bool slotfilled = false;
        
		public ClassList() {
            counter = 0;
        }

        public int getCount()
        {
            return counter;
        }

        public void incCount()
        {
            counter++;
        }

        public void resetCount()
        {
            counter = 0;
        }

        public bool endOfList()
        {
            return counter == Count;
        }

        public void setFilledSlot(bool condition)
        {
            slotfilled = condition;
        }

        public bool filledSlot()
        {
            return slotfilled;
        }
	}
}