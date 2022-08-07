using UnityEngine;

namespace TD.Assets.Enemies
{
    public class Enemy : IEnemy
    {
        private IEnemyConfig m_Config;
        private IPath m_Path;
        private ICustomLogger m_Logger;
        private string m_ID;
        private GameObject m_View;

        public Enemy(string id, ICustomLogger logger)
        {
            m_ID = id;
            m_Logger = logger;
            m_View = GameObject.CreatePrimitive(PrimitiveType.Cube);
            m_View.transform.position = Vector3.zero;
        }

        public void SetConfig(IEnemyConfig config)
        {
            m_Config = config;
        }

        public void SetPath(IPath path)
        {
            m_Path = path;
        }

        public IPath GetPath()
        {
            return m_Path;
        }

        public void UpdatePath()
        {
            m_View.transform.position = m_Path.GetPosition();
        }

        public IEnemyConfig GetEnemyConfig()
        {
            return m_Config;
        }
    }
}
