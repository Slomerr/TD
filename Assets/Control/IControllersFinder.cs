using System.Collections.Generic;

namespace TD.Assets.Control
{
    public  interface IControllersFinder
    {
        List<IController> CollectControllers();
    }
}