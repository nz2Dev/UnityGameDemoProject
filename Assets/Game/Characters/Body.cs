using UnityEngine;

namespace Game.Characters
{
    [ExecuteInEditMode]
    [RequireComponent(typeof(SkinnedMeshRenderer))]
    public class Body : MonoBehaviour
    {
        SkinnedMeshRenderer skin;

        void Start()
        {
            skin = GetComponent<SkinnedMeshRenderer>();
        }

        public void Wear(SkinnedMeshRenderer clothPrefab)
        {
            var cloth = Instantiate(clothPrefab, Vector3.zero, Quaternion.identity, transform);
            cloth.bones = skin.bones;
            cloth.rootBone = skin.rootBone;
        }
    }
}