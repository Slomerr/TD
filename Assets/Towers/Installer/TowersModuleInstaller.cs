using Zenject;

namespace TD.Assets.Towers.Installer
{
    public class TowersModuleInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<TowersManager>().AsSingle();
            Container.BindInterfacesAndSelfTo<TowersFactoryManager>().AsSingle();
        }
    }
}
