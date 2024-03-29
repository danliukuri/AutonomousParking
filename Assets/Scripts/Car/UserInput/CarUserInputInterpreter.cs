﻿using System;

namespace AutonomousParking.Car.UserInput
{
    public class CarUserInputInterpreter
    {
        private readonly CarData carData;

        public CarUserInputInterpreter(CarData carData) => this.carData = carData;

        public float InterpretAsWheelTorque(float input) => input * carData.MaxWheelTorque;

        public float InterpretAsSteeringAngle(float input) => input * carData.MaxSteeringAngle;

        public bool InterpretAsBreakingState(int input) => Convert.ToBoolean(input);

        public bool InterpretAsBreakingState(bool input) => input;
    }
}