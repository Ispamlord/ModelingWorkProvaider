using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace ModelingworkProvaider
{
    public class Line
    {
        public Line() { }
        private bool bussyness = false;
        public int Time { get; set; } = 0;
        private string otchet { get; set; } = "";
        public void check(QueueUsers users)
        {
            if (bussyness == false)
            {
                if (users.cout > 0)
                {
                    User user = users.Remove();
                    Time = Convert.ToInt32(user.Time) + 1;
                    otchet = "User is {user.Id}  in the process of processing\n";
                    bussyness = true;
                }
            }
            else
            {
                if (Time > 0)
                {
                    Time--;
                    otchet += "User on my line be exit";
                }
                if (Time == 0)
                {
                    bussyness = false;
                }
            }
        }
        public string Otchet()
        {
            return otchet;
        }
    }
}
