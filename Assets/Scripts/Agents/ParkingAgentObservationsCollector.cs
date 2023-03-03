using Unity.MLAgents.Sensors;
using UnityEngine;

namespace AutomaticParking.Agents
{
    public class ParkingAgentObservationsCollector
    {
        private readonly ParkingAgentData data;
        private readonly Rigidbody rigidbody;

        public ParkingAgentObservationsCollector(ParkingAgentData data, Rigidbody rigidbody)
        {
            this.data = data;
            this.rigidbody = rigidbody;
        }

        public void CollectAgentTransformObservations(VectorSensor sensor)
        {
            Vector3 agentPosition = data.Transform.position;
            sensor.AddObservation(agentPosition.x);
            sensor.AddObservation(agentPosition.z);
            sensor.AddObservation(data.Transform.rotation.eulerAngles.y);
        }

        public void CollectAgentVelocityObservations(VectorSensor sensor)
        {
            sensor.AddObservation(rigidbody.velocity.x);
            sensor.AddObservation(rigidbody.velocity.z);
        }

        public void CollectTargetTransformObservations(VectorSensor sensor)
        {
            Vector3 targetPosition = data.Target.position;
            sensor.AddObservation(targetPosition.x);
            sensor.AddObservation(targetPosition.z);
            sensor.AddObservation(data.Target.rotation.eulerAngles.y);
        }
    }
}