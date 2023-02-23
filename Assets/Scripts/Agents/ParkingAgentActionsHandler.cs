using AutomaticParking.Car;
using AutomaticParking.Car.UserInput;
using Unity.MLAgents.Actuators;
using UnityEngine;

namespace AutomaticParking.Agents
{
    public class ParkingAgentActionsHandler : MonoBehaviour
    {
        [SerializeField] private CarData carData;
        private CarUserInputInterpreter interpreter;

        private void Awake() => interpreter = new CarUserInputInterpreter(carData);

        public void HandleInputActions(ActionBuffers actions)
        {
            carData.CurrentWheelTorque = interpreter.InterpretAsWheelTorque(actions.ContinuousActions[0]);
            carData.CurrentSteeringAngle = interpreter.InterpretAsSteeringAngle(actions.ContinuousActions[1]);
            carData.IsBreaking = interpreter.InterpretAsBreakingState(actions.DiscreteActions[0]);
        }
    }
}