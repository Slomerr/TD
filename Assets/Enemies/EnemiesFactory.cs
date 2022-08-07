using System;
using Zenject;

namespace TD.Assets.Enemies
{
    public class EnemiesFactory : IEnemiesFactory, IInitializable
    {
        [Inject] private ICustomLogger m_CustomLogger;
        [Inject] private IEnemiesStorage m_EnemyStorage;

        private IEnemyLoader m_EnemyLoader;

        public void Initialize()
        {
            m_EnemyLoader = new EnemyLoader(m_CustomLogger);
        }

        public void CreateEnemy(string enemyKey, IEnemyConfig config, IPath path)
        {
            var id = $"{enemyKey}_{m_EnemyStorage.GetCount()}";
            IEnemy enemy = new Enemy(id, m_CustomLogger);
            m_CustomLogger.Log($"Created enemy with [ID: {id}] at [time: {DateTime.Now}]");
            enemy.SetConfig(config);
            enemy.SetPath(path.Copy());
            m_EnemyStorage.AddEnemy(enemy);
        }
    }
}
