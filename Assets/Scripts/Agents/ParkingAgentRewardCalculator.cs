namespace AutomaticParking.Agents
{
    public class ParkingAgentRewardCalculator
    {
        private const float MaxRewardForDecreasingDistanceToTarget = 10f;
        private const float MaxRewardForDecreasingAngleToTarget = 10f;
        private readonly ParkingAgentTargetTrackingData data;

        public ParkingAgentRewardCalculator(ParkingAgentTargetTrackingData data) => this.data = data;

        public float CalculateReward()
        {
            float reward = default;
            reward += CalculateRewardForDecreasingDistanceToTarget();
            reward += CalculateRewardForDecreasingAngleToTarget();
            return reward;
        }

        private float CalculateRewardForDecreasingDistanceToTarget()
        {
            float reward = default;
            if (data.CurrentDistanceToTarget < data.PreviousDistanceToTarget)
                reward += data.DistancesDifferenceNormalized * MaxRewardForDecreasingDistanceToTarget;
            else
                reward -= data.DistancesDifferenceNormalized * MaxRewardForDecreasingDistanceToTarget;
            return reward;
        }

        private float CalculateRewardForDecreasingAngleToTarget()
        {
            float reward = default;
            if (data.CurrentAngleToTarget < data.PreviousAngleToTarget)
                reward += data.AngleDifferenceNormalized * MaxRewardForDecreasingAngleToTarget;
            else
                reward -= data.AngleDifferenceNormalized * MaxRewardForDecreasingAngleToTarget;
            return reward;
        }
    }
}