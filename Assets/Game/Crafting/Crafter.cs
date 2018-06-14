using UnityEngine;

namespace Game.Crafting
{
    public class Crafter : MonoBehaviour
    {
        Tool tool;

        public void Use(Tool toolToUser)
        {
            tool = toolToUser;
            tool.AttachTo(gameObject);
        }

        public Tool GetTool()
        {
            return tool;
        }
    }
}