using NServiceBus;
using Social.Core.Models.Email;
using Social.NServiceBus.Messages.Adapters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Social.Service.Runner.Handlers
{
    public class EmailNotificationHandler : IHandleMessages<FOR<ParsableEmailAccount>>
    {
        public IBus Bus { get; set; }

        public void Handle(FOR<ParsableEmailAccount> message)
        {
            var model = message.Model;
            
            //Do some stuff...

            //send to subscribers

            throw new NotImplementedException();
        }
    }
}
