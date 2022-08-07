using Zenject;

namespace TD.Assets.GameLevels.Installer
{
    public class GameLevelsModuleInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<GameLevelsService>().AsSingle();
            Container.BindInterfacesAndSelfTo<BaseManager>().AsSingle();
        }
    }
}
