using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit.Framework.Constraints;

namespace LeoVectorSet.Tests
{
    [TestFixture]
    class VectorSetTest
    {
        [Test]
        public void ContainsShouldReturnFalseForSmallEps()
        {
            VectorSet vs = new VectorSet(0.1f);
            vs.Add(new Vector3(1, 0, 0));
            vs.Add(new Vector3(0, 1, 0));
            Assert.IsFalse(vs.Contains(new Vector3(0, 0, 1)));
        }

        [Test]
        public void ContainsShouldReturnTrueFor0EpsSameVector()
        {
            VectorSet vs = new VectorSet(0);
            vs.Add(new Vector3(5, 0, 2));
            vs.Add(new Vector3(0, 1, 0));
            Assert.IsTrue(vs.Contains(new Vector3(5, 0, 2)));
        }

        [Test]
        public void CantAddIfItContained()
        {
            VectorSet vs = new VectorSet(0.5f);
            vs.Add(new Vector3(1, 2, -5));
            vs.Add(new Vector3(0.95f, 2, -5));
            Assert.AreEqual(1,vs.Count);
        }

        [Test]
        public void AddsIfItNotContained()
        {
            VectorSet vs = new VectorSet(0.5f);
            vs.Add(new Vector3(1, 2, -5));
            vs.Add(new Vector3(50, 2, -5));
            Assert.AreEqual(2,vs.Count);
        }
        
        [Test]
        public void RemoveIfSameDirection()
        {
            VectorSet vs = new VectorSet(0.5f);
            vs.Add(new Vector3(1, 0, 0));
            vs.Remove(new Vector3(2, 0.1f, 0));
            Assert.AreEqual(0, vs.Count);
        }

        [Test]
        public void IsItTheClosestOfTheSetGeneralUsageWhenTrue()
        {
            VectorSet vs = new VectorSet(0.01f);
            vs.Add(new Vector3(1, 0, 0));
            vs.Add(new Vector3(2, 1, 0));
            vs.Add(new Vector3(1, 4, 5));
            vs.Add(new Vector3(1, 0, -3));
            Vector3 closest;
            //Assert.AreEqual(true, vs.FindClosest(new Vector3(2, 1.2f, 0), float.PositiveInfinity, out closest));
            vs.FindClosest(new Vector3(2, 1.1f, 0), float.PositiveInfinity, out closest);
                
            Assert.AreEqual(true, VectorMath.AreEqual(closest,new Vector3(2,1,0)));

        }

        [Test]
        public void IsTheClosestWhenItIsTheSame()
        {
            VectorSet vs = new VectorSet(0.01f);
            vs.Add(new Vector3(1, 0, 0));
            vs.Add(new Vector3(2, 1, 0));
            vs.Add(new Vector3(1, 4, 5));
            vs.Add(new Vector3(1, 0, -3));
            Vector3 closest;
            vs.FindClosest(new Vector3(1,4,5), float.PositiveInfinity, out closest);
            Assert.IsTrue(VectorMath.AreEqual(closest, new Vector3(1, 4, 5)));
        }

        [Test]
        public void FindClosestReturnsFalseIfVectorsEmpty()
        {
            VectorSet vs = new VectorSet(0.01f);
            Vector3 closest;
            Assert.IsFalse(vs.FindClosest(new Vector3(1, 4, 5), float.PositiveInfinity, out closest));
        }
    }
}
