using TD.Assets.Enemies;
using TD.Assets.Towers;
using UnityEngine;

namespace TD.Assets.GameLevels
{
    public interface IGameLevel
    {
        void Init(GameLevelConfig config);
        ILevelBase GetBase();
        IPath GetPath();
        GameLevelConfig GetConfig();
    }
}