using System.Collections.Generic;
using System.Linq;
using Game.Cameras;
using Game.Inputs;
using UnityEngine;

namespace Game.UI.Triggers.Activators
{
    public class MouseHover : Activator
    {
        [SerializeField] KeyCode key = KeyCode.Mouse0;
        CameraRaycaster cameraRaycaster;

        void Start()
        {
            cameraRaycaster = FindObjectOfType<CameraRaycaster>();
        }

        public override void AssignTrigger(IEnumerable<Trigger> triggers)
        {
            AssignedTrigger = triggers
                .FirstOrDefault(trigger => trigger.Context.Layer == cameraRaycaster.LastNotifiedLayer);
        }

        public override bool IsActivated()
        {
            // TODO Consider to move UserAction enum from TriggerSocket and use it there as well
            // TODO add condition to check if mouse hover some NON UI element
            return AssignedTrigger != null && Input.GetKeyDown(key);
        }

        public override bool IsDeactivate()
        {
            return Input.GetKeyUp(key);
        }
    }
}