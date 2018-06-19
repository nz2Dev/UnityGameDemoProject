using UnityEngine;

namespace Game.Utils
{
    public class CameraHelper
    {
        public static Vector3 WalkablePoint() {
            var walkableHit = CameraUtils.HitLayer(1 << (int) Layer.Walkable);
            return walkableHit.HasValue ? walkableHit.Value.point : Vector3.negativeInfinity;
        }
    }
}