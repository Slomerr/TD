namespace TD.Assets.Enemies
{
    public class EnemyConfig : IEnemyConfig
    {
        private float m_Speed;

        public EnemyConfig(float speed)
        {
            m_Speed = speed;
        }

        public float GetSpeed()
        {
            return m_Speed;
        }
    }
}
