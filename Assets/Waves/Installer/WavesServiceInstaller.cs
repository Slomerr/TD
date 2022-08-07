using Zenject;

namespace TD.Assets.Waves.Installer
{
    public class WavesServiceInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<WavesService>().AsSingle();
            Container.BindInterfacesAndSelfTo<WavesProcessor>().AsSingle();
        }
    }
}