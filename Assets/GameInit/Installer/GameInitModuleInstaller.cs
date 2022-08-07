using UnityEngine;
using Zenject;

namespace TD.Assets.GameInit.Installer
{
    public class GameInitModuleInstaller : MonoInstaller
    {
        [SerializeField] private GameEvents m_GamneEventsPrefab;

        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<GameInitStateMachine>().AsSingle();
            Container.BindInterfacesAndSelfTo<GameEvents>().FromInstance(m_GamneEventsPrefab).AsCached();
        }
    }
}