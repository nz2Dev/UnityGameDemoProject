using Game.Characters;
using UnityEditor;
using UnityEngine;

namespace Game.Editor
{
    [CustomEditor(typeof(Body))]
    public class BodyEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            var clothPrefab = (SkinnedMeshRenderer) EditorGUILayout.ObjectField(null, typeof(SkinnedMeshRenderer), false);
            if (clothPrefab != null)
            {
                var body = (Body) target;
                body.Wear(clothPrefab);
            }
        }
    }
}