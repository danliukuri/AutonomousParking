using UnityEngine;

namespace AutomaticParking.Agents
{
    public class ParkingAgentRewardCalculator
    {
        private readonly ParkingAgentData data;

        public ParkingAgentRewardCalculator(ParkingAgentData data) => this.data = data;

        public float CalculateReward()
        {
            float reward = default;
            reward += CalculateRewardForDecreasingDistanceToTarget();
            return reward;
        }

        private float CalculateRewardForDecreasingDistanceToTarget()
        {
            float reward = default;

            float currentDistanceToTarget = Vector3.Distance(data.Transform.position, data.Target.position);
            float distancesDifference = Mathf.Abs(data.PreviousDistanceToTarget - currentDistanceToTarget);

            if (currentDistanceToTarget < data.PreviousDistanceToTarget)
                reward += distancesDifference;
            else
                reward -= distancesDifference;

            data.PreviousDistanceToTarget = currentDistanceToTarget;
            return reward;
        }
    }
}