using System.Collections.Generic;
using AutomaticParking.Common.Extensions;
using UnityEngine;
using UnityEngine.Pool;

namespace AutomaticParking.Car.Creation
{
    public class CarSpawner : MonoBehaviour
    {
        [SerializeField] private CarPoolsInitializer carPoolsInitializer;
        private readonly Dictionary<Transform, IObjectPool<Transform>> cars = new();

        public Transform Spawn(Transform parkingSpot)
        {
            IObjectPool<Transform> randomCarPool = carPoolsInitializer.CarPools.RandomItem();
            Transform car = randomCarPool.Get();
            cars.Add(car, randomCarPool);
            return car;
        }

        public void DeSpawnAll()
        {
            foreach ((Transform car, IObjectPool<Transform> pool) in cars)
                pool.Release(car);
            cars.Clear();
        }
    }
}