using TD.Assets.Towers.Weapons;
using UnityEngine;

namespace TD.Assets.Towers
{
    internal class Tower : ITower
    {
        private Vector2Int m_Position;
        private TowerView m_TowerView;
        private ITowerConfig m_Config;
        private IWeapon m_Weapon;
        private IEnemyDetector m_EnemyDetector;

        public Tower(Vector2Int position, TowerView towerView, ITowerConfig config, 
                     IWeapon weapon, IEnemyDetector enemyDetector)
        {
            m_Position = position;
            m_TowerView = towerView;
            m_Config = config;
            m_Weapon = weapon;
            m_EnemyDetector = enemyDetector;
            m_Weapon.Init(this, m_Config.GetWeaponConfig());
            m_EnemyDetector.Init(this, m_Config.GetEnemyDetectorConfig());
        }

        public IEnemyDetector GetEnemyDetector()
        {
            return m_EnemyDetector;
        }

        public Vector3 GetPosition()
        {
            return new Vector3(m_Position.x, m_Position.y, 0);
        }

        public IWeapon GetWeapon()
        {
            return m_Weapon;
        }
    }
}