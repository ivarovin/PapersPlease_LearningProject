using System;
using PapersPlease.Runtime.Controller;
using UnityEngine;
using Zenject;

namespace PapersPlease.Runtime.View
{
    public class EntryPoint : MonoBehaviour
    {
        public static TimeSpan RealtimeWorkday = TimeSpan.FromSeconds(8);
        
        [Inject] TimePassage time;
        [Inject] Gameplay gameplay;

        async void Start()
        {
            await gameplay.Run(RealtimeWorkday);
        }
        
        void Update()
        {
            time.Inject(TimeSpan.FromSeconds(Time.deltaTime));
            
            if(Input.GetKeyDown(KeyCode.Space))
                EndDayAtOnce();
        }

        /// QA. Refactor. 
        public void EndDayAtOnce()
        {
            time.Inject(RealtimeWorkday);
        }
    }
}