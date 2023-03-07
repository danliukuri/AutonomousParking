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

        public ParkingAgentTargetTrackingData InitializeTargetTrackingData(ParkingAgentData data) => new()
        {
            Transform = target,
            InitialDistanceToTarget = Vector3.Distance(data.InitialPosition, target.position),
            InitialAngleToTarget = Quaternion.Angle(data.InitialRotation, target.rotation)
        };

        public void InitializeAgentDataComponents(ParkingAgentData data)
        {
            data.ObservationsCollector = new ParkingAgentObservationsCollector(data);
            data.ActionsHandler = new ParkingAgentActionsHandler(data.CarData);
            data.RewardCalculator = new ParkingAgentRewardCalculator(data, data.TargetTrackingData);
        }
    }
}