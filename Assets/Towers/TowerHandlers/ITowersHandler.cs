using System.Collections.Generic;

namespace TD.Assets.Towers.TowerHandlers
{
    public interface ITowersHandler
    {
        void Handle(List<ITower> towers);
    }
}