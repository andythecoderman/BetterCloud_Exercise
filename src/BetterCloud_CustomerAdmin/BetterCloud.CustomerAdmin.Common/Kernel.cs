using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Ninject;
using Ninject.Parameters;

namespace BetterCloud.CustomerAdmin.Common
{
    public sealed class Kernel
    {
        private static readonly Kernel _instance = new Kernel();

        private readonly IKernel _injector;

        public static Kernel Instance
        {
            get
            {
                return _instance;
            }
        }

        private Kernel()
        {
            //- Load Dependency Injection Config for running application
            _injector = new StandardKernel();
        }

        /// <summary>
        /// Creates an instance of object bound to type <typeparam name="T"></typeparam>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T GetInstance<T>()
        {
            return _injector.Get<T>();
        }

        /// <summary>
        /// Creates a mapping of and interface and a concrete type
        /// </summary>
        /// <typeparam name="TInterface"></typeparam>
        /// <typeparam name="TType"></typeparam>
        public void Bind<TInterface, TType>() where TType : TInterface 
        {
            _injector.Bind<TInterface>().To(typeof (TType));
        }
    }
}
