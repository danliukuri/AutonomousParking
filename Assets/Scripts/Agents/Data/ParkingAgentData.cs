using System;
using UnityEngine;

namespace AutomaticParking.Agents.Data
{
    [Serializable]
    public class ParkingAgentData
    {
        [field: SerializeField] public int MinStepToStartParking { get; private set; }
        public int MaxStepToStartParking => Agent.MaxStep;
        public int StepCount => Agent.StepCount;
        public bool HasReachedMaxStep => Agent.StepCount == Agent.MaxStep;

        public ParkingAgent Agent { get; set; }
        public Rigidbody Rigidbody { get; set; }
        public Transform Transform { get; set; }

        public void Reset() => Rigidbody.velocity = Rigidbody.angularVelocity = default;
    }
}