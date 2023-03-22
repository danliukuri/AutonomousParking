using UnityEngine;

namespace AutomaticParking.Common.Extensions
{
    public static class RigidbodyExtensions
    {
        public static void Reset(this Rigidbody rigidbody, Vector3 position, Quaternion rotation)
        {
            rigidbody.velocity = default;
            rigidbody.angularVelocity = default;
            rigidbody.position = position;
            rigidbody.rotation = rotation;
        }
    }
}