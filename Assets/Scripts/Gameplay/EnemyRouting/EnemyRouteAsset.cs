using UnityEngine;

namespace Gameplay.EnemyRouting
{
    [CreateAssetMenu(fileName = "EnemyRoute", menuName = "TowerDefence/Enemy route", order = 0)]
    public class EnemyRouteAsset : ScriptableObject
    {
        [SerializeField] public Vector3[] waypoints;
    }
}