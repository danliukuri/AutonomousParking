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
            PlaceCars(PickRandomParkingSpotsToOccupy());

            List<Transform> PickRandomParkingSpotsToOccupy()
            {
                List<Transform> availableParkingSpots = parkingLotData.CurrentlyAvailableParkingSpots;
                int occupiedParkingSpotsCount = availableParkingSpots.Count - parkingLotData.FreeParkingSpotsCount;
                return availableParkingSpots.ExtractRandomItems(occupiedParkingSpotsCount);
            }

            void PlaceCars(List<Transform> parkingSpots) =>
                parkingSpots.ForEach(parkingSpot => carSpawner.Spawn(parkingSpot, parkingLotData.ParkingSpotData));
        }

        public void ReInitialize()
        {
            DeInitialize();
            Initialize();
        }

        public void DeInitialize()
        {
            carSpawner.DeSpawnAll();
            parkingLotData.Reset();
        }
    }
}