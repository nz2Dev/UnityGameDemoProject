using System;
using Game.Utils;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Game.Cameras
{
    [RequireComponent(typeof(Camera))]
    public class CameraRaycaster : MonoBehaviour
    {
        public event Action<Layer> OnLayerChanged;
        public Layer LastNotifiedLayer { get; private set; }
        public RaycastHit LastHit { get; private set; }

        Camera raycastCamera;

        void Start()
        {
            LastNotifiedLayer = Layer.Unknown;
            raycastCamera = GetComponent<Camera>();
        }

        void Update()
        {
            if (EventSystem.current != null && EventSystem.current.IsPointerOverGameObject())
            {
                NotifyObserersIfLayerChanged(Layer.UI);
                return;
            }

            var hit = CameraUtils.HitLayer(raycastCamera, ~0);
            if (hit != null)
            {
                LastHit = hit.Value;
                NotifyObserersIfLayerChanged((Layer) hit.Value.collider.gameObject.layer);
            }
        }

        void NotifyObserersIfLayerChanged(Layer newLayer)
        {
            if (newLayer != LastNotifiedLayer)
            {
                LastNotifiedLayer = newLayer;
                if (OnLayerChanged != null) OnLayerChanged(newLayer);
            }
        }
    }
}