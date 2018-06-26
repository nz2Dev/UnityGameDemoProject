using UnityEngine;

namespace Game.Characters.Extensions
{
    public class BowController : MonoBehaviour
    {
        Character character;
        Transform righHand;
        Bowstring bowstring;

        void Start()
        {
            character = GetComponentInParent<Character>();
            if (character != null)
            {
                righHand = character.FindPart(Part.RighHand);
                bowstring = GetComponentInChildren<Bowstring>();
            }
        }

        void OnAnimEvent()
        {
//            if ("isGrabEvent")
//            {
//                Grab();
//            }
//            if ("isReleaseEvent")
//            {
//                Release();
//                ThrowArrow();
//            }
        }
        
    }
}