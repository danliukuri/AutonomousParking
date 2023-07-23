using AutonomousParking.Car.Wheel;
using UnityEngine;

namespace AutonomousParking.Car
{
    public class CarData : MonoBehaviour
    {
        private WheelsData wheelsData;
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
            wheelsData = GetComponentInChildren<WheelsData>();
            int drivingWheelsCount = wheelsData.DrivingWheels.Length;

            MaxWheelTorque = MaxEngineTorque * DrivetrainEfficiency / drivingWheelsCount;
        }

        public void Reset()
        {
            CurrentWheelTorque = default;
            CurrentSteeringAngle = default;
            IsBreaking = default;
            wheelsData.Reset();
        }
    }
}