using UnityEngine;

namespace AutomaticParking.Car.Wheel
{
    public class WheelData : MonoBehaviour
    {
        [field: SerializeField] public Transform Transform { get; private set; }
        [field: SerializeField] public WheelCollider Collider { get; private set; }
    }
}