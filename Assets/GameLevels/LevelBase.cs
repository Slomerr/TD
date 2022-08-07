using System;

namespace TD.Assets.GameLevels
{
    public class LevelBase : ILevelBase
    {
        private int m_HelthPoints;

        public LevelBase(int maxPoints)
        {
            m_HelthPoints = maxPoints;
        }

        public void AddHealthPoints(int healthPoints)
        {
            m_HelthPoints += healthPoints;
        }

        public int GetHealthPoints()
        {
            return m_HelthPoints;
        }

        public bool HasHeathPoints()
        {
            return 0 < m_HelthPoints;
        }
    }
}
