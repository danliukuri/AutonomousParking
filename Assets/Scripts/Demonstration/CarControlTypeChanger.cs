using System.Linq;
using AutonomousParking.Demonstration.Architecture;
using Unity.MLAgents.Policies;

namespace AutonomousParking.Demonstration
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