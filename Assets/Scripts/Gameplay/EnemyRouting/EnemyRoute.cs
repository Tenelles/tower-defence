using System;
using UnityEngine;

namespace TowerDefence
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
            if (waypoints is not { Length: > 2 })
                throw new InvalidOperationException("Must have at least two waypoint.");

            Size = waypoints.Length;
            _waypoints = (Vector3[])waypoints.Clone();
            _distances = new float[Size - 1];
            _cumulativeDistances = new float[Size - 1];
            TotalDistance = 0;
            for (var index = 0; index < Size - 1; index++)
            {
                float distance = Vector3.Distance(_waypoints[index], _waypoints[index + 1]);
                _distances[index] = distance;
                TotalDistance += distance;
                _cumulativeDistances[index] = TotalDistance;
            }

            if (TotalDistance == 0)
                throw new InvalidOperationException("TotalDistance is zero.");
        }

        public Vector3 GetPositionByDistance(float distance)
        {
            int lastWaypointIndex = GetLastIndexBeforeDistance(distance);
            if (lastWaypointIndex == Size - 1)
                return _waypoints[lastWaypointIndex];

            float distanceFromLastWaypoint = distance - _distances[lastWaypointIndex];
            if (distanceFromLastWaypoint <= 0)
                return _waypoints[lastWaypointIndex];

            return Vector3.MoveTowards(_waypoints[lastWaypointIndex], _waypoints[lastWaypointIndex + 1],
                distanceFromLastWaypoint);
        }

        public int GetLastIndexBeforeDistance(float distance)
        {
            for (var index = 0; index < Size - 1; index++)
                if (distance < _cumulativeDistances[index])
                    return index;

            return Size - 1;
        }
    }
}