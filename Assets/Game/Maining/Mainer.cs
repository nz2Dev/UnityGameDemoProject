using UnityEngine;

namespace Game.Maining
{
    public class Mainer : MonoBehaviour
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