using System;
using Zenject;

namespace TD.Assets.Enemies
{
    public class EnemiesMover : IEnemiesMover, ITickable
    {
        public event Action<IEnemy, int> EnemyCompleteMove;

        [Inject] private IEnemiesStorage m_EnemyStorage;
        [Inject] private ICustomLogger m_CustomLogger;

        public void Tick()
        {
            var enemies = m_EnemyStorage.GetEnemies();
            for (int i = 0; i < enemies.Count; ++i)
            {
                UpdateEnemyPath(enemies[i], i);
            }
        }

        private void UpdateEnemyPath(IEnemy enemy, int index)
        {
            var path = enemy.GetPath();
            if (!path.IsCompleted())
            {
                var config = enemy.GetEnemyConfig();
                path.AddProgress(config.GetSpeed());
                enemy.UpdatePath();
                if (path.IsCompleted())
                {
                    m_CustomLogger.Log("Enemy path is done");
                    EnemyCompleteMove?.Invoke(enemy, index);
                }
            }
        }
    }
}
