using System;
using AutomaticParking.Agents.Data;
using AutomaticParking.Common.Enumerations;
using Unity.MLAgents;
using static AutomaticParking.Agents.Data.ParkingAgentRecordKey;

namespace AutomaticParking.Agents.Components
{
    public class ParkingAgentStatsRecorder
    {
        private readonly ParkingAgentCollisionData agentCollisionData;
        private readonly ParkingAgentTargetTrackingData targetTrackingData;

        public ParkingAgentStatsRecorder(ParkingAgentCollisionData agentCollisionData,
            ParkingAgentTargetTrackingData targetTrackingData)
        {
            this.agentCollisionData = agentCollisionData;
            this.targetTrackingData = targetTrackingData;
        }

        public void RecordStats()
        {
            Record(TargetReach, targetTrackingData.IsTargetReached);

            Record(DistanceToTarget, targetTrackingData.DistanceToTarget);
            Record(AngleToTarget, targetTrackingData.AngleToTarget);

            foreach (Tag tag in Tag.List)
                Record(Header.Collision + tag, agentCollisionData.CollisionTag == tag);
        }

        private void Record(string key, float value, StatAggregationMethod aggregationMethod = default) =>
            Academy.Instance.StatsRecorder.Add(key, value, aggregationMethod);

        private void Record(string key, bool value = true, StatAggregationMethod aggregationMethod = default) =>
            Record(key, Convert.ToSingle(value), aggregationMethod);
    }
}