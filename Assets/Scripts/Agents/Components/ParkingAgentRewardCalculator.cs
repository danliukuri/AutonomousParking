using AutomaticParking.Agents.Data;
using AutomaticParking.Common.Extensions;
using static AutomaticParking.Agents.Data.ParkingAgentRewardData;

namespace AutomaticParking.Agents.Components
{
    public class ParkingAgentRewardCalculator
    {
        private readonly ParkingAgentData agentData;
        private readonly ParkingAgentTargetTrackingData targetTrackingData;

        public ParkingAgentRewardCalculator(ParkingAgentData agentData,
            ParkingAgentTargetTrackingData targetTrackingData)
        {
            this.agentData = agentData;
            this.targetTrackingData = targetTrackingData;
        }

        public float CalculateReward()
        {
            float reward = CalculateRewardForInactivity();
            reward += CalculateRewardForDecreasingDistanceToTarget(targetTrackingData);
            if (targetTrackingData.IsGettingRewardForDecreasingAngleToTarget)
                reward += CalculateRewardForDecreasingAngleToTarget(targetTrackingData);
            if (targetTrackingData.IsTargetReached)
                reward += CalculateRewardForTargetReach(agentData);
            return reward;
        }

        private float CalculateRewardForInactivity() => MaxRewardForInactivityPerStep / agentData.StepCount;

        private float CalculateRewardForDecreasingDistanceToTarget(ParkingAgentTargetTrackingData data) =>
            data.NormalizedDistanceToTarget * MaxRewardForDecreasingDistanceToTargetPerStep;

        private float CalculateRewardForDecreasingAngleToTarget(ParkingAgentTargetTrackingData data) =>
            data.NormalizedAngleToTarget * MaxRewardForDecreasingAngleToTargetPerStep;

        private float CalculateRewardForTargetReach(ParkingAgentData data) =>
            data.StepCount.ChangeBounds(data.MaxStepToReachTarget, data.MinStepToReachTarget,
                MinRewardForTargetReach, MaxRewardForTargetReach);
    }
}