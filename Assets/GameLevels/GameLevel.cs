using System;
using TD.Assets.Enemies;
using TD.Assets.GameLevels.Tiles;
using UnityEngine;

namespace TD.Assets.GameLevels
{
    public class GameLevel : IGameLevel
    {
        private ILevelBase m_LevelBase;
        private GameLevelConfig m_Config;
        private IPath m_Path;
        private IPathGenerator m_PathGenerator;
        private ICustomLogger m_CustomLogger;
        private IGameLevelView m_View;

        public GameLevel(ICustomLogger customLogger, IGameLevelView view)
        {
            m_CustomLogger = customLogger;
            m_View = view;
        }

        public void Init(GameLevelConfig config)
        {
            m_Config = config;
            m_LevelBase = new LevelBase(m_Config.GetMaxHealthPoints());
            m_PathGenerator = new PathGenerator(m_CustomLogger);
            m_Path = m_PathGenerator.Generate(m_Config);
            m_View.GenerateView(m_Config);
        }

        public ILevelBase GetBase()
        {
            return m_LevelBase;
        }

        public IPath GetPath()
        {
            return m_Path;
        }

        public GameLevelConfig GetConfig()
        {
            return m_Config;
        }
    }
}