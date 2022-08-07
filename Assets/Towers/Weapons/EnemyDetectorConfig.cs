namespace TD.Assets.Towers.Weapons
{
    public class EnemyDetectorConfig : IEnemyDetectorConfig
    {
        private float m_DetectDistance;

        private EnemyDetectorConfig(float detectDistance)
        {
            m_DetectDistance = detectDistance;
        }

        public float GetDetectDistance()
        {
            return m_DetectDistance;   
        }
    }
}
