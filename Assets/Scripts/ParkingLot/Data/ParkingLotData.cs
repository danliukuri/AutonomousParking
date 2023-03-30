using System.Collections.Generic;
using UnityEngine;

namespace AutomaticParking.ParkingLot.Data
{
    public class ParkingLotData : MonoBehaviour
    {
        [field: SerializeField, Min(default)] public int FreeParkingSpotsCount { get; private set; }
        [field: SerializeField] public ParkingSpotData ParkingSpotData { get; private set; }
        [field: SerializeField] public List<Transform> AvailableParkingSpots { get; private set; }
    }
}