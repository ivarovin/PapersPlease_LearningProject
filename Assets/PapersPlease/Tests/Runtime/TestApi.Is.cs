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
    }
}