using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Concurrent;
using System.Threading;

namespace LastConsoleAppThatWithProgressBar
{
    public class AppController
    {
        List<int> list = new List<int>();

        private int start;
        private int finish;

        public void setStart(int start)
        {
            this.start = start;
        }

        public void setFinish(int finish)
        {
            this.finish = finish;
        }

        public void executeAdd(int i)
        {
            Thread thread = new Thread(() => {
                lock (this)
                {
                    list.Add(start + i);
                }
            });
           thread.Start();
           thread.Join();
              
        }

        public String getStringRepresantationOfList()
        {
            String res ="";
            lock (this) 
            {
                list.ForEach(x => res += x.ToString() + " ");
            }
            return res;
        }
       
    }
}
