using PapersPlease.Runtime.Controller;
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
            Container.BindInterfacesAndSelfTo<Workday>().FromInstance(Workday.FirstOne()).AsSingle();
        }

        void InstallViews()
        {
            Container.BindInterfacesTo<LabelDayView>().FromComponentInHierarchy().AsSingle();
            Container.BindInterfacesTo<DigitalClock>().FromComponentInHierarchy().AsSingle();
        }

        void InstallControllers()
        {
            Container.Bind<StartDay>().AsSingle();
            Container.Bind<EndDay>().AsSingle();
            Container.Bind<CallForNextImmigrant>().AsSingle();
            Container.Bind<TimePassage>().AsSingle();
        }
    }
}