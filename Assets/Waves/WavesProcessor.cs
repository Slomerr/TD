using System.Collections;
using TD.Assets.Enemies;
using TD.Assets.GameInit.CoreState;
using UnityEngine;
using Zenject;

namespace TD.Assets.Waves
{
    public class WavesProcessor : IWavesProcessor, IInitializable
    {
        private const float m_Milleseconds = 1000;

        [Inject] private IEnemiesFactory m_EnemiesFactory;
        [Inject] private ICustomLogger m_CustomLogger;

        private CoroutinesHolder m_CoroutinesHolder;

        public void Initialize()
        {
            var empty = new GameObject();
            m_CoroutinesHolder = empty.AddComponent<CoroutinesHolder>();
        }

        public void StartWavesConfig(IWavesConfig config, IPath path)
        {
            m_CoroutinesHolder.StartCoroutine(ProcessingWavesConfig(config, path));
        }

        private IEnumerator ProcessingWavesConfig(IWavesConfig config, IPath path)
        {            
            for (int i = 0; i < config.GetWaveConfigs().Count; i++)
            {
                m_CustomLogger.Log("Start WaveCofig");
                m_CoroutinesHolder.StartCoroutine(ProcessingWaveCofig(config.GetWaveConfigs()[i], path));
                m_CustomLogger.Log("Start delay between waves");
                yield return new WaitForSeconds(config.GetDelayBetweenWaves() / m_Milleseconds);
            }

            m_CustomLogger.Log("Complete WavesConfig");
        }

        private IEnumerator ProcessingWaveCofig(IWaveConfig config, IPath path)
        {
            for (int i = 0; i < config.GetSpawnConfigs().Count; i++)
            {
                var coroutine = m_CoroutinesHolder.StartCoroutine(ProcessSpawnConfig(config.GetSpawnConfigs()[i], path));
                yield return coroutine;
            }
        }

        private IEnumerator ProcessSpawnConfig(ISpawnConfig spawnConfig, IPath path)
        {
            yield return new WaitForSeconds(spawnConfig.GetDelayToStartSpawn() / m_Milleseconds);
            for (int i = 0; i < spawnConfig.GetCountToSpawn(); i++)
            {
                m_EnemiesFactory.CreateEnemy(spawnConfig.GetEnemyKey(), spawnConfig.GetEnemyConfig(), path);
                yield return new WaitForSeconds(spawnConfig.GetSpawnInterval() / m_Milleseconds);
            }

            m_CustomLogger.Log("Complete processing spawnConfig");
        }
    }
}
