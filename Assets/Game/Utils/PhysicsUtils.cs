using System;
using System.Linq;
using UnityEngine;

namespace Game.Utils
{
    public class PhysicsUtils
    {
        public static Collider NearestCollider(Vector3 point, int radius, Func<Collider, bool> filter,
            LayerMask layerMask) {
            var colliders = Physics
                .OverlapSphere(point, radius, layerMask)
                .Where(filter)
                .ToList();

            colliders.Sort((collider, collider1) => {
                float distanceTo1 = Vector3.Distance(collider.transform.position, point);
                float distanceTo2 = Vector3.Distance(collider1.transform.position, point);
                return Mathf.RoundToInt(distanceTo1 - distanceTo2);
            });

            return colliders.FirstOrDefault();
        }
    }
}