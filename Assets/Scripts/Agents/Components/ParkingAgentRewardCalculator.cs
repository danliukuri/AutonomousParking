using AutomaticParking.Agents.Data;
using static AutomaticParking.Agents.Data.ParkingAgentRewardData;

namespace AutomaticParking.Agents.Components
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
            if (data.IsTargetReached)
                reward += RewardForTargetReach;
            return reward;
        }

        private float CalculateRewardForDecreasingDistanceToTarget() =>
            data.NormalizedDistanceToTarget * MaxRewardForDecreasingDistanceToTargetPerStep;

        private float CalculateRewardForDecreasingAngleToTarget() =>
            data.NormalizedAngleToTarget * MaxRewardForDecreasingAngleToTargetPerStep;
    }
}