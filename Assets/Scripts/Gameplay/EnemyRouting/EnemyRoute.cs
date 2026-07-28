using UnityEngine;

namespace TowerDefence
{
    [CreateAssetMenu(fileName = "EnemyRoute", menuName = "TowerDefence/Enemy route", order = 0)]
    public class EnemyRoute : ScriptableObject
    {
        [SerializeField] public Vector3[] waypoints;
    }
}