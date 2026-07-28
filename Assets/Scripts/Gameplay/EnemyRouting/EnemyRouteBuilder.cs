using UnityEngine;

namespace TowerDefence
{
    [ExecuteInEditMode]
    public class EnemyRouteBuilder : MonoBehaviour
    {
        [SerializeField] private EnemyRoute enemyRoute;
        [SerializeField] private Vector3[] waypoints;
    }
}