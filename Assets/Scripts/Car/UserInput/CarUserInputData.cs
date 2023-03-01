using UnityEngine;

namespace AutomaticParking.Car.UserInput
{
    public static class CarUserInputData
    {
        private const string WheelTorqueAxisName = "Vertical";
        private const string SteeringAngleAxisName = "Horizontal";
        private const KeyCode BrakingKeyCode = KeyCode.Space;

        public static float WheelTorque => Input.GetAxis(WheelTorqueAxisName);
        public static float SteeringAngle => Input.GetAxis(SteeringAngleAxisName);
        public static bool IsBreaking => Input.GetKey(BrakingKeyCode);
    }
}