using AutomaticParking.ParkingLot.Data;
using AutomaticParking.ParkingLot.ObjectPlacers;
using UnityEditor;
using UnityEngine;

namespace AutomaticParking.Editor.ParkingLot.ObjectPlacers
{
    [CanEditMultipleObjects, CustomEditor(typeof(ParkingLotEnteringCarPlacer))]
    public class ParkingLotEnteringCarPlacingZoneDrawer : UnityEditor.Editor
    {
        private const float CarSize = 4f;
        private const float MinY = 0f, MaxY = 0.5f;
        private readonly Color carReachBoundsColor = Color.red;
        private readonly Color placingZoneColor = Color.green;

        private void OnSceneGUI()
        {
            var parkingLotEnteringCarPlacer = (ParkingLotEnteringCarPlacer)target;
            EnteringCarPlacingData data = parkingLotEnteringCarPlacer.Data;
            if (data is not null)
                DrawPlacingZone(data, parkingLotEnteringCarPlacer.transform.position);
        }

        private void DrawPlacingZone(EnteringCarPlacingData data, Vector3 targetPosition)
        {
            Vector3 minPosition = targetPosition + new Vector3(data.MinPositionX, MinY, data.MinPositionZ);
            Vector3 maxPosition = targetPosition + new Vector3(data.MaxPositionX, MaxY, data.MaxPositionZ);
            Vector3 placingZoneCenter = (minPosition + maxPosition) / 2f;
            Vector3 placingZoneSize = maxPosition - minPosition;

            Handles.color = placingZoneColor;
            Handles.DrawWireCube(placingZoneCenter, placingZoneSize);
            Handles.color = carReachBoundsColor;
            Handles.DrawWireCube(placingZoneCenter, placingZoneSize + new Vector3(CarSize, default, -CarSize));
        }
    }
}