using PapersPlease.Runtime.View;
using UnityEngine;

namespace PapersPlease.Tests.Runtime
{
    public static class Is
    {
        public static bool TypewritterHidden()
        {
            return UnityEngine.Object.FindObjectOfType<Typewriter>()
                .GetComponentInParent<CanvasGroup>()
                .alpha == 0;
        }

        public static bool NewspaperHidden()
        {
            return UnityEngine.Object.FindObjectOfType<CanvasNewspaper>()
                .GetComponentInParent<CanvasGroup>()
                .alpha == 0;
        }

        public static bool ExpensesReportVisible()
        {
            return UnityEngine.Object.FindObjectOfType<EndDayScreen>(true)
                .gameObject.activeInHierarchy == true;
        }
    }
}