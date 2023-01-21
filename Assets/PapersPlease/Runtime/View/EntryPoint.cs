using System;
using System.Threading.Tasks;
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

        void Start()
        {
            SafeAwaitOf(gameplay.Run(RealtimeWorkday, destroyCancellationToken));
        }

        static async void SafeAwaitOf(Task task)
        {
            try { await task; }
            catch (OperationCanceledException) { }
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