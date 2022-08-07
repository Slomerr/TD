using System;
using TD.Assets.Enemies;
using Zenject;

namespace TD.Assets.GameLevels
{
    public class BaseManager : IBaseManager, IInitializable
    {
        public event Action HealthPointsIsOver;

        [Inject] private IEnemiesMover m_EnemiesMover;
        [Inject] private ICustomLogger m_CustomLogger;

        private ILevelBase m_LevelBase;


        public void Initialize()
        {
            m_EnemiesMover.EnemyCompleteMove += EnemyCompletedMove;
        }

        public void SetBase(ILevelBase levelBase)
        {
            m_LevelBase = levelBase;
        }

        private void EnemyCompletedMove(IEnemy enemy, int index)
        {
            if (m_LevelBase == null)
            {
                m_CustomLogger.LogError($"Evemt complete move, but {nameof(ILevelBase)} still not set. {nameof(BaseManager)}");
                return;
            }

            if (m_LevelBase.HasHeathPoints())
            {
                m_LevelBase.AddHealthPoints(-1);
                if (!m_LevelBase.HasHeathPoints())
                {
                    HealthPointsIsOver?.Invoke();
                    return;
                }

                m_CustomLogger.Log($"Add health point [{-1}] to {nameof(ILevelBase)}, " +
                                   $"current health points is [{m_LevelBase.GetHealthPoints()}]");
            }
        }
    }
}
