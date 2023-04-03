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

        public void Initialize()
        {
            PlaceTarget(parkingLotData.CurrentlyAvailableParkingSpots.RandomItem());

            void PlaceTarget(Transform parkingSpot)
            {
                TargetData.Transform.position = parkingSpot.position;
                TargetData.Transform.rotation = parkingSpot.rotation;
            }
        }
    }
}