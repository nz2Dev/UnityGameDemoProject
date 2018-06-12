using Game.Characters;
using Game.Characters.Graphics;
using UnityEditor;
using UnityEngine;

namespace Game.Editor
{
    [CustomEditor(typeof(Clothes))]
    public class ClothesEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            var clothPrefab = (SkinnedMeshRenderer) EditorGUILayout.ObjectField(null, typeof(SkinnedMeshRenderer), false);
            if (clothPrefab != null)
            {
                var clothes = (Clothes) target;
                clothes.Wear(clothPrefab);
            }
        }
    }
}