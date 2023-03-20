namespace AutomaticParking.Agents.Data
{
    public class ParkingAgentTargetTrackingData
    {
        public bool IsTargetReached { get; set; }
        public bool IsGettingRewardForDecreasingAngleToTarget { get; set; }

        public float InitialDistanceToTarget { get; set; }
        public float DistanceToTarget { get; set; }
        public float NormalizedDistanceToTarget { get; set; }
        public float MinDistanceToTarget { get; set; }
        public float MaxDistanceToTarget { get; set; }

        public float MaxDistanceToTargetToGetRewardForDecreasingAngle => 8f;

        public float InitialAngleToTarget { get; set; }
        public float AngleToTarget { get; set; }
        public float NormalizedAngleToTarget { get; set; }
        public float MinAngleToTarget { get; set; }
        public float MaxAngleToTarget { get; set; }

        public void Reset()
        {
            DistanceToTarget = InitialDistanceToTarget;
            AngleToTarget = InitialAngleToTarget;
            IsTargetReached = default;
            IsGettingRewardForDecreasingAngleToTarget = default;
        }
    }
}