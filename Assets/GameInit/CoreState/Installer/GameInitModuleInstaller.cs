using UnityEngine;
using Zenject;

namespace TD.Assets.GameInit.CoreState.Installer
{
    public class GameInitModuleInstaller : MonoInstaller
    {
        [SerializeField] private GameEvents m_GamneEventsPrefab;

        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<CoreStateManager>().AsSingle();
            Container.BindInterfacesAndSelfTo<GameEvents>().FromInstance(m_GamneEventsPrefab).AsCached();
        }
    }
}