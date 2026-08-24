using UnityEngine;

namespace TowerDefence
{
    [ExecuteInEditMode]
    public class EnemyRouteBuilder : MonoBehaviour
    {
        [SerializeField] private EnemyRouteAsset enemyRoute;
        [SerializeField] private Vector3[] waypoints;

        public Vector3[] Waypoints => waypoints;
    }
}