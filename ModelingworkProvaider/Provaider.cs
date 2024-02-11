using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace ModelingworkProvaider
{
    public class Provaider
    {
        public Queue<User> users = new Queue<User>();
        public RandomForAll RandomForAll = new RandomForAll();
        public List<Line> lines = new List<Line>();
        public int TimeWork {  get; set; }
        public Provaider(int timeWork, int linecount)
        {
            TimeWork = timeWork;
            for(int i = 0; i< linecount; i++) { 
                lines.Add(new Line());
            }
        }
        public void working()
        {

        }
        
    }
}
