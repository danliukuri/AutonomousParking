using System.Collections.Generic;
using AutomaticParking.Car.Creation;
using AutomaticParking.Common.Extensions;
using AutomaticParking.ParkingLot.Data;
using UnityEngine;

namespace AutomaticParking.ParkingLot
{
    public class ParkingLotInitializer : MonoBehaviour
    {
        [SerializeField] private CarSpawner carSpawner;
        [SerializeField] private ParkingLotData parkingLotData;

        public void Initialize()
        {
            List<Transform> parkingSpotsToOccupy = PickRandomParkingSpotsToOccupy();
            parkingSpotsToOccupy.ForEach(parkingSpot => carSpawner.Spawn(parkingSpot, parkingLotData.ParkingSpotData));

            List<Transform> PickRandomParkingSpotsToOccupy()
            {
                List<Transform> availableParkingSpots = parkingLotData.AvailableParkingSpots;
                int occupiedParkingSpotsCount = availableParkingSpots.Count - parkingLotData.FreeParkingSpotsCount;
                return availableParkingSpots.PickRandomItems(occupiedParkingSpotsCount);
            }
        }

        public void ReInitialize()
        {
            DeInitialize();
            Initialize();
        }

        public void DeInitialize() => carSpawner.DeSpawnAll();
    }
}