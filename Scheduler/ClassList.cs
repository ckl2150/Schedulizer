using System;
using System.Collections.Generic;

namespace Scheduler
{
	public class ClassList : List<Class> {
        
        private int counter;
        
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

        public bool endOfList()
        {
            return counter == Count - 1;
        }
	}
}