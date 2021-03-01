using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppIS
{
    public class WorkDay
    {
        public int WorkerLogin { get; set; }
        public string WorkDay_ { get; set; }
        public WorkDay(int workerLogin, string workDay)
        {
            WorkerLogin = workerLogin;
            WorkDay_ = workDay;
        }
        public WorkDay()
        {
            WorkerLogin = 0;
            WorkDay_ = null;
        }
    }
}
