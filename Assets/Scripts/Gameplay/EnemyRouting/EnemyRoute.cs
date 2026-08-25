using System;
using UnityEngine;

namespace Gameplay.EnemyRouting
{
    public class EnemyRoute
    {
        private readonly Vector3[] _waypoints;
        private readonly float[] _distances;
        private readonly float[] _cumulativeDistances;

        public float TotalDistance { get; }
        public int Size { get; }
        public Vector3 this[int index] => _waypoints[index];

        public EnemyRoute(Vector3[] waypoints)
        {
            if (waypoints is not { Length: > 1 })
                throw new InvalidOperationException("Must have at least two waypoint.");

            Size = waypoints.Length;
            _waypoints = (Vector3[])waypoints.Clone();
            _distances = new float[Size];
            _cumulativeDistances = new float[Size];

            _distances[0] = 0;
            _cumulativeDistances[0] = 0;
            TotalDistance = 0;
            for (var index = 1; index < Size; index++)
            {
                _distances[index] = Vector3.Distance(_waypoints[index], _waypoints[index - 1]);
                TotalDistance += _distances[index];
                _cumulativeDistances[index] = TotalDistance;
            }

            if (TotalDistance == 0)
                throw new InvalidOperationException("TotalDistance is zero.");
        }

        public Vector3 GetPositionByDistance(float distance)
        {
            int index = FindWaypointIndexBeforeDistance(distance);
            if (index == Size - 1)
                return _waypoints[index];

            float offset = distance - _cumulativeDistances[index];
            return offset >= 0
                ? Vector3.MoveTowards(_waypoints[index], _waypoints[index + 1], offset)
                : _waypoints[0];
        }

        public int FindWaypointIndexBeforeDistance(float distance)
        {
            if (distance <= 0)
                return 0;

            if (distance >= TotalDistance)
                return Size - 1;

            int index = Array.BinarySearch(_cumulativeDistances, distance);
            return index > 0 ? index : ~index - 1;
        }
    }
}