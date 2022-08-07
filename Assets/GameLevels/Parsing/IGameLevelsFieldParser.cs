namespace TD.Assets.GameLevels.Parsing
{
    public interface IGameLevelsFieldParser
    {
        GameLevelConfig Parse(string csvConfig);
    }
}