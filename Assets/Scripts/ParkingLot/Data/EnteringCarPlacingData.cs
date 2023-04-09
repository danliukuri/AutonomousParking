using UnityEngine;

namespace AutomaticParking.ParkingLot.Data
{
    public class EnteringCarPlacingData : MonoBehaviour
    {
        [field: SerializeField] public float MinPositionX { get; private set; }
        [field: SerializeField] public float MaxPositionX { get; private set; }
        [field: SerializeField] public float MinPositionZ { get; private set; }
        [field: SerializeField] public float MaxPositionZ { get; private set; }
        [field: SerializeField] public float MinRotationAngle { get; private set; }
        [field: SerializeField] public float MaxRotationAngle { get; private set; }
        [field: SerializeField] public float RotationAngleOffsetOnMinPositionX { get; private set; }
        [field: SerializeField] public float RotationAngleOffsetOnMaxPositionX { get; private set; }
    }
}