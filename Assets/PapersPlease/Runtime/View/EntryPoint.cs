using System;
using PapersPlease.Runtime.Controller;
using UnityEngine;
using Zenject;

namespace PapersPlease.Runtime.View
{
    public class EntryPoint : MonoBehaviour
    {
        [Inject] TimePassage time;
        [Inject] Gameplay gameplay;

        async void Start()
        {
            await gameplay.Run();
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
            time.Inject(TimeSpan.FromHours(23));
        }
    }
}