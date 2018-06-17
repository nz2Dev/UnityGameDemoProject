using UnityEngine;

namespace Game.Characters
{
    public class PartSocket : MonoBehaviour
    {
        [SerializeField] Part part = Part.Body;

        public Part GetPart()
        {
            return part;
        }
    }
}