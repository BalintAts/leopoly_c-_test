using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace LeoVectorSet.Tests
{
    [TestFixture]
    class VectorMathTest
    {
        [Test]
        public void AngleBetweetRightAngledVectors_ShouldReturn1dot57079637()
        {
            Vector3 v1 = new Vector3(2, 0, 0);
            Vector3 v2 = new Vector3(0, 2, 0);
            Assert.AreEqual(1.57079637f , VectorMath.AngleBetweenVectors(v1, v2));
        }        
        
        [Test]
        public void AngleBetweetSameVectorsShouldReturn0()
        {
            Vector3 v1 = new Vector3(1, 0, 0);
            Vector3 v2 = new Vector3(1, 0, 0);
            Assert.AreEqual(0 , VectorMath.AngleBetweenVectors(v1, v2));
        }        
        
        [Test]
        public void AngleBetweetSameDirectionButDifferentMagnitudeVectorsShouldReturn0()
        {
            Vector3 v1 = new Vector3(1, 0, 0);
            Vector3 v2 = new Vector3(2, 0, 0);
            Assert.AreEqual(0 , VectorMath.AngleBetweenVectors(v1, v2));
        }

        [Test]
        public void DotProduct2_3_4__5_6_7shouldReturn56()
        {
            Vector3 v1 = new Vector3(2, 3, 4);
            Vector3 v2 = new Vector3(5, 6, 7);
            Assert.AreEqual(56 , VectorMath.DotProduct(v1, v2) );
        }
    }
}
