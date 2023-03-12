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

        public void CalculateTargetTrackingMetrics()
        {
            data.DistanceToTarget = CalculateDistanceToTarget();
            data.NormalizedDistanceToTarget = CalculateNormalizedDistanceToTarget();

            data.PreviousAngleToTarget = data.CurrentAngleToTarget;
            data.CurrentAngleToTarget = CalculateCurrentAngleToTarget();
            data.AngleDifference = CalculateAngleDifference();
            data.AngleDifferenceNormalized = CalculateAngleDifferenceNormalized();

            data.IsTargetReached = CalculateWhetherTargetHasBeenReached();
        }

        private float CalculateDistanceToTarget() =>
            Vector3.Distance(agentData.Transform.position, targetData.Transform.position);

        private float CalculateNormalizedDistanceToTarget() =>
            data.DistanceToTarget.Normalize(data.MaxDistanceToTarget, data.MinDistanceToTarget);
        
        private float CalculateCurrentAngleToTarget() =>
            Quaternion.Angle(agentData.Transform.rotation, targetData.Transform.rotation);

        private float CalculateAngleDifference() => Mathf.Abs(data.PreviousAngleToTarget - data.CurrentAngleToTarget);

        private float CalculateAngleDifferenceNormalized() =>
            CalculateAngleDifference().Normalize(data.MinAngleToTarget, data.MaxAngleToTarget);

        private bool CalculateWhetherTargetHasBeenReached() =>
            Mathf.Abs(data.DistanceToTarget) < targetData.ReachRadius &&
            Mathf.Abs(data.CurrentAngleToTarget) < targetData.ReachAngle;
    }
}