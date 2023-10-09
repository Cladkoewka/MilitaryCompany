using UnityEngine;

namespace Assets.CodeBase.Data
{
    public static class DataExtensions
    {
        public static float SqrMagnitudeTo(this Vector3 from, Vector3 to)
        {
            return Vector3.SqrMagnitude(to - from);
        }
    }
}