using UnityEngine;

namespace TD.Assets.GameLevels
{
    public class GameLevelConfigsProvider : IGameLevelConfigsProvider
    {
        private GameLevelsPathsLibruary m_Libruary;
        private ICustomLogger m_CustomLogger;

        public GameLevelConfigsProvider(ICustomLogger customLogger)
        {
            m_Libruary = new GameLevelsPathsLibruary();
            m_CustomLogger = customLogger;
        }

        public TextAsset GetGameLevelConfig(int index)
        {
            var path = $"{m_Libruary.GetLevelConfigsPath()}/{string.Format(m_Libruary.GetLevelConfigNameFormat(), index)}";
            m_CustomLogger.Log($"Load GameLevelConfig by path [{path}]");
            return Resources.Load<TextAsset>(path);
        }
    }
}
