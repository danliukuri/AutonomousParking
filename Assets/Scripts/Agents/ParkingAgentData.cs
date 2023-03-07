using AutomaticParking.Car;
using UnityEngine;

namespace AutomaticParking.Agents
{
    public class ParkingAgentData
    {
        public Transform Target { get; set; }
        public Transform Transform { get; set; }
        public Rigidbody Rigidbody { get; set; }

        public CarData CarData { get; set; }

        public ParkingAgentActionsHandler ActionsHandler { get; set; }
        public ParkingAgentRewardCalculator RewardCalculator { get; set; }
        public ParkingAgentObservationsCollector ObservationsCollector { get; set; }

        public Vector3 InitialPosition { get; set; }
        public Quaternion InitialRotation { get; set; }

        public float PreviousDistanceToTarget { get; set; }
        public float PreviousAngleToTarget { get; set; }
        
        public void Reset()
        {
            Rigidbody.velocity = default;
            Transform.position = InitialPosition;
            Transform.rotation = InitialRotation;
        }
    }
}