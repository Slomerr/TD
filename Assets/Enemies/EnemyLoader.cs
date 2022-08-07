using UnityEngine;

namespace TD.Assets.Enemies
{
    public class EnemyLoader : IEnemyLoader
    {
        private EnemiesPathsLibruary m_PathsLibruary;
        private ICustomLogger m_Logger;

        public EnemyLoader(ICustomLogger logger)
        {
            m_Logger = logger;
        }

        public IEnemy LoadEnemy<T>(string enemyKey) where T : Object
        {
            var path = $"{m_PathsLibruary.GetEnemiesPrefabsPath()}/{enemyKey}";
            m_Logger.Log($"Load {nameof(IEnemy)} with type {nameof(T)} for path [{path}]");
            var loaded = Resources.Load<T>(path); 
            if (loaded == null)
            {
                m_Logger.LogError($"Can't load {nameof(IEnemy)}");
                return null;
            }

            if (loaded is IEnemy enemy)
            {
                m_Logger.Log($"Succes load {nameof(IEnemy)}");
                return enemy;
            }

            m_Logger.LogError($"Can't parce loaded to {nameof(IEnemy)}");
            return null;
        }
    }
}