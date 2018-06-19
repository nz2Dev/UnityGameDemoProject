using System.Linq;
using UnityEngine;

namespace Game.Utils
{
    public static class ComponentExtension
    {
        public static T GetComponentInChildrenOnly<T>(this MonoBehaviour gameObject) where T : Component
        {
            return gameObject.GetComponentsInChildren<T>()
                .FirstOrDefault(component => component.transform != gameObject.transform);
        }
    }
}