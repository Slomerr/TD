using Zenject;

namespace TD.Assets.Enemies.Installer
{
    public class EnemiesModuleInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<EnemiesFactory>().AsSingle();
            Container.BindInterfacesAndSelfTo<EnemiesStorage>().AsSingle();
            Container.BindInterfacesAndSelfTo<EnemiesMover>().AsSingle();
        }
    }
}
