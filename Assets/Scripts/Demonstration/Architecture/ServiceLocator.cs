using System;
using System.Collections.Generic;
using System.Linq;

namespace AutomaticParking.Demonstration.Architecture
{
    public class ServiceLocator
    {
        private static readonly Lazy<ServiceLocator> lazyServiceLocator = new();
        private readonly Dictionary<Type, HashSet<object>> services = new();
        public static ServiceLocator Instance => lazyServiceLocator.Value;

        public T Register<T>(T service)
        {
            services.TryAdd(typeof(T), new HashSet<object>());
            services[typeof(T)].Add(service);
            return service;
        }

        public T Unregister<T>(T service)
        {
            services[typeof(T)].Remove(service);
            if (!services[typeof(T)].Any())
                services.Remove(typeof(T));
            return service;
        }

        public HashSet<T> Get<T>() =>
            services.ContainsKey(typeof(T)) ? services[typeof(T)].Cast<T>().ToHashSet() : new HashSet<T>();
    }
}