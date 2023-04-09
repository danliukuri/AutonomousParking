using AutomaticParking.Common.Extensions;
using AutomaticParking.ParkingLot.Data;
using UnityEngine;

namespace AutomaticParking.ParkingLot.ObjectPlacers
{
    public class ParkingLotEnteringCarPlacer : MonoBehaviour
    {
        [field: SerializeField] public EnteringCarPlacingData Data { get; private set; }

        public void Place(Transform agent)
        {
            float randomX = Random.Range(Data.MinPositionX, Data.MaxPositionX);
            float randomZ = Random.Range(Data.MinPositionZ, Data.MaxPositionZ);
            agent.localPosition = new Vector3(randomX, default, randomZ);

            float randomAngle = Random.Range(Data.MinRotationAngle, Data.MaxRotationAngle);
            float angleOffset = randomX.ChangeBounds(Data.MinPositionX, Data.MaxPositionX,
                Data.RotationAngleOffsetOnMinPositionX, Data.RotationAngleOffsetOnMaxPositionX);
            agent.localRotation = Quaternion.Euler(default, randomAngle + angleOffset, default);
        }
    }
}