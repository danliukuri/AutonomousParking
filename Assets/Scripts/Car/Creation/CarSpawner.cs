using System.Collections.Generic;
using AutomaticParking.Common.Extensions;
using AutomaticParking.ParkingLot.Data;
using UnityEngine;
using UnityEngine.Pool;

namespace AutomaticParking.Car.Creation
{
    public class CarSpawner : MonoBehaviour
    {
        [SerializeField] private CarPoolsInitializer carPoolsInitializer;
        [SerializeField] private CarTransformConfigurator carTransformConfigurator;
        private readonly Dictionary<Transform, IObjectPool<Transform>> cars = new();

        public Transform Spawn(Transform parkingSpot, ParkingSpotData parkingSpotData)
        {
            IObjectPool<Transform> randomCarPool = carPoolsInitializer.CarPools.RandomItem();
            Transform car = randomCarPool.Get();
            cars.Add(car, randomCarPool);
            carTransformConfigurator.Configure(car, parkingSpot, parkingSpotData);
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