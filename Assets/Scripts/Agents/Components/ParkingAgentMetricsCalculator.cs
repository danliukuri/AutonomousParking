using AutomaticParking.Agents.Data;
using AutomaticParking.Common.Extensions;
using UnityEngine;

namespace AutomaticParking.Agents.Components
{
    public class ParkingAgentMetricsCalculator
    {
        private readonly ParkingAgentData agentData;
        private readonly ParkingAgentTargetTrackingData data;
        private readonly ParkingAgentTargetData targetData;

        public ParkingAgentMetricsCalculator(ParkingAgentData agentData, ParkingAgentTargetData targetData,
            ParkingAgentTargetTrackingData data)
        {
            this.agentData = agentData;
            this.targetData = targetData;
            this.data = data;
        }

        public void CalculateInitialTargetTrackingMetrics()
        {
            data.MaxDistanceToTarget = data.DistanceToTarget = CalculateDistanceToTarget();
            data.NormalizedDistanceToTarget = CalculateNormalizedDistanceToTarget();
            data.MaxAngleToTarget = data.AngleToTarget = CalculateAngleToTarget();
            data.NormalizedAngleToTarget = CalculateNormalizedAngleToTarget();

            data.IsParked = CalculateWhetherAgentIsParked();
            data.IsGettingRewardForDecreasingAngleToTarget = CalculateWhetherToGetRewardForDecreasingAngleToTarget();
        }

        public void CalculateTargetTrackingMetrics()
        {
            data.DistanceToTarget = CalculateDistanceToTarget();
            data.NormalizedDistanceToTarget = CalculateNormalizedDistanceToTarget();
            data.AngleToTarget = CalculateAngleToTarget();
            data.NormalizedAngleToTarget = CalculateNormalizedAngleToTarget();

            data.IsParked = CalculateWhetherAgentIsParked();
            data.IsGettingRewardForDecreasingAngleToTarget = CalculateWhetherToGetRewardForDecreasingAngleToTarget();
        }

        private float CalculateDistanceToTarget() =>
            Vector3.Distance(agentData.Transform.position, targetData.Transform.position);

        private float CalculateNormalizedDistanceToTarget() =>
            data.DistanceToTarget.Normalize(data.MaxDistanceToTarget, data.MinDistanceToTarget);

        private float CalculateAngleToTarget() =>
            Quaternion.Angle(agentData.Transform.rotation, targetData.Transform.rotation);

        private float CalculateNormalizedAngleToTarget() =>
            data.AngleToTarget.Normalize(data.MaxAngleToTarget, data.MinAngleToTarget);

        private bool CalculateWhetherAgentIsParked() =>
            Mathf.Abs(data.DistanceToTarget) <= targetData.ParkingRadius &&
            Mathf.Abs(data.AngleToTarget) <= targetData.ParkingAngle;

        private bool CalculateWhetherToGetRewardForDecreasingAngleToTarget() =>
            Mathf.Abs(data.DistanceToTarget) <= data.MaxDistanceToTargetToGetRewardForDecreasingAngle;
    }
}