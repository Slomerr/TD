using System.Collections.Generic;

namespace TD.Assets.Waves
{
    public class WaveConfig : IWaveConfig
    {
        private List<ISpawnConfig> m_SpawnConfigs;

        public WaveConfig(List<ISpawnConfig> spawnConfigs)
        {
            m_SpawnConfigs = spawnConfigs;
        }

        public List<ISpawnConfig> GetSpawnConfigs()
        {
            return m_SpawnConfigs;
        }
    }
}
