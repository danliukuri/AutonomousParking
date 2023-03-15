namespace AutomaticParking.Agents.Data
{
    public class ParkingAgentRewardData
    {
        public const float MaxRewardForDecreasingDistanceToTargetPerStep = 1f;
        public const float MaxRewardForDecreasingAngleToTargetPerStep = 1f;

        public const float MinRewardForTargetReach = 80f;
        public const float MaxRewardForTargetReach = 100f;

        public const float RewardForWallCollisionEnter = -5f;
        public const float RewardForCarCollisionEnter = -10f;
    }
}