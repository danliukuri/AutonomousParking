using AutomaticParking.Agents.Data;
using UnityEditor;
using UnityEngine;

namespace AutomaticParking.Editor.Agent.Data
{
    [CanEditMultipleObjects, CustomEditor(typeof(ParkingAgentTargetData))]
    public class ParkingAgentTargetParkingZoneDrawer : UnityEditor.Editor
    {
        private readonly Color parkingZoneColor = Color.green;
        private readonly Color perfectParkingZoneColor = Color.white;
        
        private void OnSceneGUI()
        {
            var data = (ParkingAgentTargetData)target;
            Vector3 position = data.transform.position;
            
            Handles.color = parkingZoneColor;
            Handles.DrawWireDisc(position, Vector3.up, data.ParkingRadius);
            Handles.color = perfectParkingZoneColor;
            Handles.DrawWireDisc(position, Vector3.up, data.PerfectParkingRadius);
        }
    }
}