using System.Collections.Generic;

namespace TD.Assets.Waves
{
    public interface IWaveConfig
    {
        List<ISpawnConfig> GetSpawnConfigs();
    }
}