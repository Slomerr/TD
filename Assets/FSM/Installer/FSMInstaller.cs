using Zenject;

namespace FSM.Installer
{
    public class FSMInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<FSMController>().AsSingle();
            Container.BindInterfacesAndSelfTo<TestStateManager>().AsSingle();
        }
    }
}