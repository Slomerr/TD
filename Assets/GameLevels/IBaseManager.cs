using System;
using TD.Assets.Enemies;

namespace TD.Assets.GameLevels
{
    public interface IBaseManager
    {
        event Action HealthPointsIsOver;

        void SetBase(ILevelBase levelBase);
    }
}