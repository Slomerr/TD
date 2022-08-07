using System.Collections.Generic;

namespace TD.Assets.Control
{
    public interface IControllersCreator
    {
        List<IController> Create();
    }
}