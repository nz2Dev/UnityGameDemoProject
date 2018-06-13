using System.Linq;
using Game.Inputs;
using UnityEngine;

namespace Game.UI
{
    public class InputUI : MonoBehaviour
    {
        [SerializeField] TriggersHost triggersHost = null;

        void Update()
        {
            if (triggersHost == null)
            {
                return;
            }

            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                triggersHost.GetTriggers().First().OnTrigger(new Inputs.Event
                {
                    GameObject = null,
                    Point = Vector3.zero
                });
            }
        }
    }
}