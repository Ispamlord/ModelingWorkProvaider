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
                    bussyness = true;
                }
            }
            else
            {
                if (Time > 0)
                {
                    Time--;
                    
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
