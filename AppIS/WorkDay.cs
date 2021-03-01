using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppIS
{
    public class WorkDay
    {
        public int Id { get; set; }
        public int WorkerLogin { get; set; }
        public string WorkDay_ { get; set; }
        public WorkDay(int workerLogin, string workDay, int id)
        {
            WorkerLogin = workerLogin;
            WorkDay_ = workDay;
            Id = id;
        }
        public WorkDay()
        {
            WorkerLogin = 0;
            WorkDay_ = null;
            Id = 0;
        }
        public WorkDay(int id)
        {
            WorkerLogin = 0;
            WorkDay_ = null;
            Id = id;
        }
    }
}
