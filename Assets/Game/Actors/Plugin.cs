using Game.Characters;
using UnityEngine;

namespace Game.Actors
{
    public abstract class Plugin : ScriptableObject
    {
        public abstract void ApplyOn(Character character);
    }
}