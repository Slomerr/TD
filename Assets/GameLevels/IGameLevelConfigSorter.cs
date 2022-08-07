using System;
using System.Collections.Generic;
using TD.Assets.GameLevels.Tiles;
using UnityEngine;

namespace TD.Assets.GameLevels
{
    public interface IGameLevelConfigSorter
    {
        Dictionary<Type, Dictionary<Vector2Int, TileParameters>> SortingConfig(GameLevelConfig config);
    }
}