using System.Collections.Generic;
using TD.Assets.GameLevels;
using TD.Assets.GameLevels.Tiles;
using UnityEngine;
using Zenject;

namespace TD.Assets.Towers
{
    public class TowersFactoryManager : ITowersFactoryManager, IInitializable
    {
        [Inject] private IGameLevelsService m_GameLevelService;
        [Inject] private ICustomLogger m_CustomLogger;

        private ITowersFactory m_TowerFactory;
        private Dictionary<Vector2Int, ITower> m_Towers;

        public void Initialize()
        {
            m_TowerFactory = new TowersFactory(m_CustomLogger, new TowerProvider());
            m_Towers = new Dictionary<Vector2Int, ITower>();
        }

        public void Create(Vector2Int position)
        {
            if (!m_GameLevelService.WasInitializedGameLevel())
            {
                m_CustomLogger.Log($"Towers >>> {nameof(GameLevelsService)} still has not initialized a {nameof(IGameLevel)} still");
                return;
            }

            if (ContainTowerAtPosition(position))
            {
                m_CustomLogger.Log($"Towers >>> was created tower at that position");
                return;
            }

            var config = m_GameLevelService.GetGameLevel().GetConfig();
            if (!config.GetTilesConfig().ContainsKey(position))
            {
                m_CustomLogger.LogError($"Towers >>> {nameof(GameLevelConfig)} does not contain cell with position [{position}]");
                return;
            }

            var parameters = config.GetTilesConfig()[position];
            if (ValidateParameters(parameters))
            {
                var tower = m_TowerFactory.Create(position);
                m_Towers.Add(position, tower);
                return;
            }

            m_CustomLogger.Log($"Towers >>> {nameof(TileParameters)} is not valid for create {nameof(ITower)}");
        }

        private bool ContainTowerAtPosition(Vector2Int position)
        {
            return m_Towers.ContainsKey(position);
        }

        private bool ValidateParameters(TileParameters tileParameters)
        {
            var status = tileParameters.GetFirstParameter().GetTileStatus().GetType() == typeof(EmptyStatus);
            var count = tileParameters.GetParameters().Count == 1;
            return status && count;
        }
    }
}
