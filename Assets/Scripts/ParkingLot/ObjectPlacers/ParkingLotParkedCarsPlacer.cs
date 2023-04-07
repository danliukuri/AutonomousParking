using System.Collections.Generic;
using AutomaticParking.Car.Creation;
using AutomaticParking.Common.Extensions;
using AutomaticParking.ParkingLot.Data;
using UnityEngine;

namespace AutomaticParking.ParkingLot.ObjectPlacers
{
    public class ParkingLotParkedCarsPlacer : MonoBehaviour
    {
        [SerializeField] private CarSpawner carSpawner;
        [SerializeField] private ParkingLotData parkingLotData;

        public void Place()
        {
            List<Transform> parkingSpotsToOccupy = PickRandomParkingSpotsToOccupy();
            parkingSpotsToOccupy.ForEach(parkingSpot => carSpawner.Spawn(parkingSpot, parkingLotData.ParkingSpotData));

            List<Transform> PickRandomParkingSpotsToOccupy()
            {
                List<Transform> availableParkingSpots = parkingLotData.CurrentlyAvailableParkingSpots;
                int occupiedParkingSpotsCount = availableParkingSpots.Count - parkingLotData.FreeParkingSpotsCount;
                return availableParkingSpots.ExtractRandomItems(occupiedParkingSpotsCount);
            }
        }

        public void Remove()
        {
            carSpawner.DeSpawnAll();
            parkingLotData.Reset();
        }
    }
}