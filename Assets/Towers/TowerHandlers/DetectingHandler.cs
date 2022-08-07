using System.Collections.Generic;
using TD.Assets.Enemies;

namespace TD.Assets.Towers.TowerHandlers
{
    public class DetectingHandler : ITowersHandler
    {
        private ICustomLogger m_CustomLogger;
        private IEnemiesStorage m_EnemiesStorage;

        public DetectingHandler(ICustomLogger customLogger, IEnemiesStorage enemiesStorage)
        {
            m_CustomLogger = customLogger;
            m_EnemiesStorage = enemiesStorage;
        }

        public void Handle(List<ITower> towers)
        {
            if (towers == null)
            {
                m_CustomLogger.LogError($"{nameof(List<ITower>)} is null at {nameof(DetectingHandler)}.{nameof(Handle)}");
                return;
            }

            for (int i = 0; i < towers.Count; ++i)
            {
                var detector = towers[i].GetEnemyDetector();
                if (detector.GetDetectedEnemy() == null)
                {
                    detector.TryDetect(m_EnemiesStorage.GetEnemies());
                }
                else
                {
                    detector.ValidateEnemyDistance();
                }

                towers[i].GetWeapon().SetEnemy(detector.GetDetectedEnemy());
                towers[i].GetWeapon().Tick();
            }
        }
    }
}
