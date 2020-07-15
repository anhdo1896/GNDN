using System;
using System.ComponentModel;
using Spirit.Core.IoC;
using Spirit.Core.IoC.Proxies;
using IContainer = Spirit.Core.IoC.IContainer;


namespace Connection
{
    public static class Provider
    {
        private static readonly IContainer container = new SpiritContainer();

        static Provider()
        {
            container.RegisterProxy(new CacheProxy());

            container.Register(typeof(IDbHelper), typeof(MSSqlHelper));

        }

        public static IContainer Container
        {
            get
            {
                return container;
            }
        }

        public static T Resolve<T>()
        {
            return container.Resolve<T>();
        }

    }

    
}
