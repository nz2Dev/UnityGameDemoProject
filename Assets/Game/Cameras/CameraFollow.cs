using UnityEngine;

namespace Game.Cameras
{
    [ExecuteInEditMode]
    [RequireComponent(typeof(Camera))]
    public class CameraFollow : MonoBehaviour
    {
        [SerializeField] Transform transformToFollow = null;
        CameraHolder holder;

        void Start()
        {
            if (!transform.parent || !transform.parent.GetComponent<CameraHolder>())
            {
                var holderGameObject = new GameObject("CameraSetup", typeof(CameraHolder));
                transform.parent = holderGameObject.transform;
            }

            holder = transform.parent.GetComponent<CameraHolder>();
        }

        void LateUpdate()
        {
            if (transformToFollow)
            {
                holder.transform.position = transformToFollow.position;
            }
        }
    }
}