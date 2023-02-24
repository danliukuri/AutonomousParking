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
            reward += CalculateRewardForDecreasingAngleToTarget();
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

        private float CalculateRewardForDecreasingAngleToTarget()
        {
            float reward = default;

            float currentAngleToTarget = Quaternion.Angle(data.Transform.rotation, data.Target.rotation);
            float angleDifference = Mathf.Abs(data.PreviousAngleToTarget - currentAngleToTarget);

            if (currentAngleToTarget < data.PreviousAngleToTarget)
                reward += angleDifference;
            else
                reward -= angleDifference;

            data.PreviousAngleToTarget = currentAngleToTarget;
            return reward;
        }
    }
}