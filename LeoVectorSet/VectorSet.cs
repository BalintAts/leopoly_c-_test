using System;
using System.Collections;
using System.Collections.Generic;


namespace LeoVectorSet
{
    public class VectorSet : ICollection<Vector3>
    {
        private readonly float _epsilon;
        private List<Vector3> _vectors = new List<Vector3>();

        /// <summary>
        /// Initializes a new instance of the VectorSet class.
        /// </summary>
        /// <param name="epsilon">Epsilon angle in radians</param>
        public VectorSet(float epsilon)
        {
            _epsilon = epsilon;
        }

        /// <summary>
        /// Epsilon angle in radians.
        /// </summary>
        public float Epsilon => _epsilon;

        bool ICollection<Vector3>.IsReadOnly => false;

        public int Count
        {
            get { return _vectors.Count; }
        }

        /// <summary>
        /// Adds a new item to the vector set.
        /// </summary>
        /// <returns>true if the element is added to the <see cref="VectorSet"/> object; false if a <see cref="Vector3"/> with the same direction was already present.</returns>
        public bool Add(Vector3 item)
        {
            if (Contains(item))
            {
                return false;
            }
            _vectors.Add(item);
            return true;
        }

        /// <summary>
        /// Removes any vectors from the set with the same direction.
        /// </summary>
        /// <returns>Number of removed items.</returns>
        public int Remove(Vector3 item)
        {
            int removedCount = 0;
            for (int i = _vectors.Count - 1; i >= 0; i--)
            {
                if (VectorMath.AngleBetweenVectors(_vectors[i], item) <= _epsilon)                   
                {
                    _vectors.RemoveAt(i);
                    removedCount++;
                }
            }
            return removedCount;
        }

        /// <summary>
        /// Removes all items from the collection.
        /// </summary>
        public void Clear()
        {
            _vectors.Clear();
        }

        /// <summary>
        /// Gets the vector in the set closest to the given vector within the given epsilon angle.
        /// </summary>
        /// <param name="dir">The direction vector to look for.</param>
        /// <param name="epsilon">Maximum angle between the given vector and the resulting one in radians.</param>
        /// <param name="result">The vector in the set, if found.</param>
        /// <returns>true if a Vector3 was found within given epsilon angle.</returns>
        public bool FindClosest(Vector3 dir, float epsilon, out Vector3 result)
        {
            result = new Vector3(0, 0, 0);
            if (_vectors.Count > 0)
            {
                result = _vectors[0];

                float currentSmallestAngle = float.PositiveInfinity;
                for (int i = 0; i < _vectors.Count; i++)
                {
                    float angleDiff = VectorMath.AngleBetweenVectors(dir, _vectors[i]);
                    if (angleDiff < currentSmallestAngle)
                    {
                        result = _vectors[i];
                        currentSmallestAngle = angleDiff;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// Determines if a vector is already present in the collection (given the pre-defined angle tolerance).
        /// </summary>
        public bool Contains(Vector3 item)
        {
            foreach(Vector3 vector in _vectors)
            {
                if(VectorMath.AngleBetweenVectors(vector,item) <= _epsilon)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        public IEnumerator<Vector3> GetEnumerator()
        {
            foreach (Vector3 vector in _vectors)
            {
                yield return vector;
            }
        }

        public void CopyTo(Vector3[] array, int arrayIndex)
        {
            Vector3[] vectorArray = array as object[];
            if (vectorArray!= null)
            {
                for (int i = 0; i < _vectors.Count; i++)
                {
                    vectorArray[arrayIndex++] = _vectors[i];
                }
            }

            throw new ArgumentException("Target array type is not compatible with the type of items in the collection.");
        }

        void ICollection<Vector3>.Add(Vector3 item) => this.Add(item);

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

        bool ICollection<Vector3>.Remove(Vector3 item) => this.Remove(item) > 0;
    }
}