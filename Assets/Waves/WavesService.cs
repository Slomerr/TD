using System.Collections.Generic;
using TD.Assets.Enemies;
using UnityEngine;
using Zenject;

namespace TD.Assets.Waves
{
    public class WavesService : IWavesService, IInitializable
    {
        [Inject] private ICustomLogger m_CustomLogger;
        [Inject] private IWavesProcessor m_WavesProcessor;

        private IWavesConfig m_WavesConfig;
        private IWavesConfigLoader m_WavesConfigLoader;

        public void Initialize()
        {
            m_WavesConfigLoader = new WavesConfigLoader();
        }

        public void LoadWavesConfig(string wavesConfigKey)
        {
            m_WavesConfig = m_WavesConfigLoader.Load(wavesConfigKey);
            if (m_WavesConfig == null)
            {
                m_CustomLogger.LogError($"Don't set {nameof(IWavesConfig)} at {nameof(WavesService)}.{nameof(LoadWavesConfig)}");
            }
        }

        public void StartWaves(IPath path)
        {
            m_WavesProcessor.StartWavesConfig(m_WavesConfig, path);
        }
    }
}