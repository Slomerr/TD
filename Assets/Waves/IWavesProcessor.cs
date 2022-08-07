using TD.Assets.Enemies;

namespace TD.Assets.Waves
{
    public interface IWavesProcessor
    {
        void StartWavesConfig(IWavesConfig config, IPath path);
    }
}