using System.Collections.Generic;
using AutomaticParking.Agents.Data;
using AutomaticParking.Common.Extensions;
using AutomaticParking.ParkingLot.Data;
using UnityEngine;

namespace AutomaticParking.Agents.Target
{
    public class ParkingAgentTargetInitializer : MonoBehaviour
    {
        [field: SerializeField] public ParkingAgentTargetData TargetData { get; private set; }
        [SerializeField] private ParkingLotData parkingLotData;

        public void Initialize(Transform agent)
        {
            PlaceTarget(FindClosestParkingSpot(parkingLotData.CurrentlyAvailableParkingSpots));

            Transform FindClosestParkingSpot(IEnumerable<Transform> availableParkingSpots) =>
                availableParkingSpots.MinBy(parkingSpot => Vector3.Distance(agent.position, parkingSpot.position));

            void PlaceTarget(Transform parkingSpot)
            {
                TargetData.Transform.position = parkingSpot.position;
                TargetData.Transform.rotation = parkingSpot.rotation;
            }
        }

        public void ReInitialize(Transform agent) => Initialize(agent);
    }
}