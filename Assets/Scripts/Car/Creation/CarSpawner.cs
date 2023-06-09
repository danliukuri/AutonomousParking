using System.Collections.Generic;
using System.Linq;
using AutomaticParking.Demonstration.Architecture;
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

        private void Awake()
        {
            ServiceLocator.Instance.Register(this);
            carPoolsInitializer ??= ServiceLocator.Instance.Get<CarPoolsInitializer>().First();
        }

        public Transform Spawn(Transform parkingSpot, ParkingSpotData parkingSpotData) =>
            Spawn(carPoolsInitializer.NextRandomCarPoolProvider.Get(), parkingSpot, parkingSpotData);

        private Transform Spawn(IObjectPool<Transform> carPool, Transform parkingSpot, ParkingSpotData parkingSpotData)
        {
            Transform car = carPool.Get();
            cars.Add(car, carPool);
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