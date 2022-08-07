using System.Collections.Generic;
using UnityEngine;

namespace TD.Assets.Control
{
    public class ControllersFinder : MonoBehaviour, IControllersFinder
    {
        public List<IController> CollectControllers()
        {
            var controllers = FindObjectsOfType<BaseController>();
            List<IController> result = new List<IController>();
            for (int i = 0; i < controllers.Length; ++i)
            {
                if (controllers[i] is IController controller)
                {
                    result.Add(controller);
                }
            }

            return result;
        }
    }
}
