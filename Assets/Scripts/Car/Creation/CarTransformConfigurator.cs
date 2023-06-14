using AutonomousParking.Common.Extensions;
using AutonomousParking.ParkingLot.Data;
using UnityEngine;

namespace AutonomousParking.Car.Creation
{
    public class CarTransformConfigurator : MonoBehaviour
    {
        [SerializeField] private float probabilityToSpawnReverseParked;
        [SerializeField] private Transform carsParent;

        public void Configure(Transform car, Transform parkingSpot, ParkingSpotData parkingSpotData)
        {
            car.SetParent(carsParent);
            ConfigurePosition(car, parkingSpot, parkingSpotData);
            ConfigureRotation(car, parkingSpot, parkingSpotData);
        }

        private void ConfigurePosition(Transform car, Transform parkingSpot, ParkingSpotData parkingSpotData) =>
            car.position = parkingSpot.position.RandomizeHorizontalPosition(parkingSpotData.MaxParkingOffset);

        private void ConfigureRotation(Transform car, Transform parkingSpot, ParkingSpotData parkingSpotData)
        {
            car.rotation = parkingSpot.rotation.RandomizeVerticalRotation(parkingSpotData.MaxParkingAngleOffset);

            const float straightAngle = 180f;
            bool hasCarToBeReverseParked = Random.value < probabilityToSpawnReverseParked;
            if (hasCarToBeReverseParked)
                car.Rotate(car.up, straightAngle);
        }
    }
}