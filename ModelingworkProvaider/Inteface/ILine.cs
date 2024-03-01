using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelingworkProvaider.Inteface
{
    public interface ILine
    {
        int Time {  get; set; }
        void check(QueueUsers users);
    }
}
