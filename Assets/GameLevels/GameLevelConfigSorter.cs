using System;
using System.Collections.Generic;
using TD.Assets.GameLevels.Tiles;
using UnityEngine;

namespace TD.Assets.GameLevels
{
    public class GameLevelConfigSorter : IGameLevelConfigSorter
    {
        public Dictionary<Type, Dictionary<Vector2Int, TileParameters>> SortingConfig(GameLevelConfig config)
        {
            var result = new Dictionary<Type, Dictionary<Vector2Int, TileParameters>>();
            foreach (var tile in config.GetTilesConfig())
            {
                var type = tile.Value.GetFirstParameter().GetTileStatus().GetType();
                if (!result.ContainsKey(type))
                {
                    result.Add(type, new Dictionary<Vector2Int, TileParameters>());
                }

                result[type].Add(tile.Key, tile.Value);
            }

            return result;
        }
    }
}
