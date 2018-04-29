using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Is3106Lecture12DotNet.Models
{
    public class Demo01ViewModel
    {
        public int RequestScopedCounter { get; set; }
        public int SessionScopedCounter { get; set; }
        public string SessionScopedString { get; set; }
        public Book SessionScopedObject { get; set; }



        public Demo01ViewModel()
        {
            RequestScopedCounter = 0;
            SessionScopedCounter = 0;
        }



        public void incrementCounters()
        {
            this.RequestScopedCounter++;
            this.SessionScopedCounter++;
        }
    }
}
