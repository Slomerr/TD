using TD.Assets.Enemies;

namespace TD.Assets.Waves
{
    public interface ISpawnConfig
    {
        string GetEnemyKey();
        IEnemyConfig GetEnemyConfig();
        int GetSpawnInterval();
        int GetDelayToStartSpawn();
        int GetCountToSpawn();
    }
}