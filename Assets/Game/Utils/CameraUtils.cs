using System;
using System.Linq;
using UnityEngine;

namespace Game.Utils
{
    public class CameraUtils
    {
        public static TResult RaycastOnlyType<TResult>(LayerMask layerMask) where TResult : Component
        {
            return (TResult) RaycastOnlyType(typeof(TResult), layerMask);
        }

        public static Component RaycastOnlyType(Type type, LayerMask layerMask)
        {
            var hit = HitLayer(layerMask);
            return hit.HasValue ? hit.Value.collider.GetComponent(type) : null;
        }

        public static RaycastHit? HitLayer(LayerMask layerMask)
        {
            return HitLayer(Camera.main, layerMask);
        }

        public static RaycastHit? HitLayer(Camera camera, LayerMask layerMask)
        {
            if (camera == null)
                camera = Camera.main;

            var ray = camera.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100f, layerMask))
                return hit;

            return null;
        }
    }
}