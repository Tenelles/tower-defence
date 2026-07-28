using UnityEditor;
using UnityEngine;

namespace TowerDefence.Editor
{
    [CustomEditor(typeof(EnemyRouteBuilder))]
    [CanEditMultipleObjects]
    public class PathBuilderEditor : UnityEditor.Editor
    {
        private SerializedProperty _waypointsProperty;
        private SerializedProperty _enemyRouteProperty;
        private EnemyRoute _enemyRoute;

        private bool _isXLocked;
        private bool _isYLocked;
        private bool _isZLocked;

        private void OnEnable() => UpdateVariables();

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            if (GUI.changed)
                UpdateVariables();
            
            if (_enemyRoute == null)
                return;

            EditorGUILayout.BeginHorizontal();

            if (_enemyRouteProperty != null && GUILayout.Button("Load"))
                LoadWaypointsFromAsset();

            if (_enemyRouteProperty != null && GUILayout.Button("Save"))
                SaveWaypointsToAsset();

            EditorGUILayout.EndHorizontal();
        }

        private void UpdateVariables()
        {
            _waypointsProperty = serializedObject.FindProperty("waypoints");
            _enemyRouteProperty = serializedObject.FindProperty("enemyRoute");
            _enemyRoute = GetEnemyRoute();
        }

        private EnemyRoute GetEnemyRoute()
        {
            if (_enemyRouteProperty is not { propertyType: SerializedPropertyType.ObjectReference })
                return null;

            string path = AssetDatabase.GetAssetPath(_enemyRouteProperty.objectReferenceValue);
            return AssetDatabase.LoadAssetAtPath<EnemyRoute>(path);
        }

        private void LoadWaypointsFromAsset()
        {
            int arraySize = _enemyRoute.waypoints.Length;
            _waypointsProperty.arraySize = arraySize;
            for (var index = 0; index < arraySize; index++) 
                _waypointsProperty.GetArrayElementAtIndex(index).vector3Value = _enemyRoute.waypoints[index];
            serializedObject.ApplyModifiedProperties();
        }

        private void SaveWaypointsToAsset()
        {
            int arraySize = _waypointsProperty.arraySize;
            _enemyRoute.waypoints = new Vector3[_waypointsProperty.arraySize];
            for (var index = 0; index < arraySize; index++) 
                _enemyRoute.waypoints[index] = _waypointsProperty.GetArrayElementAtIndex(index).vector3Value;
        }

        public void OnSceneGUI()
        { 
            for (var index = 0; index < _waypointsProperty.arraySize; index++)
            {
                Vector3 oldWaypoint = _waypointsProperty.GetArrayElementAtIndex(index).vector3Value;
                Vector3 newWaypoint = Handles.DoPositionHandle(oldWaypoint, Quaternion.identity);
                _waypointsProperty.GetArrayElementAtIndex(index).vector3Value = newWaypoint;
            }
            
            _waypointsProperty.serializedObject.ApplyModifiedProperties();
        }
    }
}