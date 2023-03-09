using AutomaticParking.Agents.Data;
using static AutomaticParking.Agents.Data.ParkingAgentRewardData;

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
            float possibleReward = data.DistancesDifferenceNormalized * MaxRewardForDecreasingDistanceToTarget;
            return data.CurrentDistanceToTarget < data.PreviousDistanceToTarget ? possibleReward : -possibleReward;
        }

        private float CalculateRewardForDecreasingAngleToTarget()
        {
            float possibleReward =  data.AngleDifferenceNormalized * MaxRewardForDecreasingAngleToTarget;
            return data.CurrentAngleToTarget < data.PreviousAngleToTarget ? possibleReward : -possibleReward;
        }
    }
}