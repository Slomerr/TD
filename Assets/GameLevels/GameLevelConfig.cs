using System;
using System.Collections.Generic;
using TD.Assets.GameLevels.Tiles;
using UnityEngine;

namespace TD.Assets.GameLevels
{
    public class GameLevelConfig
    {
        private int m_MaxHealthPoints;
        private Dictionary<Vector2Int, TileParameters> m_TilesCofnig;
        private Dictionary<Type, Dictionary<Vector2Int, TileParameters>> m_SortedTiles;
        private ICustomLogger m_CustomLogger;

        public GameLevelConfig(int maxHealthPoints, 
                               Dictionary<Vector2Int, TileParameters> tilesConfig,
                               IGameLevelConfigSorter sorter,
                               ICustomLogger customLogger)
        {
            m_MaxHealthPoints = maxHealthPoints;
            m_TilesCofnig = tilesConfig;
            m_CustomLogger = customLogger; 
            m_SortedTiles = sorter.SortingConfig(this);
        }

        public int GetMaxHealthPoints()
        {
            return m_MaxHealthPoints;
        }

        public Dictionary<Vector2Int, TileParameters> GetTilesConfig()
        {
            return m_TilesCofnig;
        }

        public Dictionary<Type, Dictionary<Vector2Int, TileParameters>> GetSortedTiles()
        {
            return m_SortedTiles;
        }
    }
}
