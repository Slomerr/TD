using Zenject;

namespace TD.Assets.Misc.Installers
{
    public class LoggerInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<Logger>().AsSingle();
        }
    }
}
