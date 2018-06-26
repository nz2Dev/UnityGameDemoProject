using Game.Characters;
using UnityEngine;

namespace Game.Actors.Plugins
{
    [CreateAssetMenu(menuName = "Plugin/Transform")]
    public class TransformPlugin : Plugin
    {
        [SerializeField] GameObject prefab = null;
        [SerializeField] Transform extraTransform = null;
        [SerializeField] Part part = Part.Body;

        public override void ApplyOn(Character character)
        {
            var characterPart = character.FindPart(part);
            var gameObject = Instantiate(prefab, characterPart);
            gameObject.transform.localPosition = extraTransform.localPosition;
            gameObject.transform.localRotation = extraTransform.localRotation;
            gameObject.transform.localScale = extraTransform.localScale;
        }
    }
}