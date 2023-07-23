using AutonomousParking.Car.Wheel;
using UnityEngine;

namespace AutonomousParking.Car
{
    [RequireComponent(typeof(CarData)), RequireComponent(typeof(WheelsOperator))]
    public class CarEngine : MonoBehaviour
    {
        private CarData carData;
        private WheelsOperator wheelsOperator;

        private void Awake()
        {
            carData = GetComponent<CarData>();
            wheelsOperator = GetComponent<WheelsOperator>();
        }

        private void FixedUpdate()
        {
            wheelsOperator.ApplyWheelTorque(carData.CurrentWheelTorque / Time.fixedDeltaTime);
            wheelsOperator.ApplyBreaking(carData.IsBreaking ? carData.MaxBrakeTorque : default);
            wheelsOperator.ApplySteering(carData.CurrentSteeringAngle);
            wheelsOperator.SynchronizeWheelsVisualization();
        }
    }
}