using UnityEngine;

namespace AutomaticParking.Car.UserInput
{
    public class CarUserInputHandler : MonoBehaviour
    {
        private const string VerticalAxisName = "Vertical";
        private const string HorizontalAxisName = "Horizontal";
        private const KeyCode BrakingKeyCode = KeyCode.Space;

        [SerializeField] private CarData carData;
        private CarUserInputInterpreter interpreter;

        private void Awake() => interpreter = new CarUserInputInterpreter(carData);

        private void Update()
        {
            carData.CurrentWheelTorque = interpreter.InterpretAsWheelTorque(Input.GetAxis(VerticalAxisName));
            carData.CurrentSteeringAngle = interpreter.InterpretAsSteeringAngle(Input.GetAxis(HorizontalAxisName));
            carData.IsBreaking = interpreter.InterpretAsBreakingState(Input.GetKey(BrakingKeyCode));
        }
    }
}