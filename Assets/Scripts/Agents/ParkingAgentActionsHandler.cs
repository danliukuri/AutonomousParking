using System;
using AutomaticParking.Car;
using AutomaticParking.Car.UserInput;
using Unity.MLAgents.Actuators;

namespace AutomaticParking.Agents
{
    public class ParkingAgentActionsHandler
    {
        private readonly CarData carData;
        private readonly CarUserInputInterpreter interpreter;

        public ParkingAgentActionsHandler(CarData carData)
        {
            this.carData = carData;
            interpreter = new CarUserInputInterpreter(carData);
        }

        public void HandleInputActions(ActionBuffers actions)
        {
            carData.CurrentWheelTorque = interpreter.InterpretAsWheelTorque(actions.ContinuousActions[0]);
            carData.CurrentSteeringAngle = interpreter.InterpretAsSteeringAngle(actions.ContinuousActions[1]);
            carData.IsBreaking = interpreter.InterpretAsBreakingState(actions.DiscreteActions[0]);
        }

        public void HandleHeuristicInputContinuousActions(in ActionSegment<float> continuousActionsOut)
        {
            continuousActionsOut[0] = CarUserInputData.WheelTorque;
            continuousActionsOut[1] = CarUserInputData.SteeringAngle;
        }

        public void HandleHeuristicInputDiscreteActions(in ActionSegment<int> discreteActionsOut) =>
            discreteActionsOut[0] = Convert.ToInt32(CarUserInputData.IsBreaking);
    }
}