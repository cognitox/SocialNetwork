
#if SERVICE

using NServiceBus;

namespace Social.Service.Runner
{

    /*
        This class configures this endpoint as a Server. More information about how to configure the NServiceBus host
        can be found here: http://particular.net/articles/the-nservicebus-host
    */
    public class EndpointConfig : IConfigureThisEndpoint, AsA_Server
    {
    }

    public class CustomInit : INeedInitialization
    {
        public void Init()
        {
            Configure.Instance.UseNHibernateSubscriptionPersister();
            Configure.Instance.UseNHibernateSagaPersister();
            Configure.Instance.UseNHibernateTimeoutPersister();
        }
    }

}

#endif