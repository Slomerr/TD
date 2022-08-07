using TD.Assets.Towers.Weapons;
using UnityEngine;

namespace TD.Assets.Towers
{
    public class TowersFactory : ITowersFactory
    {
        private ICustomLogger m_CustomLogger;
        private ITowerProvider m_TowerProvider;

        public TowersFactory(ICustomLogger customLogger, ITowerProvider towerProvider)
        {
            m_CustomLogger = customLogger;
            m_TowerProvider = towerProvider;
        }

        public ITower Create(Vector2Int position)
        {
            var view = Generate(m_TowerProvider.GetTowerView("Tower"), position);
            IWeapon weapon = new MachineGun(m_CustomLogger);
            IEnemyDetector detector = new EnemyDetector(m_CustomLogger);
            IWeaponConfig weaponConfig = new WeaponConfig();
            IEnemyDetectorConfig detectorConfig = new EnemyDetectorConfig(10f);
            ITowerConfig towerConfig = new TowerConfig(weaponConfig, detectorConfig);
            ITower tower = new Tower(position, view, towerConfig, weapon, detector);
            m_CustomLogger.Log($"Create tower at position [{position}]");
            return tower;
        }

        private TowerView Generate(TowerView prefab, Vector2Int position)
        {
            return TowerView.Instantiate(prefab, new Vector3(position.x, position.y), Quaternion.identity);
        }
    }
}
