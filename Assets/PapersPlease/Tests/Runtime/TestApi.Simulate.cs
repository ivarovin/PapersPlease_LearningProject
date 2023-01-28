using System.Collections;
using PapersPlease.Runtime.View;
using RGV.TestApi.Runtime;

namespace PapersPlease.Tests.Runtime
{
    public static class Simulate
    {
        public static IEnumerator WholeDay()
        {
            yield return WalkToWork();
            yield return WholeWorkday();
        }

        public static IEnumerator WholeWorkday()
        {
            yield return Wait.TheWorkdayToStart();
            yield return Wait.TheWorkdayToEnd();
        }
        
        public static IEnumerator WalkToWork()
        {
            yield return Wait.TheNewspaperToBeShown();
            TestApi.Fake.ClickOn<WalkToWorkButton>();
            yield return Wait.TheNewspaperToBeClosed();
            yield return Wait.NewDayTypewriter();
        }

        public static IEnumerator PassToNextDay()
        {
            TestApi.Fake.ClickOn<StartNewDayButton>();
            yield return null;
        }
    }
}