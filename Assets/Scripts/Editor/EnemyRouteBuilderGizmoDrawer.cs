using Gameplay.EnemyRouting;
using UnityEditor;
using UnityEngine;

namespace Editor
{
    public static class EnemyRouteBuilderGizmoDrawer
    {
        [DrawGizmo(GizmoType.Selected | GizmoType.NonSelected)]
        private static void DrawGizmoForEnemyRouteBuilder(EnemyRouteBuilder pathBuilder, GizmoType gizmoType)
        {
            for (var index = 1; index < pathBuilder.Waypoints.Length; index++)
            {
                Vector3 current = pathBuilder.Waypoints[index];
                Vector3 previous = pathBuilder.Waypoints[index - 1];
                Gizmos.DrawLine(previous, current);
            }
        }
    }
}