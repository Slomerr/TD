using Zenject;
using TD.Assets.GameLevels.Parsing;
using TD.Assets.GameLevels.Tiles;

namespace TD.Assets.GameLevels
{
    public class GameLevelsService : IGameLevelsService
    {
        private const string m_StandartTileName = "Grass";

        private ICustomLogger m_CustomLogger;        
        private IGameLevelConfigsProvider m_ConfigsProvider;
        private IGameLevelsFieldParser m_FieldParser;
        private ITileStatusFactory m_TileStatusFactory;
        private IGameLevel m_GameLevel;

        [Inject]
        public GameLevelsService(ICustomLogger customLogger)
        {
            m_CustomLogger = customLogger;
            m_ConfigsProvider = new GameLevelConfigsProvider(m_CustomLogger);
            m_TileStatusFactory = new TileStatusFactory(GetStandartTileStatus(), m_CustomLogger);
            m_FieldParser = new GameLevelsFieldParser(GetStandartTileParameter(),
                                                      m_TileStatusFactory,
                                                      m_CustomLogger,
                                                      new GameLevelConfigSorter());
        }

        public IGameLevel InitGameLevel(int index)
        {
            var textAsset = m_ConfigsProvider.GetGameLevelConfig(index);
            GameLevelConfig config = m_FieldParser.Parse(textAsset.text);
            m_GameLevel = new GameLevel(m_CustomLogger, new GameLevelView(new TilesProvider()));
            m_GameLevel.Init(config);
            return m_GameLevel;
        }

        public IGameLevel GetGameLevel()
        {
            return m_GameLevel;
        }

        private TileParameter GetStandartTileParameter()
        {
            return new TileParameter(m_StandartTileName, GetStandartTileStatus());
        }

        private ITileStatus GetStandartTileStatus()
        {
            return new EmptyStatus();
        }

        public bool WasInitializedGameLevel()
        {
            return m_GameLevel != null;
        }
    }
}