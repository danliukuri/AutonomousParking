namespace AutomaticParking.Agents.Data
{
    public class ParkingAgentTargetTrackingData
    {
        public bool IsTargetReached { get; set; }

        public float InitialDistanceToTarget { get; set; }
        public float PreviousDistanceToTarget { get; set; }
        public float CurrentDistanceToTarget { get; set; }
        public float MinDistanceToTarget { get; set; }
        public float MaxDistanceToTarget { get; set; }

        public float InitialAngleToTarget { get; set; }
        public float PreviousAngleToTarget { get; set; }
        public float CurrentAngleToTarget { get; set; }
        public float MinAngleToTarget { get; set; }
        public float MaxAngleToTarget { get; set; }

        public float DistancesDifference { get; set; }
        public float DistancesDifferenceNormalized { get; set; }
        public float AngleDifference { get; set; }
        public float AngleDifferenceNormalized { get; set; }

        public void Reset()
        {
            CurrentDistanceToTarget = PreviousDistanceToTarget = InitialDistanceToTarget;
            CurrentAngleToTarget = PreviousAngleToTarget = InitialAngleToTarget;
            IsTargetReached = default;
        }
    }
}