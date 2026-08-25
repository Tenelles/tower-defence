using System;
using Gameplay.EnemyRouting;
using NUnit.Framework;
using UnityEngine;

namespace EditModeTests
{
    [TestFixture]
    public class EnemyRouteTests
    {
        private const float Epsilon = 1e-5f;

        private static EnemyRoute CreateRoute(params Vector3[] points) => new(points);

        [Test]
        public void Constructor_ValidPoints_ShouldCreateInstance()
        {
            var points = new[] { new Vector3(0, 0, 0), new Vector3(10, 0, 0) };
            Assert.DoesNotThrow(() => { _ = new EnemyRoute(points); });
        }

        [Test]
        public void Constructor_LessThanTwoPoints_ShouldThrow()
        {
            var points = new[] { new Vector3(0, 0, 0) };
            Assert.Throws<InvalidOperationException>(() => { _ = new EnemyRoute(points); });
        }

        [Test]
        public void Constructor_EmptyArray_ShouldThrow()
        {
            Assert.Throws<InvalidOperationException>(() => { _ = new EnemyRoute(Array.Empty<Vector3>()); });
        }

        [Test]
        public void Constructor_Null_ShouldThrow()
        {
            Assert.Throws<InvalidOperationException>(() => { _ = new EnemyRoute(null); });
        }

        [Test]
        public void Constructor_AllPointsSame_ShouldThrow()
        {
            Vector3[] points = { Vector3.zero, Vector3.zero, Vector3.zero };
            Assert.Throws<InvalidOperationException>(() => { _ = new EnemyRoute(points); });
        }

        [Test]
        public void Constructor_ShouldCloneWaypoints()
        {
            var original = new[] { new Vector3(1, 2, 3), new Vector3(4, 5, 6) };
            var route = new EnemyRoute(original);
            original[0] = Vector3.zero;
            Assert.AreEqual(new Vector3(1, 2, 3), route[0]);
        }

        [Test]
        public void TotalDistance_ShouldBeSumOfSegmentLengths()
        {
            EnemyRoute route = CreateRoute(
                new Vector3(0, 0, 0),
                new Vector3(3, 0, 0),
                new Vector3(3, 4, 0)
            );
            
            Assert.AreEqual(7f, route.TotalDistance, Epsilon);
        }

        [Test]
        public void TotalDistance_SingleSegment_ShouldEqualLength()
        {
            EnemyRoute route = CreateRoute(Vector3.zero, new Vector3(5, 0, 0));
            Assert.AreEqual(5f, route.TotalDistance, Epsilon);
        }

        [Test]
        public void GetPositionByDistance_NegativeDistance_ShouldReturnFirstWaypoint()
        {
            EnemyRoute route = CreateRoute(Vector3.zero, new Vector3(10, 0, 0));
            Vector3 position = route.GetPositionByDistance(-5f);
            Assert.AreEqual(Vector3.zero, position);
        }

        [Test]
        public void GetPositionByDistance_ZeroDistance_ShouldReturnFirstWaypoint()
        {
            EnemyRoute route = CreateRoute(Vector3.zero, new Vector3(10, 0, 0));
            Vector3 position = route.GetPositionByDistance(0f);
            Assert.AreEqual(Vector3.zero, position);
        }

        [Test]
        public void GetPositionByDistance_DistanceGreaterThanTotal_ShouldReturnLastWaypoint()
        {
            EnemyRoute route = CreateRoute(Vector3.zero, new Vector3(10, 0, 0));
            Vector3 position = route.GetPositionByDistance(15f);
            Assert.AreEqual(new Vector3(10, 0, 0), position);
        }

        [Test]
        public void GetPositionByDistance_ExactlyTotalDistance_ShouldReturnLastWaypoint()
        {
            EnemyRoute route = CreateRoute(Vector3.zero, new Vector3(10, 0, 0));
            Vector3 position = route.GetPositionByDistance(10f);
            Assert.AreEqual(new Vector3(10, 0, 0), position);
        }

        [Test]
        public void GetPositionByDistance_InsideFirstSegment_ShouldInterpolate()
        {
            EnemyRoute route = CreateRoute(
                new Vector3(0, 0, 0),
                new Vector3(10, 0, 0),
                new Vector3(20, 0, 0)
            );
            Vector3 position = route.GetPositionByDistance(3f);
            Assert.AreEqual(new Vector3(3, 0, 0), position);
        }

        [Test]
        public void GetPositionByDistance_InsideSecondSegment_ShouldInterpolate()
        {
            EnemyRoute route = CreateRoute(
                new Vector3(0, 0, 0),
                new Vector3(10, 0, 0),
                new Vector3(20, 0, 0)
            );
            Vector3 position = route.GetPositionByDistance(15f);
            Assert.AreEqual(new Vector3(15, 0, 0), position);
        }

        [Test]
        public void GetPositionByDistance_ExactlyAtWaypoint_ShouldReturnThatWaypoint()
        {
            EnemyRoute route = CreateRoute(
                new Vector3(0, 0, 0),
                new Vector3(10, 0, 0),
                new Vector3(20, 0, 0)
            );
            Vector3 position = route.GetPositionByDistance(10f);
            Assert.AreEqual(new Vector3(10, 0, 0), position);
        }

        [Test]
        public void GetPositionByDistance_VariedSegmentLengths_ShouldInterpolateCorrectly()
        {
            EnemyRoute route = CreateRoute(
                new Vector3(0, 0, 0),
                new Vector3(3, 0, 0),
                new Vector3(3, 4, 0)
            );
            Vector3 position = route.GetPositionByDistance(5f);
            var expected = new Vector3(3, 2, 0);
            Assert.AreEqual(expected, position);
        }

        [Test]
        public void GetPositionByDistance_With3DCoordinates_ShouldWork()
        {
            EnemyRoute route = CreateRoute(
                new Vector3(1, 2, 3),
                new Vector3(4, 6, 8)
            );
            float t = 3f / Vector3.Distance(new Vector3(1, 2, 3), new Vector3(4, 6, 8));
            Vector3 expected = new Vector3(1, 2, 3) + t * (new Vector3(4, 6, 8) - new Vector3(1, 2, 3));
            Vector3 actual = route.GetPositionByDistance(3f);
            Assert.AreEqual(expected.x, actual.x, Epsilon);
            Assert.AreEqual(expected.y, actual.y, Epsilon);
            Assert.AreEqual(expected.z, actual.z, Epsilon);
        }

        [Test]
        public void FindWaypointIndexBeforeDistance_DistanceZero_ShouldReturn0()
        {
            EnemyRoute route = CreateRoute(Vector3.zero, new Vector3(10, 0, 0));
            Assert.AreEqual(0, route.FindWaypointIndexBeforeDistance(0f));
        }

        [Test]
        public void FindWaypointIndexBeforeDistance_NegativeDistance_ShouldReturn0()
        {
            EnemyRoute route = CreateRoute(Vector3.zero, new Vector3(10, 0, 0));
            Assert.AreEqual(0, route.FindWaypointIndexBeforeDistance(-1f));
        }

        [Test]
        public void FindWaypointIndexBeforeDistance_DistanceGreaterThanTotal_ShouldReturnLastWaypointIndex()
        {
            EnemyRoute route = CreateRoute(Vector3.zero, new Vector3(10, 0, 0), new Vector3(20, 0, 0));
            Assert.AreEqual(2, route.FindWaypointIndexBeforeDistance(25f));
        }

        [Test]
        public void FindWaypointIndexBeforeDistance_ExactlyTotalDistance_ShouldReturnLastWaypointIndex()
        {
            EnemyRoute route = CreateRoute(Vector3.zero, new Vector3(10, 0, 0), new Vector3(20, 0, 0));
            Assert.AreEqual(2, route.FindWaypointIndexBeforeDistance(20f));
        }

        [Test]
        public void FindWaypointIndexBeforeDistance_InsideFirstSegment_ShouldReturn0()
        {
            EnemyRoute route = CreateRoute(
                new Vector3(0, 0, 0),
                new Vector3(10, 0, 0),
                new Vector3(20, 0, 0)
            );
            Assert.AreEqual(0, route.FindWaypointIndexBeforeDistance(3f));
        }

        [Test]
        public void FindWaypointIndexBeforeDistance_InsideSecondSegment_ShouldReturn1()
        {
            EnemyRoute route = CreateRoute(
                new Vector3(0, 0, 0),
                new Vector3(10, 0, 0),
                new Vector3(20, 0, 0)
            );
            Assert.AreEqual(1, route.FindWaypointIndexBeforeDistance(15f));
        }

        [Test]
        public void FindWaypointIndexBeforeDistance_ExactlyAtFirstWaypoint_ShouldReturn1()
        {
            EnemyRoute route = CreateRoute(
                new Vector3(0, 0, 0),
                new Vector3(10, 0, 0),
                new Vector3(20, 0, 0)
            );
            Assert.AreEqual(1, route.FindWaypointIndexBeforeDistance(10f));
        }

        [Test]
        public void FindWaypointIndexBeforeDistance_ExactlyAtSecondWaypoint_ShouldReturn2()
        {
            EnemyRoute route = CreateRoute(
                new Vector3(0, 0, 0),
                new Vector3(10, 0, 0),
                new Vector3(20, 0, 0)
            );
            Assert.AreEqual(2, route.FindWaypointIndexBeforeDistance(20f));
        }

        [Test]
        [TestCase(5f, 1)]
        [TestCase(3f, 1)]
        [TestCase(0.5f, 0)]
        [TestCase(7f, 2)]
        public void FindWaypointIndexBeforeDistance_VariedLengths_ShouldReturnCorrectWaypoint(float distance, int result)
        {
            EnemyRoute route = CreateRoute(
                new Vector3(0, 0, 0),
                new Vector3(3, 0, 0),
                new Vector3(3, 4, 0)
            );
            Assert.AreEqual(result, route.FindWaypointIndexBeforeDistance(distance));
        }

        [Test]
        public void Indexer_ShouldReturnWaypointAtIndex()
        {
            Vector3[] points = { new(1, 2, 3), new(4, 5, 6) };
            var route = new EnemyRoute(points);
            Assert.AreEqual(new Vector3(4, 5, 6), route[1]);
        }

        [Test]
        public void Size_ShouldEqualNumberOfWaypoints()
        {
            Vector3[] points = { Vector3.zero, Vector3.one, new(2, 2, 2) };
            var route = new EnemyRoute(points);
            Assert.AreEqual(3, route.Size);
        }
    }
}