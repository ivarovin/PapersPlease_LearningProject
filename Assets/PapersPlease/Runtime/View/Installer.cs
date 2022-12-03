using System.Linq;
using PapersPlease.Runtime.Controller;
using PapersPlease.Runtime.Model;
using UnityEngine;
using Zenject;

namespace PapersPlease.Runtime.View
{
    public class Installer : MonoInstaller
    {
        public override void InstallBindings()
        {
            InstallModels();
            InstallControllers();
            InstallViews();
        }

        void InstallModels()
        {
            Container.BindInterfacesAndSelfTo<Workday>().FromInstance(Workday.FirstOne).AsSingle();
        }
        
        void InstallControllers()
        {
            Container.Bind<StartDay>().AsSingle();
            Container.Bind<EndDay>().AsSingle();
            Container.Bind<CallForNextEntrant>().AsSingle();
            Container.Bind<TimePassage>().AsSingle();
            Container.Bind<ShowNewspaper>().AsSingle();
            Container.Bind<Gameplay>().AsSingle();
        }

        void InstallViews()
        {
            Debug.Log(FindObjectsOfType<CanvasNewspaper>().Any());
            InstallNewspaper();
            Container.BindInterfacesTo<DigitalClock>().FromComponentInHierarchy().AsSingle();
            Container.BindInterfacesTo<Typewriter>().FromComponentsInHierarchy().AsSingle();
            Container.BindInterfacesTo<SpeakerButton>().FromComponentsInHierarchy().AsSingle();
        }

        void InstallNewspaper()
        {
            Container.BindInterfacesTo<CanvasNewspaper>().FromInstance(FindObjectsOfType<CanvasNewspaper>().Single()).AsSingle();
            Container.BindInterfacesTo<WalkToWorkButton>().FromInstance(FindObjectsOfType<WalkToWorkButton>().Single()).AsSingle();
        }
    }
}