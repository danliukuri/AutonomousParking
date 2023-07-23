using AutomaticParking.Demonstration.Architecture;
using Unity.MLAgents.Policies;
using UnityEngine;

namespace AutomaticParking.Demonstration.Infrastructure
{
    public class ParkingAgentServicesRegistrar : MonoBehaviour
    {
        [SerializeField] private BehaviorParameters parkingAgentBehaviorParameters;

        private void Awake() => ServiceLocator.Instance.Register(parkingAgentBehaviorParameters);

        private void OnDestroy() => ServiceLocator.Instance.Unregister(parkingAgentBehaviorParameters);
    }
}