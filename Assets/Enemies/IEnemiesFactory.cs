namespace TD.Assets.Enemies
{
    public interface IEnemiesFactory
    {
        void CreateEnemy(string enemyKey, IEnemyConfig config, IPath path);
    }
}