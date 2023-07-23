using System.Collections.Generic;
using UnityEngine;

namespace AutonomousParking.Car.Creation
{
    public class CarsFactoryData : MonoBehaviour
    {
        [field: SerializeField] public Transform Parent { get; private set; }
        [field: SerializeField] public List<GameObject> Prefabs { get; private set; }
    }
}