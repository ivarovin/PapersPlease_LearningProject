using PapersPlease.Runtime.Controller;
using UnityEngine;
using Zenject;

namespace PapersPlease.Runtime.View
{
    public class Installer : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<StartDay>().AsSingle();
            Container.Bind<EndDay>().AsSingle();
            Container.BindInterfacesTo<LabelDayView>().FromComponentInHierarchy().AsSingle();
        }
    }
}