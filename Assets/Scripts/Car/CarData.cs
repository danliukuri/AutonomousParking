using AutomaticParking.Car.Wheel;
using UnityEngine;

namespace AutomaticParking.Car
{
    public class CarData : MonoBehaviour
    {
        [field: SerializeField] public float MaxEngineTorque { get; private set; } = 100f;
        [field: SerializeField] public float MaxBrakeTorque { get; private set; } = 1000f;
        [field: SerializeField, Range(0, 90)] public float MaxSteeringAngle { get; private set; } = 35f;
        [field: SerializeField, Range(0, 1)] public float DrivetrainEfficiency { get; private set; } = 0.75f;

        public float MaxWheelTorque { get; private set; }
        public float CurrentWheelTorque { get; set; }
        public float CurrentSteeringAngle { get; set; }
        public bool IsBreaking { get; set; }

        private void Awake()
        {
            var wheelsInfo = GetComponentInChildren<WheelsData>();
            int drivingWheelsCount = wheelsInfo.DrivingWheels.Length;

            MaxWheelTorque = MaxEngineTorque * DrivetrainEfficiency / drivingWheelsCount;
        }

        public void Reset()
        {
            CurrentWheelTorque = default;
            CurrentSteeringAngle = default;
            IsBreaking = default;
        }
    }
}