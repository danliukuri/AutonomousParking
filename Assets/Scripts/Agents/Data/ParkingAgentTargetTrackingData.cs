using System;
using UnityEngine;

namespace AutonomousParking.Agents.Data
{
    [Serializable]
    public class ParkingAgentTargetTrackingData
    {
        [field: SerializeField] public float MaxDistanceToTargetToGetRewardForDecreasingAngle { get; set; }

        public bool IsParked { get; set; }
        public bool IsPerfectlyParked { get; set; }

        public bool IsGettingRewardForDecreasingAngleToTarget { get; set; }

        public float DistanceToTarget { get; set; }
        public float NormalizedDistanceToTarget { get; set; }
        public float MinDistanceToTarget { get; set; }
        public float MaxDistanceToTarget { get; set; }

        public float AngleToTarget { get; set; }
        public float NormalizedAngleToTarget { get; set; }
        public float MinAngleToTarget { get; set; }
        public float MaxAngleToTarget { get; set; }
    }
}