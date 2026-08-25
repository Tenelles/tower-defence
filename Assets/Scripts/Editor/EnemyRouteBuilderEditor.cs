using Gameplay.EnemyRouting;
using UnityEditor;
using UnityEngine;

namespace Editor
{
    [CustomEditor(typeof(EnemyRouteBuilder))]
    public class EnemyRouteBuilderEditor : UnityEditor.Editor
    {
        private const string EnemyRoutesBaseName = "Assets/ScriptableObjects/EnemyRoutes/route.asset";

        private SerializedProperty _waypointsProperty;
        private SerializedProperty _enemyRouteProperty;

        private void OnEnable()
        {
            _waypointsProperty = serializedObject.FindProperty("waypoints");
            _enemyRouteProperty = serializedObject.FindProperty("enemyRoute");
        }

        public override void OnInspectorGUI()
        {
            if (_waypointsProperty == null)
                return;
            
            //serializedObject.Update();
            DrawAssetPropertyField();
            DrawSaveLoadButtons();
            DrawWaypointsField();
        }

        public void OnSceneGUI()
        {
            if (target is not EnemyRouteBuilder builder || builder.Waypoints is null || builder.Waypoints.Length == 0)
                return;

            serializedObject.Update();
            Tools.current = Tool.None;

            for (var index = 0; index < builder.Waypoints.Length; index++)
                builder.Waypoints[index] = Handles.PositionHandle(builder.Waypoints[index], Quaternion.identity);
        }

        private void DrawAssetPropertyField()
        {
            EditorGUI.BeginChangeCheck();
            EditorGUILayout.PropertyField(_enemyRouteProperty);
            if (EditorGUI.EndChangeCheck())
                serializedObject.ApplyModifiedPropertiesWithoutUndo();
        }

        private void DrawSaveLoadButtons()
        {
            bool shouldDisableButtons = _enemyRouteProperty.objectReferenceValue is not EnemyRouteAsset;

            EditorGUILayout.BeginHorizontal();
            EditorGUI.BeginDisabledGroup(shouldDisableButtons);

            if (GUILayout.Button("Load"))
                LoadWaypointsFromAsset();
            
            EditorGUI.EndDisabledGroup();

            if (GUILayout.Button("Save"))
                SaveWaypointsToAsset();

            EditorGUI.EndDisabledGroup();
            EditorGUILayout.EndHorizontal();
        }

        private void DrawWaypointsField()
        {
            EditorGUI.BeginChangeCheck();
            EditorGUILayout.PropertyField(_waypointsProperty, true);
            if (EditorGUI.EndChangeCheck())
                serializedObject.ApplyModifiedProperties();
        }

        private void LoadWaypointsFromAsset()
        {
            EnemyRouteAsset asset = GetEnemyRouteAsset();

            int arraySize = asset.waypoints.Length;
            _waypointsProperty.arraySize = arraySize;
            for (var index = 0; index < arraySize; index++)
                _waypointsProperty.GetArrayElementAtIndex(index).vector3Value = asset.waypoints[index];
            
            serializedObject.ApplyModifiedProperties();
        }

        private void SaveWaypointsToAsset()
        {
            EnemyRouteAsset asset = GetEnemyRouteAsset();
            int arraySize = _waypointsProperty.arraySize;
            asset.waypoints = new Vector3[arraySize];
            for (var index = 0; index < arraySize; index++)
                asset.waypoints[index] = _waypointsProperty.GetArrayElementAtIndex(index).vector3Value;

            AssetDatabase.SaveAssets();
            if (_enemyRouteProperty is { objectReferenceValue: null })
            {
                _enemyRouteProperty.objectReferenceValue = asset;
                serializedObject.ApplyModifiedProperties();
            }
        }

        private EnemyRouteAsset GetEnemyRouteAsset() =>
            _enemyRouteProperty?.objectReferenceValue as EnemyRouteAsset ?? CreateEnemyRoute();

        private static EnemyRouteAsset CreateEnemyRoute()
        {
            var instance = CreateInstance<EnemyRouteAsset>();
            string assetName = AssetDatabase.GenerateUniqueAssetPath(EnemyRoutesBaseName);
            
            AssetDatabase.CreateAsset(instance, assetName);
            Debug.Log($"Created new {nameof(EnemyRouteAsset)}: {assetName}");
            return AssetDatabase.LoadAssetAtPath<EnemyRouteAsset>(assetName);
        }
    }
}