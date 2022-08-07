using System;
using UnityEngine;
using Zenject;

namespace GameInit.InitState.Installer
{
    public class InitStateInstaller : MonoInstaller
    {
        [SerializeField] private StartPanel m_StartPanelPrefab;
        [SerializeField] private Transform m_UIRoot;
        
        public override void InstallBindings()
        {
            var panel = Instantiate(m_StartPanelPrefab, m_UIRoot);
            Container.BindInterfacesAndSelfTo<StartPanel>().FromInstance(panel).AsSingle();
            Container.BindInterfacesAndSelfTo<InitStateManager>().AsSingle();
        }
    }
}