using System.Collections.Generic;
using System.Linq;
using Game.Inputs;
using UnityEngine;
using UnityEngine.UI;

namespace Game.UI.Triggers.Activators
{
    public class TriggerSocket : Activator
    {
        public enum UserAction
        {
            Press,
            // TODO Click,
            // TODO Release
        }

        const int EmptyIndex = -1;

        [SerializeField] KeyCode key = KeyCode.Alpha1;
        [SerializeField] UserAction action = UserAction.Press;
        [SerializeField] int triggerIndex = EmptyIndex;

        public override void AssignTrigger(IEnumerable<Trigger> triggers)
        {
            if (triggerIndex == EmptyIndex)
                return;

            if (AssignedTrigger == null)
            {
                AssignedTrigger = triggers.ElementAtOrDefault(triggerIndex);
                if (AssignedTrigger != null)
                {
                    SetIcon();
                }
            }
        }

        public override bool IsActivated()
        {
            // TODO add condition to check if user click on UI element
            return AssignedTrigger != null && action == UserAction.Press && Input.GetKeyDown(key);
        }

        public override bool IsDeactivate()
        {
            return Input.GetKeyUp(KeyCode.Escape);
        }

        void SetIcon()
        {
            var icon = GetComponentInChildren<Image>();
            icon.sprite = AssignedTrigger.Construction.Icon;
            icon.enabled = true;
        }
    }
}