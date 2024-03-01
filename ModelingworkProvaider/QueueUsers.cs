using ModelingworkProvaider.Inteface;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelingworkProvaider
{
    public class QueueUsers :IQueueUsers
    {
        public Queue<User> queue;
        public int cout { get; set; }
        public QueueUsers()
        {
            queue = new Queue<User>();
        }
        public int Add(int servisetime)
        {
            User user = new User(servisetime);
            queue.Enqueue(user);
            cout++;
            return user.Id;
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
