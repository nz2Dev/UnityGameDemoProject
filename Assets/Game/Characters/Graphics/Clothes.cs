using UnityEngine;

namespace Game.Characters.Graphics
{
    [ExecuteInEditMode]
    [RequireComponent(typeof(SkinnedMeshRenderer))]
    public class Clothes : MonoBehaviour
    {
        const string ClothesContainerName = "Clothes";

        SkinnedMeshRenderer skin;
        ClothesContainer container;

        void Awake()
        {
            container = transform.parent.GetComponentInChildren<ClothesContainer>();
            if (!container)
            {
                var containerObject = new GameObject(ClothesContainerName, typeof(ClothesContainer));
                containerObject.transform.parent = transform.parent;
                container = containerObject.GetComponent<ClothesContainer>();
            }
        }

        void Start()
        {
            skin = GetComponent<SkinnedMeshRenderer>();
        }

        public void Wear(SkinnedMeshRenderer clothPrefab)
        {
            var cloth = Instantiate(clothPrefab, Vector3.zero, Quaternion.identity, container.transform);
            cloth.bones = skin.bones;
            cloth.rootBone = skin.rootBone;
        }
    }
}