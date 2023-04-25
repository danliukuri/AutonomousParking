using AutomaticParking.Agents.Data;
using AutomaticParking.Common.Extensions;

namespace AutomaticParking.Agents.Components
{
    public class ParkingAgentRewardCalculator
    {
        private readonly ParkingAgentCollisionData agentCollisionData;
        private readonly ParkingAgentData agentData;
        private readonly ParkingAgentRewardData rewardData;
        private readonly ParkingAgentTargetTrackingData targetTrackingData;

        public ParkingAgentRewardCalculator(ParkingAgentCollisionData agentCollisionData, ParkingAgentData agentData,
            ParkingAgentRewardData rewardData, ParkingAgentTargetTrackingData targetTrackingData)
        {
            this.agentCollisionData = agentCollisionData;
            this.agentData = agentData;
            this.rewardData = rewardData;
            this.targetTrackingData = targetTrackingData;
        }

        public float CalculateReward()
        {
            float reward = CalculateRewardForInactivity();

            reward += CalculateRewardForDecreasingDistanceToTarget();
            if (targetTrackingData.IsGettingRewardForDecreasingAngleToTarget)
                reward += CalculateRewardForDecreasingAngleToTarget();

            if (agentCollisionData.IsAnyCollision)
                reward += rewardData.CollisionRewards[agentCollisionData.CollisionTag];

            if (targetTrackingData.IsParked)
            {
                reward += CalculateRewardForParking();
                if (targetTrackingData.IsPerfectlyParked)
                    reward += CalculateRewardForPerfectParking();
            }

            return reward;
        }

        private float CalculateRewardForInactivity() => rewardData.MaxRewardForInactivityPerStep / agentData.StepCount;

        private float CalculateRewardForDecreasingDistanceToTarget() =>
            targetTrackingData.NormalizedDistanceToTarget * rewardData.MaxRewardForDecreasingDistanceToTargetPerStep;

        private float CalculateRewardForDecreasingAngleToTarget() =>
            targetTrackingData.NormalizedAngleToTarget * rewardData.MaxRewardForDecreasingAngleToTargetPerStep;

        private float CalculateRewardForParking() => agentData.StepCount
            .ChangeBounds(agentData.MaxStepToStartParking, agentData.MinStepToStartParking,
                rewardData.MinRewardForParkingPerStep, rewardData.MaxRewardForParkingPerStep);

        private float CalculateRewardForPerfectParking() => agentData.StepCount
            .ChangeBounds(agentData.MaxStepToStartParking, agentData.MinStepToStartParking,
                rewardData.MinRewardForPerfectParking, rewardData.MaxRewardForPerfectParking);
    }
}