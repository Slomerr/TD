using System.Collections.Generic;
using Zenject;

namespace TD.Assets.Enemies
{
    public class EnemiesStorage : IEnemiesStorage, IInitializable
    {
        [Inject] private IEnemiesMover m_EnemyMover;

        private List<IEnemy> m_Enemies;

        public void Initialize()
        {
            m_Enemies = new List<IEnemy>();
            m_EnemyMover.EnemyCompleteMove += EnemyCompletedMove;
        }

        public void AddEnemy(IEnemy enemy)
        {
            m_Enemies.Add(enemy);
        }

        public List<IEnemy> GetEnemies()
        {
            return m_Enemies;
        }

        public int GetCount()
        {
            return m_Enemies.Count;
        }

        private void EnemyCompletedMove(IEnemy enemy, int index)
        {
            m_Enemies.RemoveAt(index);
        }
    }
}
