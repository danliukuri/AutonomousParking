using AutomaticParking.Agents.Data;
using AutomaticParking.Car;
using UnityEngine;

namespace AutomaticParking.Agents.Components
{
    public class ParkingAgentInitializer : MonoBehaviour
    {
        [SerializeField] public ParkingAgentTargetData targetData;

        public CarData InitializeCarData() => GetComponentInChildren<CarData>();

        public ParkingAgentData InitializeAgentData(ParkingAgent agent)
        {
            var agentRigidbody = GetComponent<Rigidbody>();
            var agentTransform = GetComponent<Transform>();
            return new ParkingAgentData(agent)
            {
                Rigidbody = agentRigidbody,
                Transform = agentTransform,
                InitialPosition = agentTransform.position,
                InitialRotation = agentTransform.rotation
            };
        }

        public ParkingAgentTargetData InitializeTargetData() => targetData;

        public ParkingAgentTargetTrackingData InitializeTargetTrackingData(ParkingAgentData data)
        {
            float initialDistanceToTarget = Vector3.Distance(data.InitialPosition, targetData.Transform.position);
            float initialAngleToTarget = Quaternion.Angle(data.InitialRotation, targetData.Transform.rotation);
            return new ParkingAgentTargetTrackingData
            {
                InitialDistanceToTarget = initialDistanceToTarget,
                MinDistanceToTarget = default,
                MaxDistanceToTarget = initialDistanceToTarget,
                InitialAngleToTarget = initialAngleToTarget,
                MinAngleToTarget = default,
                MaxAngleToTarget = initialAngleToTarget
            };
        }
    }
}