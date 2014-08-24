using NServiceBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Social.NServiceBus.Messages.Adapters
{
    public class FOR<CoreModelType> : ICommand where CoreModelType : new()
    {
        private CoreModelType _model;
        public CoreModelType Model
        {
            get
            {
                return _model;
            }
        }
        public FOR(CoreModelType model)
        {
            _model = new CoreModelType();
        }
    }
}
