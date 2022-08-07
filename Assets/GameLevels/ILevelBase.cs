namespace TD.Assets.GameLevels
{
    public interface ILevelBase
    {
        int GetHealthPoints();
        void AddHealthPoints(int healthPoints);
        bool HasHeathPoints();
    }
}