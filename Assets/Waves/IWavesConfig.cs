using System.Collections.Generic;

namespace TD.Assets.Waves
{
    public interface IWavesConfig
    {
        List<IWaveConfig> GetWaveConfigs();
        int GetDelayBetweenWaves();
    }
}
