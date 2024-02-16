using CodeBase.Data;
using UnityEngine;

namespace CodeBase.Extensions
{
    public static class VectorDataExtension
    {
        public static Vector3Data ToData(this Vector3 vector3)
        {
            return new Vector3Data().SetPositions(vector3.x, vector3.y, vector3.z);
        }
        
        public static Vector3 ToVector(this Vector3Data vector3)
        {
            return new Vector3(vector3.X, vector3.Y, vector3.Z);
        }

        public static Vector3Data SetPositions(this Vector3Data vector3Data, float x, float y, float z)
        {
            vector3Data.X = x;
            vector3Data.Y = y;
            vector3Data.Z = z;
            return vector3Data;
        }
    }
}