using UnityEngine;

namespace Game.Characters
{
    public abstract class Plugin : ScriptableObject
    {
        public abstract void ApplyOn(Character character);
    }
}