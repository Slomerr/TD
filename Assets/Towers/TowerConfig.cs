using TD.Assets.Towers.Weapons;

namespace TD.Assets.Towers
{
    public class TowerConfig : ITowerConfig
    {
        private IWeaponConfig m_WeaponConfig;
        private IEnemyDetectorConfig m_EnemyDetectorConfig;

        public TowerConfig(IWeaponConfig weaponConfig, IEnemyDetectorConfig enemyDetectorConfig)
        {
            m_WeaponConfig = weaponConfig;
            m_EnemyDetectorConfig = enemyDetectorConfig;
        }

        public IEnemyDetectorConfig GetEnemyDetectorConfig()
        {
            return m_EnemyDetectorConfig;
        }

        public IWeaponConfig GetWeaponConfig()
        {
            return m_WeaponConfig;
        }
    }
}
