using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using UnityEngine;

namespace PapersPlease.Runtime.View
{
    public static class MonoBehaviourTaskExtensions
    {
        /// <summary>
        /// Allows to wait in a MonoBehaviour attending to its cancellation token. 
        /// </summary>
        /// <seealso cref="MonoBehaviour.destroyCancellationToken"/>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Task Delay(this MonoBehaviour monoBehaviour, TimeSpan delay)
        {
            return Task.Delay(delay / Time.timeScale, monoBehaviour.destroyCancellationToken);
        }
        
        /// <summary>
        /// Same than <see cref="Delay"/> but unscaled time. 
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Task DelayRealTime(this MonoBehaviour monoBehaviour, TimeSpan unscaledDelay)
        {
            return Task.Delay(unscaledDelay, monoBehaviour.destroyCancellationToken);
        }
    }
}