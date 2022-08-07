namespace TD.Assets.Enemies
{
    public interface IEnemy
    {
        void SetConfig(IEnemyConfig config);
        void SetPath(IPath path);
        IPath GetPath();
        void UpdatePath();
        IEnemyConfig GetEnemyConfig();
    }
}