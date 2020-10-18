using System;
using System.Collections;
using System.Collections.Generic;

namespace LeoVectorSet
{
    public struct Vector3
    {
        public float x, y, z;

        public Vector3(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public float Magnitude()
        {
            return Convert.ToSingle(Math.Sqrt(x*x + y*y + z*z));
        }

        public Vector3 Normalized()
        {
            float a, b, c;
            a = x / Magnitude();
            b = y / Magnitude();
            c = z / Magnitude();
            return new Vector3(a, b, c);
        }
    }
}