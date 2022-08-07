using TD.Assets.Towers.Weapons;

namespace TD.Assets.Towers
{
    public class EnemyDetectorConfig : IEnemyDetectorConfig
    {
        private float m_DetectDistance;

        public EnemyDetectorConfig(float detectDistance)
        {
            m_DetectDistance = detectDistance;
        }

        public float GetDetectDistance()
        {
            return m_DetectDistance;
        }
    }
}
