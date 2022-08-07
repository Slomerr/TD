using System.Collections.Generic;
using TD.Assets.Enemies;
using UnityEngine;

namespace TD.Assets.Waves
{
    internal class WavesConfigLoader : IWavesConfigLoader
    {
        private WavesPathsLibruary m_WavesPaths;

        public WavesConfigLoader()
        {
            m_WavesPaths = new WavesPathsLibruary();
        }

        public IWavesConfig Load(string wavesConfigKey)
        {
            /*var path = $"{m_WavesPaths.GetWavesConfigsPath()}/{wavesConfigKey}";
            Debug.Log($"Load {nameof(IWavesConfig)} by path [{path}]");
            return Resources.Load<WavesConfig>(path);*/
            return CreateConfig();
        }

        private IWavesConfig CreateConfig()
        {
            IEnemyConfig enemyConfig = new EnemyConfig(0.005f);
            return new WavesConfig(new List<IWaveConfig>()
            {
                new WaveConfig(new List<ISpawnConfig>()
                {
                    new SpawnConfig("enemyTest1",
                                    enemyConfig,
                                    2000,
                                    1000,
                                    5)
                }),
                new WaveConfig(new List<ISpawnConfig>()
                {
                    new SpawnConfig("enemyTest2",
                                    enemyConfig,
                                    2000,
                                    1000,
                                    5)
                })
            }, 5000);
        }
    }
}
