using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace LeoVectorSet
{
    public static class Program
    {
        private const float DegToRad = (float)(Math.PI / 180.0);

        public static void Main(string[] args)
        {
            for (float ae = 01f; ae < 25.0f; ae += 0.1f)
            {
                float angleEps = ae * DegToRad;

                ICollection<Vector3> vs = new VectorSet(angleEps);

                int k1 = 0;
                for (float phi = 0.0f; phi < Math.PI; phi += angleEps * 2.0f)
                {
                    ++k1;
                    vs.Add(CreateTestVector(phi));
                }

                Debug.Assert(k1 == vs.Count, "Add(Vector3) problem");

                int k = k1;
                for (float phi = angleEps / 2.0f; phi < Math.PI; phi += angleEps * 4.0f)
                {
                    --k;
                    vs.Remove(CreateTestVector(phi));
                }

                Debug.Assert(k == vs.Count, "Remove(Vector3) problem");

                for (float phi = 0.0f; phi < Math.PI; phi += angleEps * 2.0f)
                {
                    vs.Add(CreateTestVector(phi));
                }

                Debug.Assert(k1 == vs.Count, "Add(Vector3) problem");
            }

            VectorSet vectorSet = new VectorSet(1.0f * DegToRad);
            Vector3 closest;
            Debug.Assert(!vectorSet.FindClosest(new Vector3(1.0f, 2.0f, 3.0f), float.PositiveInfinity, out closest), "FindClosest(Vector3) problem");
            vectorSet.Add(new Vector3(0.0f, 1.0f, 0.0f));
            vectorSet.Add(new Vector3(0.0f, 0.0f, 1.0f));
            vectorSet.FindClosest(new Vector3(1.0f, 0.1f, 0.0f), float.PositiveInfinity, out closest);

            Debug.Assert(
                vectorSet.FindClosest(new Vector3(1.0f, 0.1f, 0.0f), float.PositiveInfinity, out closest) &&
                closest.x == 0.0f &&
                closest.y == 1.0f &&
                closest.z == 0.0f, "FindClosest(Vector3) problem");
        }

        private static Vector3 CreateTestVector(float phi)
        {
            return new Vector3((float)Math.Cos(phi) * 3, (float)Math.Sin(phi) * 3, 0.0f);
        }
    }
}