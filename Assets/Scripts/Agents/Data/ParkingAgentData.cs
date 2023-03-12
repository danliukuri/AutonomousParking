using AutomaticParking.Agents.Components;
using AutomaticParking.Car;
using UnityEngine;

namespace AutomaticParking.Agents.Data
{
    public class ParkingAgentData
    {
        public Rigidbody Rigidbody { get; set; }
        public Transform Transform { get; set; }
        public Vector3 InitialPosition { get; set; }
        public Quaternion InitialRotation { get; set; }

        public CarData CarData { get; set; }
        public ParkingAgentTargetData TargetData { get; set; }
        public ParkingAgentTargetTrackingData TargetTrackingData { get; set; }

        public ParkingAgentActionsHandler ActionsHandler { get; set; }
        public ParkingAgentMetricsCalculator MetricsCalculator { get; set; }
        public ParkingAgentRewardCalculator RewardCalculator { get; set; }
        public ParkingAgentObservationsCollector ObservationsCollector { get; set; }
        
        public void Reset()
        {
            Rigidbody.velocity = default;
            Transform.position = InitialPosition;
            Transform.rotation = InitialRotation;
        }
    }
}