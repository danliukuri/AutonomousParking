using UnityEngine;

namespace AutonomousParking.ParkingLot.Data
{
    public class ParkingSpotData : MonoBehaviour
    {
        [field: SerializeField] public float MaxParkingOffset { get; private set; }
        [field: SerializeField] public float MaxParkingAngleOffset { get; private set; }
    }
}