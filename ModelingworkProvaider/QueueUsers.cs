using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelingworkProvaider
{
    public class QueueUsers
    {
        public Queue<User> queue;
        public int cout { get; set; }
        public QueueUsers()
        {
            queue = new Queue<User>();
        }
        public void Add(int servisetime)
        {
            queue.Enqueue(new User(servisetime));
            cout++;
        }
        public User Remove()
        {
            cout--;
            return queue.Dequeue();
        }
        public void Clear()
        {
            queue.Clear();
        }
    }
}
