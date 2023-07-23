using System.Linq;
using AutomaticParking.Demonstration.Architecture;
using Unity.MLAgents.Policies;

namespace AutomaticParking.Demonstration
{
    public class CarControlTypeChanger
    {
        public bool IsAiControlCar { get; private set; } = true;

        public void ChangeCarControlType()
        {
            IsAiControlCar = !IsAiControlCar;
            SetCarControlBehaviorType();
        }

        public void SetCarControlBehaviorType()
        {
            BehaviorParameters behaviorParameters = ServiceLocator.Instance.Get<BehaviorParameters>().First();
            behaviorParameters.BehaviorType = IsAiControlCar ? BehaviorType.InferenceOnly : BehaviorType.HeuristicOnly;
        }
    }
}