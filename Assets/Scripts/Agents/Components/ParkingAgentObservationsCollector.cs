using AutomaticParking.Agents.Data;
using Unity.MLAgents.Sensors;
using UnityEngine;

namespace AutomaticParking.Agents.Components
{
    public class ParkingAgentObservationsCollector
    {
        private readonly ParkingAgentData data;

        public ParkingAgentObservationsCollector(ParkingAgentData data) => this.data = data;

        public void CollectAgentTransformObservations(VectorSensor sensor)
        {
            Vector3 agentPosition = data.Transform.position;
            sensor.AddObservation(agentPosition.x);
            sensor.AddObservation(agentPosition.z);
            sensor.AddObservation(data.Transform.rotation.eulerAngles.y);
        }

        public void CollectAgentVelocityObservations(VectorSensor sensor)
        {
            sensor.AddObservation(data.Rigidbody.velocity.x);
            sensor.AddObservation(data.Rigidbody.velocity.z);
        }

        public void CollectTargetTransformObservations(VectorSensor sensor)
        {
            Transform targetTransform = data.TargetTrackingData.Transform;
            Vector3 targetPosition = targetTransform.position;
            sensor.AddObservation(targetPosition.x);
            sensor.AddObservation(targetPosition.z);
            sensor.AddObservation(targetTransform.rotation.eulerAngles.y);
        }
    }
}