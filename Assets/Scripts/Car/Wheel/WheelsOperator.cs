using UnityEngine;

namespace AutonomousParking.Car.Wheel
{
    public class WheelsOperator : MonoBehaviour
    {
        private WheelsData wheelsData;

        private void Awake() => wheelsData = GetComponentInChildren<WheelsData>();

        public void ApplyWheelTorque(float wheelTorque)
        {
            foreach (WheelData wheel in wheelsData.DrivingWheels)
                wheel.Collider.motorTorque = wheelTorque;
        }

        public void ApplyBreaking(float colliderBrakeTorque)
        {
            foreach (WheelData wheel in wheelsData.BrakingWheels)
                wheel.Collider.brakeTorque = colliderBrakeTorque;
        }

        public void ApplySteering(float steeringAngle)
        {
            foreach (WheelData wheel in wheelsData.SteeringWheels)
                wheel.Collider.steerAngle = steeringAngle;
        }

        public void SynchronizeWheelsVisualization()
        {
            foreach (WheelData wheel in wheelsData.AllWheels)
                SynchronizePoseWithCollider(wheel);

            void SynchronizePoseWithCollider(WheelData wheel)
            {
                wheel.Collider.GetWorldPose(out Vector3 position, out Quaternion rotation);
                wheel.Transform.rotation = rotation;
                wheel.Transform.position = position;
            }
        }
    }
}