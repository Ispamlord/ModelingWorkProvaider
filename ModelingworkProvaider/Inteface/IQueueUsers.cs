using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelingworkProvaider.Inteface
{
    public interface IQueueUsers
    {
        int cout { get; }
        int Add(int serviceTime);
        User Remove();
    }
}
