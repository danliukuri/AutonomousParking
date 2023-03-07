using UnityEngine;

namespace AutomaticParking.Agents
{
    public class ParkingAgentRewardCalculator
    {
        private readonly ParkingAgentData agentData;
        private readonly ParkingAgentTargetTrackingData data;

        public ParkingAgentRewardCalculator(ParkingAgentData agentData, ParkingAgentTargetTrackingData data)
        {
            this.agentData = agentData;
            this.data = data;
        }

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

            data.PreviousDistanceToTarget = data.CurrentDistanceToTarget;
            data.CurrentDistanceToTarget =
                Vector3.Distance(agentData.Transform.position, data.Transform.position);
            data.DistancesDifference = Mathf.Abs(data.PreviousDistanceToTarget - data.CurrentDistanceToTarget);

            if (data.CurrentDistanceToTarget < data.PreviousDistanceToTarget)
                reward += data.DistancesDifference;
            else
                reward -= data.DistancesDifference;

            return reward;
        }

        private float CalculateRewardForDecreasingAngleToTarget()
        {
            float reward = default;

            data.PreviousAngleToTarget = data.CurrentAngleToTarget;
            data.CurrentAngleToTarget = Quaternion.Angle(agentData.Transform.rotation, data.Transform.rotation);
            data.AngleDifference = Mathf.Abs(data.PreviousAngleToTarget - data.CurrentAngleToTarget);

            if (data.CurrentAngleToTarget < data.PreviousAngleToTarget)
                reward += data.AngleDifference;
            else
                reward -= data.AngleDifference;

            return reward;
        }
    }
}