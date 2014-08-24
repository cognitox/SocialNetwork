using Social.Service.Runner.Jobs;
using Social.Service.Runner.Jobs.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Social.Cmd.Runner
{
    class Program
    {
        static void Main(string[] args)
        {
            //IRunnerJob scheduler = new TaskRunnerJob();
            //scheduler.Execute();
            while (true)
            {
                Thread.Sleep(1000);
            }
        }
    }
}
