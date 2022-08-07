using System;
using System.Collections.Generic;
using TD.Assets.Enemies;
using TD.Assets.Misc;

namespace TD.Assets.Towers.Weapons
{
    public class EnemyDetector : IEnemyDetector
    {
        private ICustomLogger m_CustomLogger;
        private ITower m_Tower;
        private IEnemyDetectorConfig m_DetectorConfig;
        private IEnemy m_DetectedEnemy;

        public EnemyDetector(ICustomLogger customLogger)
        {
            m_CustomLogger = customLogger;
        }

        public IEnemy GetDetectedEnemy()
        {
            return m_DetectedEnemy;
        }

        public void Init(ITower tower, IEnemyDetectorConfig config)
        {
            m_Tower = tower;
            m_DetectorConfig = config;
        }

        public Result<IEnemy> TryDetect(List<IEnemy> enemies)
        {
            if (WasInitialized())
            {
                if (enemies == null)
                {
                    m_CustomLogger.LogError($"{nameof(List<IEnemy>)} is null at {nameof(EnemyDetector)}.{nameof(TryDetect)}");
                    return new Result<IEnemy>(false, null);
                }

                if (enemies.Count == 0)
                {
                    return new Result<IEnemy>(false, null);
                }

                var towerPosition = m_Tower.GetPosition();
                for (int i = 0; i < enemies.Count; ++i)
                {
                    var distance = (enemies[i].GetPath().GetPosition() - towerPosition).magnitude;
                    if (Math.Abs(distance) <= m_DetectorConfig.GetDetectDistance())
                    {
                        m_DetectedEnemy = enemies[i];
                        return new Result<IEnemy>(true, enemies[i]);
                    }
                }

                return new Result<IEnemy>(false, null);
            }
            
            m_CustomLogger.Log($"Calling {nameof(TryDetect)}, but {nameof(EnemyDetector)} was not initialized");
            return new Result<IEnemy>(false, null);
        }

        public bool ValidateEnemyDistance()
        {
            if (WasInitialized())
            {
                if (m_DetectedEnemy == null)
                {
                    m_CustomLogger.LogError($"{nameof(IEnemy)} is null at {nameof(EnemyDetector)}.{nameof(ValidateEnemyDistance)}");
                    return false;
                }

                var distance = (m_DetectedEnemy.GetPath().GetPosition() - m_Tower.GetPosition()).magnitude;
                if (Math.Abs(distance) <= m_DetectorConfig.GetDetectDistance())
                {
                    return true;
                }

                m_DetectedEnemy = null;
                return false;
            }

            m_CustomLogger.Log($"Calling {nameof(ValidateEnemyDistance)}, but {nameof(EnemyDetector)} was not initialized");
            return false;
        }

        private bool WasInitialized()
        {
            return m_Tower != null && m_DetectorConfig != null;
        }
    }
}
