using TD.Assets.Enemies;

namespace TD.Assets.GameLevels
{
    public interface IPathGenerator
    {
        IPath Generate(GameLevelConfig config);
    }
}