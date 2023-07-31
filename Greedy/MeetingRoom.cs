using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DS.Greedy
{
    public class MeetingRoom
    {
        public static int cmp(Meeting<int, int> a, Meeting<int, int> b)
        {
            if (a.End < b.End)
                return -1;
            else if (a.End > b.End)
                return 1;

            return 0;
        }
        public int maxMeetings(int[] start, int[] end, int n)
        {
            List<Meeting<int, int>> list = new List<Meeting<int, int>>();

            int i;

            for (i = 0; i < n; i++)
            {
                Meeting<int, int> meeting = new Meeting<int, int>(end[i], start[i]);
                list.Add(meeting);
            }

            list.Sort(cmp);

            int last_meeting = list[0].End;

            int count = 1;

            for(int idx = 1; idx < n; idx++)
            {
                int startTime = list[idx].Start;
                if(startTime > last_meeting)
                {
                    count++;
                    last_meeting = list[idx].End;
                }
            }

            return count;
        }

    }
   
    public class Meeting<T, U>
    {
        public Meeting() { }

        public Meeting(U end, T start)
        {
            this.End = end;
            this.Start = start;
        }

        public T Start
        {
            get;
            set;
        }
        public U End
        {
            get;
            set;
        }
    }
}
