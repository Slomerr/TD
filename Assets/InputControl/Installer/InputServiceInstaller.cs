using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace TD.Assets.InputControl.Installer
{
    public class InputServiceInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<InputService>().AsSingle();
        }
    }
}
