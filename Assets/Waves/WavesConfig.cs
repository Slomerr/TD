using System.Collections.Generic;
using UnityEngine;

namespace TD.Assets.Waves
{
    public class WavesConfig : ScriptableObject, IWavesConfig
    {
        private List<IWaveConfig> m_WaveConfigs;
        private int m_DelayBetweenWaves;

        public WavesConfig(List<IWaveConfig> configs, int delayBetweenWaves)
        {
            m_WaveConfigs = configs;
            m_DelayBetweenWaves = delayBetweenWaves;
        }

        public int GetDelayBetweenWaves()
        {
            return m_DelayBetweenWaves;
        }

        public List<IWaveConfig> GetWaveConfigs()
        {
            return m_WaveConfigs;
        }
    }
}