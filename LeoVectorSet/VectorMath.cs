using System;
using System.Collections;
using System.Collections.Generic;


namespace LeoVectorSet
{
    public static class VectorMath
    {
        public static float AngleBetweenVectors(Vector3 a, Vector3 b)
        {
            a = a.Normalized();
            b = b.Normalized();
            float cosAlpha = DotProduct(a, b);
            return Convert.ToSingle(Math.Acos(cosAlpha));
        }

        public static float DotProduct(Vector3 a, Vector3 b)
        {
            return a.x * b.x + a.y * b.y + a.z * b.z;
        }

        public static Vector3 Subtract(Vector3 a, Vector3 b)
        {
            return new Vector3(a.x - b.x, a.y - b.y, a.z - b.z);
        }

        public static Vector3 AddVectors(Vector3 a, Vector3 b)
        {
            return new Vector3(a.x + b.x, a.y + b.y, a.z + b.z);
        }

        public static bool AreEqual(Vector3 a, Vector3 b) {
            return a.x == b.x && a.y == b.y && a.z == b.z;
        }
    }
}