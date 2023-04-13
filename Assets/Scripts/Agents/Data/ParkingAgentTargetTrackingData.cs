﻿namespace AutomaticParking.Agents.Data
{
    public class ParkingAgentTargetTrackingData
    {
        public bool IsGettingRewardForDecreasingAngleToTarget { get; set; }

        public float DistanceToTarget { get; set; }
        public float NormalizedDistanceToTarget { get; set; }
        public float MinDistanceToTarget { get; set; }
        public float MaxDistanceToTarget { get; set; }

        public float MaxDistanceToTargetToGetRewardForDecreasingAngle => 8f;

        public float AngleToTarget { get; set; }
        public float NormalizedAngleToTarget { get; set; }
        public float MinAngleToTarget { get; set; }
        public float MaxAngleToTarget { get; set; }
    }
}