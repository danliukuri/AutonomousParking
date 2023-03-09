using AutomaticParking.Agents.Data;
using AutomaticParking.Car;
using UnityEngine;

namespace AutomaticParking.Agents
{
    public class ParkingAgentInitializer : MonoBehaviour
    {
        [SerializeField] public Transform target;

        public ParkingAgentData InitializeAgentData()
        {
            var agentRigidbody = GetComponent<Rigidbody>();
            var agentTransform = GetComponent<Transform>();
            return new ParkingAgentData
            {
                Rigidbody = agentRigidbody,
                Transform = agentTransform,
                InitialPosition = agentTransform.position,
                InitialRotation = agentTransform.rotation
            };
        }

        public CarData InitializeCarData() => GetComponentInChildren<CarData>();

        public ParkingAgentTargetTrackingData InitializeTargetTrackingData(ParkingAgentData data)
        {
            float initialDistanceToTarget = Vector3.Distance(data.InitialPosition, target.position);
            float initialAngleToTarget = Quaternion.Angle(data.InitialRotation, target.rotation);
            return new ParkingAgentTargetTrackingData
            {
                Transform = target,
                InitialDistanceToTarget = initialDistanceToTarget,
                MinDistanceToTarget = default,
                MaxDistanceToTarget = initialDistanceToTarget,
                InitialAngleToTarget = initialAngleToTarget,
                MinAngleToTarget = default,
                MaxAngleToTarget = initialAngleToTarget
            };
        }

        public void InitializeAgentDataComponents(ParkingAgentData data)
        {
            data.ActionsHandler = new ParkingAgentActionsHandler(data.CarData);
            data.MetricsCalculator = new ParkingAgentMetricsCalculator(data, data.TargetTrackingData);
            data.RewardCalculator = new ParkingAgentRewardCalculator(data.TargetTrackingData);
            data.ObservationsCollector = new ParkingAgentObservationsCollector(data);
        }
    }
}