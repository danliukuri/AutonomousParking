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
            EnteringCarPlacingData data = ((ParkingLotEnteringCarPlacer)target).Data;
            if (data is not null)
                DrawPlacingZone(data);
        }

        private void DrawPlacingZone(EnteringCarPlacingData data)
        {
            var minPosition = new Vector3(data.MinPositionX, MinY, data.MinPositionZ);
            var maxPosition = new Vector3(data.MaxPositionX, MaxY, data.MaxPositionZ);
            Vector3 placingZoneCenter = (minPosition + maxPosition) / 2f;
            Vector3 placingZoneSize = maxPosition - minPosition;

            Handles.color = placingZoneColor;
            Handles.DrawWireCube(placingZoneCenter, placingZoneSize);
            Handles.color = carReachBoundsColor;
            Handles.DrawWireCube(placingZoneCenter, placingZoneSize + new Vector3(CarSize, default, -CarSize));
        }
    }
}