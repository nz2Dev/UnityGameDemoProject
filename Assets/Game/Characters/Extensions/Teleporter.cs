using UnityEngine;

namespace Game.Characters.Extensions
{
    public class Teleporter : MonoBehaviour
    {
        Character character;

        void Start()
        {
            character = GetComponentInParent<Character>();
        }

        public void Teleport(Vector3 point)
        {
            // character.GetComponent<MeshRenderer>().sharedMaterial.SetInt("Disolve", 100);
            character.transform.position = point;
            // character.GetComponent<MeshRenderer>().sharedMaterial.SetInt("Disolve", 0);
        }
    }
}