using AutomaticParking.Extensions;
using UnityEngine;

namespace AutomaticParking.Agents
{
    public class ParkingAgentMetricsCalculator
    {
        private readonly ParkingAgentData agentData;
        private readonly ParkingAgentTargetTrackingData data;

        public ParkingAgentMetricsCalculator(ParkingAgentData agentData, ParkingAgentTargetTrackingData data)
        {
            this.agentData = agentData;
            this.data = data;
        }

        public void CalculateTargetTrackingMetrics()
        {
            data.PreviousDistanceToTarget = data.CurrentDistanceToTarget;
            data.CurrentDistanceToTarget = CalculateCurrentDistanceToTarget();
            data.PreviousAngleToTarget = data.CurrentAngleToTarget;
            data.CurrentAngleToTarget = CalculateCurrentAngleToTarget();

            data.DistancesDifference = CalculateDistancesDifference();
            data.AngleDifference = CalculateAngleDifference();
        }

        private float CalculateCurrentDistanceToTarget() =>
            Vector3.Distance(agentData.Transform.position, data.Transform.position);

        private float CalculateDistancesDifference() =>
            Mathf.Abs(data.PreviousDistanceToTarget - data.CurrentDistanceToTarget);

        private float CalculateCurrentAngleToTarget() =>
            Quaternion.Angle(agentData.Transform.rotation, data.Transform.rotation);

        private float CalculateAngleDifference() => Mathf.Abs(data.PreviousAngleToTarget - data.CurrentAngleToTarget);
    }
}