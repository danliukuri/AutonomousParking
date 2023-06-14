using System.Collections.Generic;
using UnityEngine;

namespace AutonomousParking.ParkingLot.Data
{
    public class ParkingLotData : MonoBehaviour
    {
        [field: SerializeField, Min(default)] public int FreeParkingSpotsCount { get; private set; }
        [field: SerializeField] public ParkingSpotData ParkingSpotData { get; private set; }
        [field: SerializeField] public List<Transform> AvailableParkingSpots { get; private set; }
        public List<Transform> CurrentlyAvailableParkingSpots { get; private set; }

        private void Awake() => CurrentlyAvailableParkingSpots = new List<Transform>(AvailableParkingSpots);

        public void Reset()
        {
            CurrentlyAvailableParkingSpots.Clear();
            CurrentlyAvailableParkingSpots.AddRange(AvailableParkingSpots);
        }
    }
}