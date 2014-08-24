using Social.Service.Scheduler.Logic;
using Social.Service.Scheduler.Logic.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Social.Cmd.Scheduler
{
    class Program
    {
        static void Main(string[] args)
        {
            ISocialAppScheduler scheduler = new SocialAppScheduler();
            scheduler.Start();
        }
    }
}
