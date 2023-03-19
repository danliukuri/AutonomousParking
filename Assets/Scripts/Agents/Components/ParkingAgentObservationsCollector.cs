using AutomaticParking.Agents.Data;
using Unity.MLAgents.Sensors;
using UnityEngine;

namespace AutomaticParking.Agents.Components
{
    public class ParkingAgentObservationsCollector
    {
        private readonly ParkingAgentData agentData;
        private readonly ParkingAgentTargetData targetData;

        public ParkingAgentObservationsCollector(ParkingAgentData agentData, ParkingAgentTargetData targetData)
        {
            this.agentData = agentData;
            this.targetData = targetData;
        }

        public void CollectAgentTransformObservations(VectorSensor sensor)
        {
            Vector3 agentPosition = agentData.Transform.position;
            sensor.AddObservation(agentPosition.x);
            sensor.AddObservation(agentPosition.z);
            sensor.AddObservation(agentData.Transform.rotation.eulerAngles.y);
        }

        public void CollectAgentVelocityObservations(VectorSensor sensor)
        {
            sensor.AddObservation(agentData.Rigidbody.velocity.x);
            sensor.AddObservation(agentData.Rigidbody.velocity.z);
            sensor.AddObservation(agentData.Rigidbody.angularVelocity.y);
        }

        public void CollectTargetTransformObservations(VectorSensor sensor)
        {
            Transform targetTransform = targetData.Transform;
            Vector3 targetPosition = targetTransform.position;
            sensor.AddObservation(targetPosition.x);
            sensor.AddObservation(targetPosition.z);
            sensor.AddObservation(targetTransform.rotation.eulerAngles.y);
        }
    }
}