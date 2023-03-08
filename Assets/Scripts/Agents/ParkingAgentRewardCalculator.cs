namespace AutomaticParking.Agents
{
    public class ParkingAgentRewardCalculator
    {
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
                reward += data.DistancesDifference;
            else
                reward -= data.DistancesDifference;
            return reward;
        }

        private float CalculateRewardForDecreasingAngleToTarget()
        {
            float reward = default;
            if (data.CurrentAngleToTarget < data.PreviousAngleToTarget)
                reward += data.AngleDifference;
            else
                reward -= data.AngleDifference;
            return reward;
        }
    }
}