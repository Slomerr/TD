using TD.Assets.GameLevels.Tiles;

namespace TD.Assets.GameLevels.Parsing
{
    public interface ITileStatusFactory
    {
        ITileStatus ParseToStatus(string status);
    }
}
