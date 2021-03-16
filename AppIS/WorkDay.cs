using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppIS
{
    public class WorkDay
    {
        public string WorkerLogin { get; set; }
        public string WorkDays { get; set; }
        public WorkDay(string workerLogin, string workDay)
        {
            WorkerLogin = workerLogin;
            WorkDays = workDay;
        }
        public WorkDay()
        {
            WorkerLogin = null;
            WorkDays = null;
        }
        public WorkDay(string workerLogin)
        {
            WorkerLogin = workerLogin;
            WorkDays = null;
        }
    }
}
