using System.Collections.Generic;
using AutonomousParking.Common.Extensions;
using AutonomousParking.ParkingLot.Data;
using UnityEngine;

namespace AutonomousParking.ParkingLot.ObjectPlacers
{
    public class ParkingLotAgentTargetPlacer : MonoBehaviour
    {
        [SerializeField] private ParkingLotData parkingLotData;

        public void Place(Transform target, Transform agent)
        {
            Transform closestParkingSpot = FindClosestParkingSpot(parkingLotData.CurrentlyAvailableParkingSpots);
            target.position = closestParkingSpot.position;
            target.rotation = closestParkingSpot.rotation;

            Transform FindClosestParkingSpot(IEnumerable<Transform> availableParkingSpots) =>
                availableParkingSpots.MinBy(parkingSpot => Vector3.Distance(agent.position, parkingSpot.position));
        }
    }
}