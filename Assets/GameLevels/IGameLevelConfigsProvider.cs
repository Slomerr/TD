using UnityEngine;

namespace TD.Assets.GameLevels
{
    public interface IGameLevelConfigsProvider
    {
        TextAsset GetGameLevelConfig(int index);
    }
}