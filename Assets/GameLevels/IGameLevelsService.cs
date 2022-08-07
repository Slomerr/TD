using TD.Assets.Towers;
using UnityEngine;

namespace TD.Assets.GameLevels
{
    public interface IGameLevelsService
    {
        IGameLevel InitGameLevel(int index);
        IGameLevel GetGameLevel();
        bool WasInitializedGameLevel();
    }
}