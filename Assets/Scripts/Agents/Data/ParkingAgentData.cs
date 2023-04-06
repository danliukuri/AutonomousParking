using UnityEngine;

namespace AutomaticParking.Agents.Data
{
    public class ParkingAgentData
    {
        private readonly ParkingAgent agent;
        public ParkingAgentData(ParkingAgent agent) => this.agent = agent;

        public float MinStepToReachTarget => 200f;
        public float MaxStepToReachTarget => agent.MaxStep;
        public float StepCount => agent.StepCount;

        public Rigidbody Rigidbody { get; set; }
        public Transform Transform { get; set; }
        public Vector3 InitialPosition { get; set; }
        public Quaternion InitialRotation { get; set; }

        public void Reset()
        {
            Transform.position = InitialPosition;
            Transform.rotation = InitialRotation;
            Rigidbody.velocity = default;
            Rigidbody.angularVelocity = default;
        }
    }
}