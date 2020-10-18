using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace LeoVectorSet.Tests
{
    [TestFixture]
    class Vector3Test
    {
        [Test]
        public void Magnitude_3_4_0_ShouldRetunr5()
        {
            LeoVectorSet.Vector3 vector = new LeoVectorSet.Vector3(3, 4, 0);
            Assert.AreEqual(vector.Magnitude(), 5);
        }

        [Test]
        public void Normalized_magnitude_ShouldRetunr1()
        {
            LeoVectorSet.Vector3 vector = new LeoVectorSet.Vector3(3, 4, 0);
            Assert.AreEqual(vector.Normalized().Magnitude(), 1);
        }




    }
}
