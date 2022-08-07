using TD.Assets.Enemies;

namespace TD.Assets.Waves
{
    public interface IWavesService
    {
        void LoadWavesConfig(string wavesConfigKey);
        void StartWaves(IPath path);
    }
}
