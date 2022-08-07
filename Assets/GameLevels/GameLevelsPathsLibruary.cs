namespace TD.Assets.GameLevels
{
    public class GameLevelsPathsLibruary
    {
        private const string m_LevelConfigsPath = "GameLevelConfigs";
        private const string m_TilesPath = "Tiles";
        private const string m_LevelConfigNameFormat = "TD - Map_{0}";


        public string GetLevelConfigsPath()
        {
            return m_LevelConfigsPath;
        }

        public string GetTilesPath()
        {
            return m_TilesPath;
        }

        public string GetLevelConfigNameFormat()
        {
            return m_LevelConfigNameFormat;
        }
    }
}
