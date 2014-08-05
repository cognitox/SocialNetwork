using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//http://codereview.stackexchange.com/questions/8307/implementing-factory-design-pattern-with-generics

namespace Social.Core.Factories
{
    /// <summary>
    /// This Factory should track all of the running services within a database table
    /// To determine all of the resources currently being used by all services and the 
    /// System
    /// </summary>
    /// <typeparam name="InterfaceType"></typeparam>
    /// <typeparam name="EnumType"></typeparam>
    public class DBTrackedFactory<InterfaceType, EnumType>
    {
        private String _section;
        private DBTrackedFactory() { }
        private DBTrackedFactory(String section) 
        {
            _section = section;
        }

        static readonly Dictionary<EnumType, Func<InterfaceType>> _dict
             = new Dictionary<EnumType, Func<InterfaceType>>();

        public static InterfaceType Create(EnumType @enum)
        {
            Func<InterfaceType> constructor = null;
            if (_dict.TryGetValue(@enum, out constructor))
                return constructor();

            throw new ArgumentException("No type registered for this id");
        }

        public static void Register(EnumType @enum, Func<InterfaceType> ctor)
        {
            _dict.Add(@enum, ctor);
        }
    }
}
