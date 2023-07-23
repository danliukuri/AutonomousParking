using AutonomousParking.Common.Patterns.Pool;
using UnityEngine;
using UnityEngine.Pool;

namespace AutonomousParking.Common.Patterns.Factory
{
    public class ComponentPoolFactory<TComponent> where TComponent : Component
    {
        private readonly ComponentFactory<TComponent> componentFactory;
        private readonly PoolData data;

        public ComponentPoolFactory(ComponentFactory<TComponent> componentFactory, PoolData data)
        {
            this.componentFactory = componentFactory;
            this.data = data;
        }

        public ObjectPool<TComponent> Create() => new(componentFactory.Create,
            componentFactory.OnGetFromPool, componentFactory.OnReleaseToPool, componentFactory.DestroyPoolObject, 
            data.ThrowErrorIfItemAlreadyInPoolWhenRelease, data.StartCapacity, data.MaxSize);

        public IObjectPool<TComponent> FillWithStartObjects(IObjectPool<TComponent> pool)
        {
            for (var i = 0; i < data.StartCount; i++)
                pool.Release(componentFactory.Create());
            return pool;
        }
    }
}