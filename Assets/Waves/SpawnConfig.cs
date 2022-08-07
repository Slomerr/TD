using TD.Assets.Enemies;

namespace TD.Assets.Waves
{
    public class SpawnConfig : ISpawnConfig
    {
        private string m_EnemyKey;
        private IEnemyConfig m_EnemyConfig;
        private int m_SpawnInterval;
        private int m_DelayToStartSpawn;
        private int m_CountToSpawn;

        public SpawnConfig(string enemyKey,
                           IEnemyConfig enemyConfig,
                           int spawnInterval,
                           int delayToStartSpawn,
                           int countToSpawn)
        {
            m_EnemyKey = enemyKey;
            m_EnemyConfig = enemyConfig;   
            m_SpawnInterval = spawnInterval;
            m_DelayToStartSpawn = delayToStartSpawn;
            m_CountToSpawn = countToSpawn;
        }

        public int GetDelayToStartSpawn()
        {
            return m_DelayToStartSpawn;
        }

        public IEnemyConfig GetEnemyConfig()
        {
            return m_EnemyConfig;
        }

        public string GetEnemyKey()
        {
            return m_EnemyKey;
        }

        public int GetSpawnInterval()
        {
            return m_SpawnInterval;
        }

        public int GetCountToSpawn()
        {
            return m_CountToSpawn;
        }
    }
}
