using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelingworkProvaider
{
    public class User
    {
        public  int Id { get; set; }
        public int Time;
        private static int nextId { get; set; } = 0;
        public User(int time) {
            Id = nextId;
            Time = time+1;
            nextId++;
        }
    }
}
