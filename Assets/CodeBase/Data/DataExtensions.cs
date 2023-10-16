﻿using UnityEngine;

namespace Assets.CodeBase.Data
{
    public static class DataExtensions
    {
        public static float SqrMagnitudeTo(this Vector3 from, Vector3 to) => 
            Vector3.SqrMagnitude(to - from);

        public static string ToJson(this object obj) => 
            JsonUtility.ToJson(obj);

        public static T ToDeserialized<T>(this string json) =>
            JsonUtility.FromJson<T>(json);
    }
}