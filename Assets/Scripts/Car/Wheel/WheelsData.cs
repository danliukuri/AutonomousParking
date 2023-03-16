using UnityEngine;

namespace AutomaticParking.Car.Wheel
{
    public class WheelsData : MonoBehaviour
    {
        [field: SerializeField] public WheelData[] DrivingWheels { get; private set; }
        [field: SerializeField] public WheelData[] SteeringWheels { get; private set; }
        [field: SerializeField] public WheelData[] BrakingWheels { get; private set; }
        public WheelData[] AllWheels { get; private set; } 

        private void Awake() => AllWheels = GetComponentsInChildren<WheelData>();

        public void Reset()
        {
            foreach (WheelData wheel in AllWheels)
                wheel.Reset();
        }
    }
}