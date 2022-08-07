using TD.Assets.Enemies;

namespace TD.Assets.Towers.Weapons
{
    public class MachineGun : IWeapon
    {
        private ITower m_Tower;
        private IWeaponConfig m_Config;
        private ICustomLogger m_CustomLogger;
        private IEnemy m_Enemy;

        public MachineGun(ICustomLogger customLogger)
        {
            m_CustomLogger = customLogger;
        }

        public void Init(ITower tower, IWeaponConfig config)
        {
            m_Tower = tower;
            m_Config = config;
        }

        public void SetEnemy(IEnemy enemy)
        {
            if (enemy != m_Enemy)
            {
                m_Enemy = enemy;
                if (enemy != null)
                {
                    m_CustomLogger.LogWarning($"Set enemy {enemy}");
                }
            }
        }

        public void Tick()
        {
            
        }
    }
}
