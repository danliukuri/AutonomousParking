using AutomaticParking.Agents.Data;
using AutomaticParking.Common.Extensions;
using UnityEngine;
using static AutomaticParking.Agents.Data.ParkingAgentRewardData;

namespace AutomaticParking.Agents.Components
{
    public class ParkingAgentRewardCalculator
    {
        private readonly ParkingAgentCollisionData agentCollisionData;
        private readonly ParkingAgentData agentData;
        private readonly ParkingAgentTargetTrackingData targetTrackingData;

        public ParkingAgentRewardCalculator(ParkingAgentData agentData,
            ParkingAgentTargetTrackingData targetTrackingData, ParkingAgentCollisionData agentCollisionData)
        {
            this.agentCollisionData = agentCollisionData;
            this.agentData = agentData;
            this.targetTrackingData = targetTrackingData;
        }

        public float CalculateReward()
        {
            float reward = CalculateRewardForInactivity();
            reward += CalculateRewardForDecreasingDistanceToTarget(targetTrackingData);
            if (targetTrackingData.IsGettingRewardForDecreasingAngleToTarget)
                reward += CalculateRewardForDecreasingAngleToTarget(targetTrackingData);
            if (agentCollisionData.IsAnyCollision)
                reward += CollisionRewards[agentCollisionData.CollisionTag];
            if (targetTrackingData.IsParked)
            {
                reward += CalculateRewardForParking();
                if (targetTrackingData.IsPerfectlyParked)
                    reward += CalculateRewardForPerfectParking();
            }
            return reward;
        }

        private float CalculateRewardForInactivity() => MaxRewardForInactivityPerStep / agentData.StepCount;

        private float CalculateRewardForDecreasingDistanceToTarget(ParkingAgentTargetTrackingData data) =>
            data.NormalizedDistanceToTarget * MaxRewardForDecreasingDistanceToTargetPerStep;

        private float CalculateRewardForDecreasingAngleToTarget(ParkingAgentTargetTrackingData data) =>
            data.NormalizedAngleToTarget * MaxRewardForDecreasingAngleToTargetPerStep;

        private float CalculateRewardForParking() => agentData.StepCount
            .ChangeBounds(agentData.MaxStepToStartParking, agentData.MinStepToStartParking,
                MinRewardForParkingPerStep, MaxRewardForParkingPerStep);

        private float CalculateRewardForPerfectParking() => agentData.StepCount
            .ChangeBounds(agentData.MaxStepToStartParking, agentData.MinStepToStartParking,
                MinRewardForPerfectParking, MaxRewardForPerfectParking);
    }
}