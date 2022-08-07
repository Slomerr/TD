
namespace TD.Assets.Waves
{
    internal interface IWavesConfigLoader
    {
        IWavesConfig Load(string wavesConfigKey);
    }
}
