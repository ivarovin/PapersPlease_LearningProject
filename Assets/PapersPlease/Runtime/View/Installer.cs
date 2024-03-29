﻿using PapersPlease.Runtime.Controller;
using PapersPlease.Runtime.Model;
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
            Container.BindInterfacesAndSelfTo<Economy>().AsSingle();
            Container.Bind<WorkdayPerformance>().AsSingle();
        }
        
        void InstallControllers()
        {
            Container.Bind<StartDay>().AsSingle();
            Container.Bind<EndDay>().AsSingle();
            Container.Bind<CallForNextEntrant>().AsSingle();
            Container.Bind<TimePassage>().AsSingle();
            Container.Bind<ShowNewspaper>().AsSingle();
            Container.Bind<Gameplay>().AsSingle();
            Container.Bind<InspectPassport>().AsSingle();
        }

        void InstallViews()
        {
            Container.BindInterfacesTo<CanvasNewspaper>().FromComponentInHierarchy().AsSingle();
            Container.BindInterfacesTo<DigitalClock>().FromComponentInHierarchy().AsSingle();
            Container.BindInterfacesTo<WalkToWorkButton>().FromComponentsInHierarchy().AsSingle();
            Container.BindInterfacesTo<Typewriter>().FromComponentsInHierarchy().AsSingle();
            Container.BindInterfacesTo<SpeakerButton>().FromComponentsInHierarchy().AsSingle();
            Container.BindInterfacesTo<EndDayScreen>().FromComponentsInHierarchy().AsSingle();
        }
    }
}