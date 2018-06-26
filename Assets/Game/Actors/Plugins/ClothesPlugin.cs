using Game.Characters;
using UnityEngine;

namespace Game.Actors.Plugins
{
    [CreateAssetMenu(menuName = "Plugin/Clothes")]
    public class ClothesPlugin : Plugin
    {
        [SerializeField] SkinnedMeshRenderer prefab;
        [SerializeField] float shapeKeyValue;
        [SerializeField] int shapeKeyIndex;

        public override void ApplyOn(Character character)
        {
            var clothes = character.GetComponentInChildren<Clothes>();
            clothes.Wear(prefab);

            // TODO Also apply shape changes.
        }
    }
}