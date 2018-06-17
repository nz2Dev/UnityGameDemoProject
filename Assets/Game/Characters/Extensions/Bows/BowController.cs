using UnityEngine;

namespace Game.Characters.Extensions.Bows
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

        // TODO implement event receiving from Character Animator.
    }
}