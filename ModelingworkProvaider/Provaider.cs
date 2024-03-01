using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace ModelingworkProvaider
{
    public class Provaider
    {
        private Line[] lines;

        public Provaider(int count)
        {
            lines = new Line[count];
            for (int i = 0; i < lines.Length; i++)
            {
                lines[i] = new Line();
            }
        }
        public void working(QueueUsers users)
        {
            for(int i = 0; i < lines.Length; i++)
            {
                lines[i].check(users);
            }
        }
    }
}
