using Castle.Windsor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra
{
    public static class IoC
    {
        private static readonly object LockObj = new object();

        private static IWindsorContainer container = new WindsorContainer();

        public static IWindsorContainer Container
        {
            get { return container; }

            set
            {
                lock (LockObj)
                {
                    container = value;
                }
            }
        }

        public static T Resolve<T>()
        {
            return container.Resolve<T>();
        }

        public static object Resolve(Type type)
        {
            return container.Resolve(type);
        }
    }
}
