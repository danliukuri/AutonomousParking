using UnityEngine;

namespace AutomaticParking.Car.Wheel
{
    public class WheelData : MonoBehaviour
    {
        [field: SerializeField] public Transform Transform { get; private set; }
        [field: SerializeField] public WheelCollider Collider { get; private set; }

        public void Reset()
        {
            Collider.motorTorque = default;
            Collider.brakeTorque = default;
            Collider.steerAngle = default;
            Collider.rotationSpeed = default;
        }
    }
}